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
using System.Collections.Specialized;
using System.Text;

namespace MidiApp.GB800.Model
{
    /// <summary>
    /// a Tone
    /// </summary>
    internal class JXTone : AbstractTone
    {
        // the parameters names

        #region PARAMETER_NAMES

        public static readonly string[] PARAMETERS_NAMES ={
                            "DCO1 Range",
                            "DCO1 Wave",
                            "DCO1 Tune",
                            "DCO1 LFO",
                            "DCO1 Env",

                            "DCO2 Range",
                            "DCO2 Wave",
                            "DCO XMOD",

                            "DCO2 Tune",
                            "DCO2 Fine Tune",
                            "DCO2 LFO",
                            "DCO2 Env",
                            "DCO Dynamics",
                            "DCO Env Mode",

                            "Mixer DCO1 Level",
                            "Mixer DCO2 Level",
                            "Mixer Env",
                            "Mixer Dynamics",
                            "Mixer Env Mode",

                            "VCF HPF",
                            "VCF Freq",
                            "VCF Q",
                            "VCF LFO",
                            "VCF Env",
                            "VCF Key",
                            "VCF Dynamics",
                            "VCF Env Mode",

                            "VCA Level",
                            "VCA Dynamics",
                            "VCA Chorus",

                            "LFO Wave",
                            "LFO Delay",
                            "LFO Rate",

                            "EG1 Attack",
                            "EG1 Decay",
                            "EG1 Sustain",
                            "EG1 Release",
                            "EG1 Key",

                            "EG2 Attack",
                            "EG2 Decay",
                            "EG2 Sustain",
                            "EG2 Release",
                            "EG2 Key",
                            "VCA Env Mode"
         };

        #endregion PARAMETER_NAMES

        /// <summary>
        /// Sysex message map. Key is parameter name, _value is Sysex byte data
        /// </summary>
        ///
        private OrderedDictionary _ParameterMap = null;

        public override OrderedDictionary ParameterMap
        { get { return _ParameterMap; } }

        //----------------------------------------------------------------------------
        private string _sToneName = null;

        /// <summary>
        /// returns/set thee name of the tone. Length is fixed/padded to ToneConstants.TONE_NAME_LENGTH
        /// </summary>
        public override string ToneName
        {
            get { return _sToneName; }
            set
            {
                if (value.Length > JXToneConstants.TONE_NAME_LENGTH)
                {
                    _sToneName = value.Substring(0, JXToneConstants.TONE_NAME_LENGTH);
                }
                else
                {
                    _sToneName = value;
                    _sToneName = _sToneName.PadRight(JXToneConstants.TONE_NAME_LENGTH, ' ');
                }
            }
        }

        //----------------------------------------------------------------------------
        public JXTone()
        {
            _sToneName = string.Empty;
            InitializeParameterMap();
        }

        //----------------------------------------------------------------------------
        internal bool SynthetizerTypeIsJX10
        {
            get
            {
                // get this info from the first parameter
                JXParameter param = (JXParameter)_ParameterMap[0];
                return (param.Message[JXToneConstants.SYNTHETIZER_TYPE_POSITION] == (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70);
            }
            set
            {
                byte bSynthetizerType = 0;
                if (value == true)
                {
                    bSynthetizerType = (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70;
                }
                else
                {
                    bSynthetizerType = (byte)JXToneConstants.EnumSynthetizerType.JX8P;
                }

                // update the parameters
                foreach (JXParameter param in _ParameterMap.Values)
                {
                    param.Message[JXToneConstants.SYNTHETIZER_TYPE_POSITION] = bSynthetizerType;
                }

                //
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Initialize the sysex message map. sysex are ordered as in a APR message
        /// </summary>
        protected override void InitializeParameterMap()
        {
            //TODO PS a valider (les et intervalles ont été changées)

            _ParameterMap = new OrderedDictionary();

            //TODO redefinir les min, max et step
            _ParameterMap.Add("DCO1 Range", new JXParameter("DCO1 Range", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x0B, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO1 Wave", new JXParameter("DCO1 Wave", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x0C, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO1 Tune", new JXParameter("DCO1 Tune", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x0D, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO1 LFO", new JXParameter("DCO1 LFO", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x0E, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO1 Env", new JXParameter("DCO1 Env", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x0F, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("DCO2 Range", new JXParameter("DCO2 Range", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x10, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO2 Wave", new JXParameter("DCO2 Wave", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x11, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO XMOD", new JXParameter("DCO2 XMOD", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x12, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("DCO2 Tune", new JXParameter("DCO2 Tune", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x13, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO2 Fine Tune", new JXParameter("DCO2 Fine Tune", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x14, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO2 LFO", new JXParameter("DCO2 LFO", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x15, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO2 Env", new JXParameter("DCO2 Env", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x16, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO Dynamics", new JXParameter("DCO Dynamics", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x1A, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("DCO Env Mode", new JXParameter("Env Mode", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x1B, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("Mixer DCO1 Level", new JXParameter("Mixer DCO1 Level", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x1C, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("Mixer DCO2 Level", new JXParameter("Mixer DCO2 Level", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x1D, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("Mixer Env", new JXParameter("Mixer Env", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x1E, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("Mixer Dynamics", new JXParameter("Mixer Dynamics", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x1F, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("Mixer Env Mode", new JXParameter("Mixer Env Mode", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x20, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("VCF HPF", new JXParameter("VCF HPF", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x21, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF Freq", new JXParameter("VCF Freq", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x22, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF Q", new JXParameter("VCF Q", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x23, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF LFO", new JXParameter("VCF LFO", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x24, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF Env", new JXParameter("VCF Env", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x25, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF Key", new JXParameter("VCF Key", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x26, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF Dynamics", new JXParameter("VCF Dynamics", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x27, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCF Env Mode", new JXParameter("VCF Env Mode", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x28, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("VCA Level", new JXParameter("VCA Level", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x29, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("VCA Dynamics", new JXParameter("VCA Dynamics", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x2A, 0x00, 0xF7 }), 0));
            // for chorus sysex implementation says 0-31/32-63/64-127, so define it as if i has 4 step, even if the last will not be used
            _ParameterMap.Add("VCA Chorus", new JXParameter("VCA Chorus", 0, 64, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x2B, 0x00, 0xF7 }), 0));
            // same as for chorus
            _ParameterMap.Add("LFO Wave", new JXParameter("LFO Wave", 0, 64, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x2C, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("LFO Delay", new JXParameter("LFO Delay", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x2D, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("LFO Rate", new JXParameter("LFO Rate", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x2E, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("EG1 Attack", new JXParameter("EG1 Attack", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x2F, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG1 Decay", new JXParameter("EG1 Decay", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x30, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG1 Sustain", new JXParameter("EG1 Sustain", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x31, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG1 Release", new JXParameter("EG1 Release", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x32, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG1 Key", new JXParameter("EG1 Key", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x33, 0x00, 0xF7 }), 0));

            _ParameterMap.Add("EG2 Attack", new JXParameter("EG2 Attack", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x34, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG2 Decay", new JXParameter("EG2 Decay", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x35, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG2 Sustain", new JXParameter("EG2 Sustain", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x36, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG2 Release", new JXParameter("EG2 Release", 0, 127, 1, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x37, 0x00, 0xF7 }), 0));
            _ParameterMap.Add("EG2 Key", new JXParameter("EG2 Key", 0, 96, 32, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x38, 0x00, 0xF7 }), 0));
            //TODO PS: c'est le seul ou le step vaut la valeur, tester si cela passe
            _ParameterMap.Add("VCA Env Mode", new JXParameter("VCA Env Mode", 0, 64, 64, new SysExMessage(new byte[] { 0xF0, 0x41, 0x36, 0x00, (byte)JXToneConstants.EnumSynthetizerType.JX10_MKS70, 0x20, 0x01, 0x3A, 0x00, 0xF7 }), 0));
        }

        //-----------------------------------------
        /// <summary>
        /// surcharge pour debug
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ToneName: {0}\r\nMIDIChannel: {1}\r\n",
                ToneName,
                MIDIChannel);
            sb.Append(DumpParameterMap());
            return sb.ToString();
        }
    }
}