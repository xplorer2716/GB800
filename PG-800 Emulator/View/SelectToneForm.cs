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
using MidiApp.GB800.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MidiApp.GB800.View
{
    /// <summary>
    /// A form to select a tone in a bank
    /// </summary>
    internal partial class SelectToneForm : Form
    {
        internal delegate void ToneSelectedEventHandler(object sender, JXTone tone);

        // tone selectedEvent
        internal event ToneSelectedEventHandler ToneSelectedEvent;

        /// <summary>
        /// Tone filename
        /// </summary>
        internal string ToneFilename { get; set; }

        /// <summary>
        /// returns the selected item
        /// </summary>
        internal JXTone SelectedTone
        {
            get
            {
                if (_toneListView.Items.Count > 0)
                {
                    return (JXTone)_toneListView.SelectedItems[0].Tag;
                }
                else return null;
            }
        }

        /// <summary>
        /// for design purpose only
        /// </summary>
        public SelectToneForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// _value ctor
        /// </summary>
        /// <param name="list">list of tones</param>
        internal SelectToneForm(IList<JXTone> list)
        {
            InitializeComponent();
            foreach (JXTone tone in list)
            {
                ListViewItem item = new ListViewItem(tone.ToneName);
                item.ImageIndex = 1;
                item.Tag = tone;
                _toneListView.Items.Add(item);
            }
            if (list.Count > 0)
            {
                _toneListView.Items[0].Selected = true;
            }
        }

        private void _toneListView_DoubleClick(object sender, EventArgs e)
        {
            if (ToneSelectedEvent != null)
            {
                ToneSelectedEvent(this, SelectedTone);
            }
        }
    }
}