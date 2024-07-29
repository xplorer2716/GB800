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
using MidiApp.GB800.Controller;
using MidiApp.MidiController.Controller;
using MidiApp.MidiController.Model;
using MidiApp.MidiController.View;
using System;
using System.Windows.Forms;

namespace MidiApp.GB800.View
{
    /// <summary>
    /// The main application form
    /// </summary>
    public partial class MainForm : AbstractControllerMainForm
    {
        //piano control form
        private PianoControlForm _PianoControlForm = null;

        //-------------------------------------------------------------------------------
        public MainForm()
            : base()
        {
            InitializeComponent();
            // piano control form
            _PianoControlForm = new PianoControlForm(Controller, System.Drawing.Color.Orange);
        }

        //-------------------------------------------------------------------------------

        protected override void OnLoad(EventArgs e)
        {
            LoadSettings();
            base.OnLoad(e);
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// //intialize the controller with settings values
        /// </summary>
        /// <returns></returns>
        private bool LoadSettings()
        {
            GB800Controller controler = (GB800Controller)Controller;
            //TODO PS: arreter le thread sur settings ? à l'init, vérifier si plusieurs demarrages ou non (abstract)
            try
            {
                controler.SetAutomationInputDevice(Properties.Settings.Default.AutomationInputDeviceName);
                controler.SetSynthInputDevice(string.Empty);
                controler.SetSynthOutputDevice(Properties.Settings.Default.SynthOutputDeviceName);
                controler.ParameterTransmitDelay = Properties.Settings.Default.SysexTransmitDelay;
                // MIDI channel is 0 based
                controler.SetMIDIChannel(Properties.Settings.Default.MIDIChannel);

                controler.ControlChangeAutomationTable.Clear();

                foreach (String entry in Properties.Settings.Default.AutomationTable)
                {
                    // entries are semicolon separated
                    int Delimiter = entry.LastIndexOf(';');
                    string sParameterName = entry.Substring(0, Delimiter);
                    string sControlChangeNumber = entry.Substring(Delimiter + 1, entry.Length - Delimiter - 1);
                    int iControlChangeNumber;
                    if (int.TryParse(sControlChangeNumber, out iControlChangeNumber))
                    {
                        if (iControlChangeNumber < 1) iControlChangeNumber = 1;
                        if (iControlChangeNumber > 128) iControlChangeNumber = 128;
                        controler.ControlChangeAutomationTable.Add(new StringIntDualEntry(sParameterName, iControlChangeNumber));
                    }
                }
                return true;
            }
            // TODO PS: typer l'exception + gerer les erreurs(retour ou exception)
            catch (Exception e)
            {
                MessageBox.Show("Wrong settings parameters. Please update the settings", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        //-------------------------------------------------------------------------------

        #region BASE_CLASS_IMPLEMENTATION

        private GB800Controller _Controller = null;

        protected override AbstractController Controller
        {
            get
            {
                if (_Controller == null)
                {
                    _Controller = new GB800Controller();
                }
                return _Controller;
            }
        }

        #endregion BASE_CLASS_IMPLEMENTATION

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Override because of the old implementation of Trackbar
        /// </summary>
        /// <param name="control"></param>
        protected override void RecursiveRegisterValuedUserControl(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (subControl.Controls.Count != 0)
                {
                    RecursiveRegisterValuedUserControl(subControl);
                }
            }
            // register only ValuedUserControl
            MidiApp.UIControls.BlueTrackBar current = control as MidiApp.UIControls.BlueTrackBar;
            if (current != null)
            {
                RegisteredControlsMap.Add((string)current.Tag, current);

                // get the parameter values from controller (ok, we use the model layer...)
                AbstractParameter param = Controller.GetParameter((string)current.Tag);
                if (param != null)
                {
                    // min/max exhange due to this fuckin trackbar impl...
                    if (current.Orientation == MidiApp.UIControls.BlueTrackBar.TrackBarOrientation.Horizontal)
                    {
                        current.Minimum = param.MinValue;
                        current.Maximum = param.MaxValue;
                    }
                    else
                    {
                        current.Minimum = param.MaxValue;
                        current.Maximum = param.MinValue;
                    }
                    current.Step = param.Step;
                    current.Value = param.Value;
                }
            }
        }
    }
}