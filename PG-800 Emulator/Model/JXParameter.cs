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
using Sanford.Multimedia.Midi;
using System;

namespace MidiApp.GB800.Model
{
    /// <summary>
    /// a Roland JX-10 Parameter
    /// </summary>
    internal class JXParameter : AbstractParameter
    {
        private object _JXLockObject = new object();

        /// <summary>
        /// Index in Sysex Message where the _value is
        /// </summary>
        public const int SYSEX_VALUE_INDEX = 8;

        /// <summary>
        /// Length of Sysex (all the same)
        /// </summary>
        private const int SYSEX_MESSAGE_LENGTH = 10;

        //-------------------------------------------------------------------------------
        private SysExMessage _SysexMessage;

        public override SysExMessage Message
        {
            get
            {
                lock (_JXLockObject)
                {
                    return _SysexMessage;
                }
            }
            set
            {
                lock (_JXLockObject)
                {
                    if (value == null)
                    {
                        throw new NullReferenceException("SysExMessage can not be null");
                    }
                    _SysexMessage = value;
                }
            }
        }

        protected override void UpdateMessageFromValue()
        {
            _SysexMessage[SYSEX_VALUE_INDEX] = (byte)Value;
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// _value override; set the _value in the sysex message when setting the _value
        /// </summary>
        public override int Value
        {
            get
            {
                lock (_JXLockObject)
                {
                    return base.Value;
                }
            }
            set
            {
                // do not use base lock object since we'll get a race condition
                lock (_JXLockObject)
                {
                    if (value > byte.MaxValue)
                    {
                        throw new OverflowException(String.Format("_value can not be greater than {0}", byte.MaxValue));
                    }
                    base.Value = value;
                }
            }
        }

        //-------------------------------------------------------------------------------
        public JXParameter(string name, int minValue, int maxValue, int step, SysExMessage message, int value)
            : base(name, minValue, maxValue, step, message, value)
        {
        }

        #region ICloneable Membres

        //-------------------------------------------------------------------------------
        protected JXParameter(JXParameter param)
            : base(param)
        {
            // clone of Message is already done by AbstractParameter, no additional data member cloning here
        }

        public override object Clone()
        {
            return new JXParameter(this);
        }

        #endregion ICloneable Membres
    }
}