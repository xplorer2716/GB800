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

using MidiApp.GB800.Model;
using MidiApp.MidiController.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MidiApp.GB800.Controller
{
    public class GB800Controller : MidiApp.MidiController.Controller.AbstractController
    {
        public GB800Controller()
            : base()
        {
        }

        //-------------------------------------------------------------------------------
        // base classe impl.
        protected override MidiApp.MidiController.Model.AbstractTone CreateToneInstance()
        {
            return new MidiApp.GB800.Model.JXTone();
        }

        public override int CurrentProgramNumber
        {
            get { throw new NotImplementedException(); }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// set the type of synth: JX-10/MKS-70 or JX-8P
        /// </summary>
        internal bool SynthetizerTypeIsJX10
        {
            get
            {
                return ((JXTone)Tone).SynthetizerTypeIsJX10;
            }
            set
            {
                ((JXTone)Tone).SynthetizerTypeIsJX10 = value;
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// returns the list of tones from the file name or null if problem occurs
        /// </summary>
        /// <param name="filename">the ssyex filename</param>
        /// <returns>list of tones</returns>
        internal List<JXTone> LoadTones(string sFilename)
        {
            BinaryReader binReader = null;
            JXTonesReader toneReader = null;
            List<JXTone> list = null;
            try
            {
                binReader = new BinaryReader(File.Open(sFilename, FileMode.Open));
                toneReader = new JXTonesReader(binReader);
                // we break here the MVC model, but we want to avoid to load tones twice and keep a local copy
                list = new List<JXTone>(toneReader);
            }
            finally
            {
                if (binReader != null)
                {
                    binReader.Close();
                    binReader = null;
                }
                if (toneReader != null)
                {
                    toneReader.Dispose();
                    toneReader = null;
                }
            }
            return list;
        }

        //-------------------------------------------------------------------------------
        internal void LoadTone(JXTone tone)
        {
            this.Tone = tone;
            // send all parameters
            foreach (DictionaryEntry entry in Tone.ParameterMap)
            {
                AbstractParameter parameter = (AbstractParameter)entry.Value;
                // set values to editing tone
                NotifyAutomationParameterChangeEvent(new ParameterChangeEventArgs((string)entry.Key, parameter.Value));
            }
        }

        //-------------------------------------------------------------------------------
        public void SaveTone(string sFileName)
        {
            JXToneWriter writer = new JXToneWriter();
            base.SaveTone(sFileName, writer);
            writer = null;
        }

        /// <summary>
        /// Extracts the tones from bank to a given directory.
        /// </summary>
        /// <param name="bankFilename">The bank filename.</param>
        /// <param name="directoryName">Name of the directory.</param>
        /// <returns></returns>
        public override IEnumerable<Tuple<string, AbstractTone>> ExtractSinglePatchesFromAllDataDumpFileToDirectory(string bankFilename, string directoryName)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}