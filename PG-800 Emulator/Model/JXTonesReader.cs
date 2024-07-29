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
using System.Collections.Generic;
using System.IO;

namespace MidiApp.GB800.Model
{
    internal class JXTonesReader : IEnumerable<JXTone>, IEnumerator<JXTone>
    {
        // type of tone sysex
        private JXToneConstants.EnumToneSysexType _ToneSysexType = JXToneConstants.EnumToneSysexType.UNKNOWN;

        /// <summary>
        /// file's binary reader
        /// </summary>
        private BinaryReader _binaryReader;

        // working buffer
        private byte[] _data = null;

        /// <summary>
        /// don't use it
        /// </summary>
        private JXTonesReader()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="reader"></param>
        public JXTonesReader(BinaryReader reader)
        {
            _binaryReader = reader;
            Reset();
        }

        #region IEnumerable<JXTone> Membres

        public IEnumerator<JXTone> GetEnumerator()
        {
            return this;
        }

        #endregion IEnumerable<JXTone> Membres

        #region IEnumerable Membres

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this;
        }

        #endregion IEnumerable Membres

        #region IEnumerator<JXTone> Membres

        public JXTone Current
        {
            get
            {
                JXTone tone = new JXTone();
                //channel
                tone.MIDIChannel = _data[JXToneConstants.CHANNEL_NUMBER_POSITION];
                // other metadata are ignored

                // tone name - avoid wrong chars
                int position = JXToneConstants.ToneNamePosition(_ToneSysexType);
                for (int i = JXToneConstants.ToneNamePosition(_ToneSysexType); i < position + JXToneConstants.TONE_NAME_LENGTH; i++)
                {
                    if ((_data[i] < 0x20) || (_data[i] > 0x7F))
                    {
                        _data[i] = 0x20;
                    }
                }
                //parse it
                tone.ToneName = System.Text.Encoding.ASCII.GetString(_data, JXToneConstants.ToneNamePosition(_ToneSysexType), JXToneConstants.TONE_NAME_LENGTH);
                tone.ToneName = tone.ToneName.TrimStart(null);

                // parameters data
                int ParameterPosition = -1;
                int StartPosition = JXToneConstants.ToneNamePosition(_ToneSysexType) + JXToneConstants.TONE_NAME_LENGTH + 1;
                int EndPosition = JXToneConstants.ToneSysexDataFullLength(_ToneSysexType) - 1; //skip terminator
                for (int i = StartPosition; i < EndPosition; i++)
                {
                    // skip the "undefined" bytes
                    if ((i != JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[1]) &&
                        (i != JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[2]) &&
                        (i != JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[3]) &&
                        (i != JXToneConstants.ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[4]))
                    {
                        // set the _value; parameters in map follow same order as APR tone data
                        ParameterPosition++;
                        AbstractParameter parameter = (AbstractParameter)tone.ParameterMap[ParameterPosition];
                        parameter.Value = _data[i];
                        parameter.Changed = true;
                    }
                }

                return tone;
            }
        }

        #endregion IEnumerator<JXTone> Membres

        #region IDisposable Membres

        public void Dispose()
        {
            _data = null;
        }

        #endregion IDisposable Membres

        #region IEnumerator Membres

        /// <summary>
        /// returns the current tone
        /// </summary>
        object System.Collections.IEnumerator.Current
        {
            get
            {
                return ((IEnumerator<JXTone>)this).Current;
            }
        }

        /// <summary>
        /// true if next tone available
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            // test intro bytes
            int byteCount = _binaryReader.Read(_data, 0, JXToneConstants.TONE_INTRO_LENGTH);
            while (byteCount == JXToneConstants.TONE_INTRO_LENGTH)
            {
                if (
                    (_data[0] == JXToneConstants.ALL_TONE_PARAM_INTRO[0]) &&
                    (_data[1] == JXToneConstants.ALL_TONE_PARAM_INTRO[1]) &&
                    (_data[2] == JXToneConstants.ALL_TONE_PARAM_INTRO[2]) &&
                    (_data[JXToneConstants.SYSEX_IS_TONE_POSITION] == JXToneConstants.ALL_TONE_PARAM_INTRO[JXToneConstants.SYSEX_IS_TONE_POSITION]))
                {
                    // read all tone data
                    int BytesToRead = JXToneConstants.ToneSysexDataFullLength(JXToneConstants.EnumToneSysexType.ALL_TONE_PARAMETER) - JXToneConstants.TONE_INTRO_LENGTH;
                    byteCount = _binaryReader.Read(_data, JXToneConstants.TONE_INTRO_LENGTH, BytesToRead);
                    if (byteCount != BytesToRead) return false;
                    _ToneSysexType = JXToneConstants.EnumToneSysexType.ALL_TONE_PARAMETER;
                    return true;
                }
                else if (
                 (_data[0] == JXToneConstants.BULK_DUMP_TONE_INTRO[0]) &&
                 (_data[1] == JXToneConstants.BULK_DUMP_TONE_INTRO[1]) &&
                 (_data[2] == JXToneConstants.BULK_DUMP_TONE_INTRO[2]) &&
                 (_data[JXToneConstants.SYSEX_IS_TONE_POSITION] == JXToneConstants.BULK_DUMP_TONE_INTRO[JXToneConstants.SYSEX_IS_TONE_POSITION]))
                {
                    // read all tone data
                    int BytesToRead = JXToneConstants.ToneSysexDataFullLength(JXToneConstants.EnumToneSysexType.BULK_DUMP) - JXToneConstants.TONE_INTRO_LENGTH;
                    byteCount = _binaryReader.Read(_data, JXToneConstants.TONE_INTRO_LENGTH, BytesToRead);
                    if (byteCount != BytesToRead) return false;
                    _ToneSysexType = JXToneConstants.EnumToneSysexType.BULK_DUMP;
                    return true;
                }
                else
                {
                    //go forward 1 byte
                    _binaryReader.BaseStream.Seek(-(JXToneConstants.TONE_INTRO_LENGTH - 1), SeekOrigin.Current);
                    byteCount = _binaryReader.Read(_data, 0, JXToneConstants.TONE_INTRO_LENGTH);
                }
            }

            return false;
        }

        public void Reset()
        {
            // start at begining of file
            _binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
            _ToneSysexType = JXToneConstants.EnumToneSysexType.UNKNOWN;
            _data = new byte[JXToneConstants.ToneSysexDataFullLength(JXToneConstants.EnumToneSysexType.BULK_DUMP)]; //biggest we will use
        }

        #endregion IEnumerator Membres
    }
}