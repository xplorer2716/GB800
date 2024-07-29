/*
GB 800 - A midi app to edit the Roland Super JX-10 tones (kind of PG-800 emulator), without requiring memory cartridge.
Copyright (C) 2012-2024 Pascal Schmitt

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using MidiApp.MidiController.Model;
using Sanford.Multimedia.Midi;
using System;
using System.IO;

namespace MidiApp.GB800.Model
{
    /// <summary>
    /// a class to write a tone to a sysex file
    /// </summary>
    internal class JXToneWriter : IToneWriter
    {
        public JXToneWriter()
        {
        }

        /// <summary>
        /// Write a tone to file.
        /// If filename already exists, overwrite tone parameters,and keep the name as it is.
        /// If not, generate a dummy tone intro.
        /// </summary>
        /// <param name="filename">Tone sysex filename</param>
        /// <param name="tone">the tone object</param>
        public void WriteTone(string sFilename, AbstractTone TheTone)
        {
            BinaryWriter binWriter = null;
            try
            {
                byte[] data;
                // generate intro if file does not exists
                if (!File.Exists(sFilename))
                {
                    data = (byte[])JXToneConstants.ALL_TONE_PARAM_INTRO.Clone();

                    // set the synthesizer type
                    if (((JXTone)TheTone).SynthetizerTypeIsJX10)
                    {
                        data[JXToneConstants.SYNTHETIZER_TYPE_POSITION] = (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70;
                    }
                    else
                    {
                        data[JXToneConstants.SYNTHETIZER_TYPE_POSITION] = (byte)JXToneConstants.EnumSynthetizerType.JX8P;
                    }

                    //updates Midi Channel (zero based)
                    data[JXToneConstants.CHANNEL_NUMBER_POSITION] = (byte)TheTone.MIDIChannel;

                    binWriter = new BinaryWriter(File.Open(sFilename, FileMode.Create));
                    binWriter.Write(data);

                    // write the name of the tone
                    binWriter.Write(System.Text.Encoding.ASCII.GetBytes(TheTone.ToneName.PadRight(JXToneConstants.TONE_NAME_LENGTH, (char)0x20)));
                    // generate the first undefined byte
                    binWriter.Write(JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES[0]);
                }
                else
                {
                    binWriter = new BinaryWriter(File.Open(sFilename, FileMode.Open));
                    // skip intro, name, and first undefined byte
                    binWriter.Seek(JXToneConstants.ALL_TONE_PARAM_INTRO.Length + JXToneConstants.TONE_NAME_LENGTH + 1, SeekOrigin.Begin);
                }

                // write the parameter
                data = new byte[JXToneConstants.TONE_DATA_LENGTH + 1]; //+1: for the final sysex byte
                int iParameterPosition = 0;
                int i = 0;
                for (i = 0; i < JXToneConstants.TONE_DATA_LENGTH; i++)
                {
                    // the "undefined" bytes.
                    if ((i + JXToneConstants.TONE_INTRO_LENGTH + JXToneConstants.TONE_NAME_LENGTH + 1) == JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[1])
                    {
                        data[i] = JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES[1];
                    }
                    else if ((i + JXToneConstants.TONE_INTRO_LENGTH + JXToneConstants.TONE_NAME_LENGTH + 1) == JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[2])
                    {
                        data[i] = JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES[2];
                    }
                    else if ((i + JXToneConstants.TONE_INTRO_LENGTH + JXToneConstants.TONE_NAME_LENGTH + 1) == JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[3])
                    {
                        data[i] = JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES[3];
                    }
                    else if ((i + JXToneConstants.TONE_INTRO_LENGTH + JXToneConstants.TONE_NAME_LENGTH + 1) == JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[4])
                    {
                        data[i] = JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES[4];
                    }
                    else
                    {
                        AbstractParameter parameter = (AbstractParameter)TheTone.ParameterMap[iParameterPosition];
                        data[i] = (byte)parameter.Value;
                        iParameterPosition++;
                    }
                }

                // do not forget the F7 final byte
                data[i] = (byte)SysExType.Continuation;
                binWriter.Write(data);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save tone sysex to " + sFilename, ex);
            }
            finally
            {
                if (binWriter != null)
                {
                    binWriter.Close();
                    binWriter = null;
                }
            }
        }
    }
}