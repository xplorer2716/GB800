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
namespace MidiApp.GB800.Model
{
    //-----------------------------------------------------------------------------------
    /// <summary>
    /// Constants for tone sysex read/write
    /// </summary>
    internal static class JXToneConstants
    {
        // synth type values
        internal enum EnumSynthetizerType
        {
            JX10_MKS70 = 0x24,
            JX8P = 0x21
        }

        // tone sysex type
        internal enum EnumToneSysexType
        {
            UNKNOWN = -1,
            ALL_TONE_PARAMETER,
            BULK_DUMP
        }

        /// <summary>
        /// The first bytes used to identify the sysex
        /// </summary>
        internal const int TONE_INTRO_LENGTH = 7;

        // channel number position
        internal const int CHANNEL_NUMBER_POSITION = 3;

        // synthetizer type position, starting at the beginning of the sysex
        internal const int SYNTHETIZER_TYPE_POSITION = 4;

        // patch/tone toggle
        internal const int SYSEX_IS_TONE_POSITION = 5;

        internal const byte SYSEX_IS_TONE_VALUE = 0x20;
        internal const byte DEFAULT_PATCH_GROUP = 0x01; // tone "A"
        internal const byte DEFAULT_CHANNEL_NUMBER = 0x00; // #1

        /// <summary>
        /// number of bytes to read before the 59 data bytes, for APR
        /// </summary>
        internal const int ALL_TONE_PARAMETER_SYSEX_METADATA_LENGTH = 4;

        /// <summary>
        /// number of bytes to read before the 59 data bytes, for BULK DUMP (same as APR + prog + tone number)
        /// </summary>
        internal const int BULK_DUMP_TONE_SYSEX_METADATA_LENGTH = 6;

        /// <summary>
        /// returns sysex data full lentgth depending on tone sysex type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static int ToneSysexDataFullLength(EnumToneSysexType type)
        {
            int length = -1;
            switch (type)
            {
                case EnumToneSysexType.BULK_DUMP:
                    length = TONE_INTRO_LENGTH + 2 + FULL_TONE_DATA_LENGTH + 1;
                    break;

                case EnumToneSysexType.ALL_TONE_PARAMETER:
                    length = TONE_INTRO_LENGTH + FULL_TONE_DATA_LENGTH + 1;
                    break;
            }
            return length;
        }

        internal static int ToneNamePosition(EnumToneSysexType type)
        {
            int position = -1;
            switch (type)
            {
                case EnumToneSysexType.BULK_DUMP:
                    position = TONE_INTRO_LENGTH + 2;
                    break;

                case EnumToneSysexType.ALL_TONE_PARAMETER:
                    position = TONE_INTRO_LENGTH;
                    break;
            }
            return position;
        }

        /// <summary>
        /// name + tone data
        /// </summary>
        internal const int FULL_TONE_DATA_LENGTH = 59;

        /// <summary>
        /// length of the name data
        /// </summary>
        internal const int TONE_NAME_LENGTH = 10;

        /// <summary>
        /// length of usefull tone data after tone name
        /// </summary>
        internal const int TONE_DATA_LENGTH = FULL_TONE_DATA_LENGTH - TONE_NAME_LENGTH - 1;

        /// <summary>
        /// Return the undefined bytes positions depending of sysex type
        /// </summary>
        internal static byte[] UndefinedBytesPositions(EnumToneSysexType type)
        {
            byte[] positions = null;
            switch (type)
            {
                case EnumToneSysexType.BULK_DUMP:
                    positions = BULK_DUMP_TONE_UNDEF_BYTES_POSITIONS;
                    break;

                case EnumToneSysexType.ALL_TONE_PARAMETER:
                    positions = ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS;
                    break;
            }
            return positions;
        }

        /// <summary>
        /// undefined bytes positions for an all tone param sysex
        /// </summary>
        internal static readonly byte[] ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS = new byte[5] {
            TONE_INTRO_LENGTH +TONE_NAME_LENGTH,
            TONE_INTRO_LENGTH +TONE_NAME_LENGTH +13,
            TONE_INTRO_LENGTH +TONE_NAME_LENGTH +14 ,
            TONE_INTRO_LENGTH +TONE_NAME_LENGTH +15,
            TONE_INTRO_LENGTH +TONE_NAME_LENGTH +47
        };

        /// <summary>
        /// undefined bytes positions for a bulk dump sysex
        /// </summary>
        internal static readonly byte[] BULK_DUMP_TONE_UNDEF_BYTES_POSITIONS = new byte[5] {
            (byte)(ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[0]+2),
            (byte)(ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[1]+2),
            (byte)(ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[2]+2),
            (byte)(ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[3]+2),
            (byte)(ALL_TONE_PARAM_UNDEF_BYTES_POSITIONS[4]+2),
        };

        //internal readonly static byte[] ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES = new byte[5] { 0x20, 0x7F, 0x7F, 0x7F, 0x7F };
        //TODO PS - voir pourquoi ces valeurs avait été choisies
        internal static readonly byte[] ALL_TONE_PARAM_UNDEF_BYTES_DEFAULT_VALUES = new byte[5] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

        internal static readonly byte[] ALL_TONE_PARAM_INTRO = new byte[TONE_INTRO_LENGTH] { 0xF0, 0x41, 0x35, DEFAULT_CHANNEL_NUMBER, (byte)EnumSynthetizerType.JX10_MKS70, SYSEX_IS_TONE_VALUE, DEFAULT_PATCH_GROUP };
        internal static readonly byte[] BULK_DUMP_TONE_INTRO = new byte[TONE_INTRO_LENGTH] { 0xF0, 0x41, 0x37, DEFAULT_CHANNEL_NUMBER, (byte)EnumSynthetizerType.JX10_MKS70, SYSEX_IS_TONE_VALUE, DEFAULT_PATCH_GROUP };
    }
}