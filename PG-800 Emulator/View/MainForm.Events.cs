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
using MidiApp.GB800.Controller;
using MidiApp.GB800.Model;
using MidiApp.MidiController.Controller;
using MidiApp.MidiController.Controller.Arguments;
using MidiApp.MidiController.Service;
using MidiApp.MidiController.View;
using MidiApp.UIControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MidiApp.GB800.View
{
    /// <summary>
    /// The main application form
    /// </summary>
    public partial class MainForm : AbstractControllerMainForm
    {
        /// <summary>
        /// tone selection form
        /// </summary>
        private SelectToneForm _selectForm;

        private enum EnumSysExFileType
        {
            SYSEX_FILETYPE_UNKNOWN,
            SYSEX_FILETYPE_TONE,
            SYSEX_FILETYPE_BANK
        }

        // type of sysex file that was last opened
        private EnumSysExFileType _SysExFileType = EnumSysExFileType.SYSEX_FILETYPE_UNKNOWN;

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Load a tone file sysex and update the GUI with loaded data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLoadTone_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSysexFileDialog = new OpenFileDialog();

            openSysexFileDialog.Filter = FileUtils.SYSEX_FILE_FILTER;
            openSysexFileDialog.RestoreDirectory = true;

            if (openSysexFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GB800Controller controler = ((GB800Controller)Controller);
                    // read the tone sysex and fill the map with the parameters values
                    List<JXTone> list = controler.LoadTones(openSysexFileDialog.FileName);
                    if (list == null)
                    {
                        throw new Exception(string.Format("Unable to find sysex data from file: {0}", openSysexFileDialog.FileName));
                    }
                    // a single tone was found
                    if (list.Count == 1)
                    {
                        if (_selectForm != null) _selectForm.Hide();
                        controler.LoadTone(list[0]);
                        // store the file name for save function
                        this.ToneFileName = openSysexFileDialog.FileName;
                        _SysExFileType = EnumSysExFileType.SYSEX_FILETYPE_TONE;
                    }
                    // several tone are found - let the user select one
                    else
                    {
                        if (_selectForm == null)
                        {
                            _selectForm = new SelectToneForm(list);
                            _selectForm.ToneSelectedEvent += new SelectToneForm.ToneSelectedEventHandler(_selectFor_ToneSelectedEvent);
                            // left align the form
                            _selectForm.Height = this.Height;
                            _selectForm.Top = this.Top;
                            int leftPosition = (this.Left - _selectForm.Width);
                            if (leftPosition > 0)
                            {
                                _selectForm.Left = leftPosition;
                            }
                        }
                        //TODO PS: erreur ici, on ne passe plus la liste
                        _selectForm.ToneFilename = openSysexFileDialog.FileName;
                        _selectForm.Text = Path.GetFileName(openSysexFileDialog.FileName);
                        _selectForm.Show();
                        _SysExFileType = EnumSysExFileType.SYSEX_FILETYPE_BANK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// tone selected event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tone"></param>
        private void _selectFor_ToneSelectedEvent(object sender, JXTone tone)
        {
            if (tone != null)
            {
                GB800Controller controler = ((GB800Controller)Controller);
                controler.LoadTone(tone);
                this.ToneFileName = _selectForm.ToneFilename;
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Save sysex tone file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveTone_Click(object sender, EventArgs e)
        {
            // tricky but has to be handled
            // if file is not a tone sysex, always "save as"
            if (!File.Exists(this.ToneFileName) || _SysExFileType != EnumSysExFileType.SYSEX_FILETYPE_TONE)
            {
                btSaveAs_Click(sender, e);
            }
            else
            {
                // tone sysex that already exists
                try
                {
                    DialogResult dr = MessageBox.Show(String.Format("File {0} already exists. Replace ?", this.ToneFileName), "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        ((GB800Controller)Controller).SaveTone(this.ToneFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Save sysex tone file as new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveSysexFileDialog = new SaveFileDialog();

            saveSysexFileDialog.Filter = FileUtils.SYSEX_FILE_FILTER;
            saveSysexFileDialog.RestoreDirectory = true;

            if (saveSysexFileDialog.ShowDialog() == DialogResult.OK)

                try
                {
                    ((GB800Controller)Controller).SaveTone(saveSysexFileDialog.FileName);
                    this.ToneFileName = saveSysexFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// show the settings form and update settings if needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsDialog = new SettingsForm();

            settingsDialog.SynthOutputDeviceName = Properties.Settings.Default.SynthOutputDeviceName;
            settingsDialog.AutomationInputDeviceName = Properties.Settings.Default.AutomationInputDeviceName;
            settingsDialog.SysExTransmitDelay = Properties.Settings.Default.SysexTransmitDelay;
            settingsDialog.SynthetizerTypeIsJX10 = Properties.Settings.Default.SynthetizerTypeIsJX10;
            // 0 based
            settingsDialog.MIDIChannel = Properties.Settings.Default.MIDIChannel + 1;

            foreach (StringIntDualEntry entry in Controller.ControlChangeAutomationTable)
            {
                settingsDialog.AutomationTable.Add(entry.StringValue, entry.IntValue);
            }

            if (settingsDialog.ShowDialog() == DialogResult.OK)
            {
                Application.DoEvents();
                // save the settings
                Properties.Settings.Default.SynthOutputDeviceName = settingsDialog.SynthOutputDeviceName;
                Properties.Settings.Default.AutomationInputDeviceName = settingsDialog.AutomationInputDeviceName;
                Properties.Settings.Default.SysexTransmitDelay = settingsDialog.SysExTransmitDelay;
                Properties.Settings.Default.SynthetizerTypeIsJX10 = settingsDialog.SynthetizerTypeIsJX10;
                // 0 based
                Properties.Settings.Default.MIDIChannel = settingsDialog.MIDIChannel - 1;

                //update the automation table
                Properties.Settings.Default.AutomationTable.Clear();
                foreach (DictionaryEntry entry in settingsDialog.AutomationTable)
                {
                    // controller's control change table will be refilled thru LoadSettings()
                    Properties.Settings.Default.AutomationTable.Add(String.Format("{0};{1}", (string)entry.Key, (int)entry.Value));
                }
                Properties.Settings.Default.Save();

                // simulate a settings reload
                LoadSettings();
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// About form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// show / hide the piano control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPiano_Click(object sender, EventArgs e)
        {
            if (!_PianoControlForm.Visible)
            {
                _PianoControlForm.Show(this);
            }
            else
            {
                _PianoControlForm.Hide();
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// ask the controller to generate a random tone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRandomize_Click(object sender, EventArgs e)
        {
            RandomizeToneArgument randomArgs = new RandomizeToneArgument(new HashSet<string>(new string[] { "VCA Level" }), 0.5F);
            Controller.RandomizeTone(randomArgs);
        }

        private void AnyControl_ValueChanged(object sender, EventArgs e)
        {
            //TODO PS
            // assuming here we have IValuedControl
            IValuedControl valuedControl = sender as IValuedControl;
            Control control = sender as Control;
            if (control != null && valuedControl != null)
            {
                //TODO PS - récup de la forme de XpanderMIDIControler à fixer
                base.HandleControlValueChanged(/*GetParameterNameForValuedControlTag((string)*/(string)control.Tag/*)*/, valuedControl.Value);
            } // knob!=null
        }

        private void AnyControl_MouseDown(object sender, MouseEventArgs e)
        {
            base.HandleControlMouseDown(sender, e);
        }

        private void AnyControl_MouseUp(object sender, MouseEventArgs e)
        {
            base.HandleControlMouseUp(sender, e);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (_selectForm != null)
            {
                _selectForm.ToneSelectedEvent -= new SelectToneForm.ToneSelectedEventHandler(_selectFor_ToneSelectedEvent);
                _selectForm.Close();
                _selectForm.Dispose();
            }
            base.OnClosing(e);
        }

        /// <summary>
        /// occurs when a click is done on  Tune and fine tune sliders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TuneAndFineTuneMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MidiApp.UIControls.BlueTrackBar slider = sender as BlueTrackBar;
                if (slider != null)
                {
                    slider.Value = (slider.Maximum - slider.Minimum) / 2;
                }
            }
        }

        /// <summary>
        /// Occurs when a click is done oh the GB800 Logo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            btAbout_Click(sender, e);
        }
    }
}