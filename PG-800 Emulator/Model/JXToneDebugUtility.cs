/*
Xplorer - A real-time editor for the Oberheim Xpander and Matrix-12 synths
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

namespace MidiApp.GB800.Model
{
    /// <summary>
    /// Helper class for debugging stuff
    /// </summary>
    internal class JXToneDebugUtility
    {
        /// <summary>
        /// a debug tone with "readable" values
        /// </summary>
        private static JXTone _DebugTone = null;

        internal static JXTone DebugTone
        {
            get { return JXToneDebugUtility._DebugTone; }
        }

        static JXToneDebugUtility()
        {
            //_DebugTone = new JXTone();
            //_DebugTone.ToneName = "ABCDEFGHIJ";
            //for (int i = 0; i < _DebugTone.ParameterMap.Count; i++)
            //{
            //    SysExMessage Message = (SysExMessage)_DebugTone.ParameterMap[i];
            //    Message[JXParameter.SYSEX_VALUE_INDEX] = (byte)i;
            //}
        }

        private JXToneDebugUtility()
        {
        }

        /// <summary>
        /// trace the tone data to System.Diagnostics.Trace
        /// </summary>
        /// <param name="TheTone"></param>
        internal static void TraceTone(JXTone TheTone)
        {
            System.Diagnostics.Trace.WriteLine("----------------------------");
            System.Diagnostics.Trace.WriteLine("Name: {0}", TheTone.ToneName);

            string[] TheKeys = new string[TheTone.ParameterMap.Keys.Count];
            TheTone.ParameterMap.Keys.CopyTo(TheKeys, 0);

            for (int i = 0; i < TheTone.ParameterMap.Count; i++)
            {
                AbstractParameter parameter = (AbstractParameter)TheTone.ParameterMap[i];
                System.Diagnostics.Trace.WriteLine(parameter.ToString());
            }
        }
    }
}