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
using MidiApp.UIControls;
using Sanford.Multimedia.Midi;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

namespace MidiApp.GB800.View
{
    public partial class SettingsForm : Form
    {
        // automation devices are optional. use this name to indicate no use
        public const string DEVICE_NONE = "None";

        private string _sSynthOutputDeviceName;

        public string SynthOutputDeviceName
        {
            get { return _sSynthOutputDeviceName; }
            set { _sSynthOutputDeviceName = value; }
        }

        private string _sAutomationInputDeviceName;

        public string AutomationInputDeviceName
        {
            get { return _sAutomationInputDeviceName; }
            set { _sAutomationInputDeviceName = value; }
        }

        private string _sAutomationOutputDeviceName;

        public string AutomationOutputDeviceName
        {
            get { return _sAutomationOutputDeviceName; }
            set { _sAutomationOutputDeviceName = value; }
        }

        private int _SysExTransmitDelay = 0;

        /// <summary>
        /// delay between sysex send
        /// </summary>
        public int SysExTransmitDelay
        {
            get { return _SysExTransmitDelay; }
            set { _SysExTransmitDelay = value; }
        }

        private int _MIDIChannel = 1;

        public int MIDIChannel
        {
            get { return _MIDIChannel; }
            set { _MIDIChannel = value; }
        }

        /// <summary>
        /// get or set the synthezizer type
        /// </summary>
        public bool SynthetizerTypeIsJX10
        {
            get
            {
                return rdSynthTypeJX10.Checked == true;
            }
            set
            {
                rdSynthTypeJX10.Checked = value;
                rdSynthTypeJX8P.Checked = !value;
            }
        }

        /// <summary>
        /// default devive ID values
        /// </summary>
        private int _SynthOutputDeviceID = -1;

        private int _AutomationInputDeviceID = -1;
        private int _AutomationOutputDeviceID = -1;

        private OrderedDictionary _AutomationTable = new OrderedDictionary();

        public OrderedDictionary AutomationTable
        {
            get
            {
                return _AutomationTable;
            }
        }

        //-------------------------------------------------------------------------------
        public SettingsForm()
        {
            InitializeComponent();

            // initialize the CC combo content
            for (int iControlChangeNumber = 0; iControlChangeNumber < ControlChangesNames.Names.Length; iControlChangeNumber++)
            {
                comboControlChange.Items.Add(GetControlChangeNameForNumber(iControlChangeNumber));
            }
            comboControlChange.SelectedIndexChanged += new EventHandler(control_SelectedValueChanged);
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Helper for showing Control change names
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        private static string GetControlChangeNameForNumber(int iNumber)
        {
            string sString = null;
            if (iNumber < 128)
            {
                sString = String.Format("{0} : {1}", iNumber.ToString(), ControlChangesNames.Names[iNumber]);
            }
            else
            {
                sString = String.Format("{0}", ControlChangesNames.Names[iNumber]);
            }
            return sString;
        }

        //-------------------------------------------------------------------------------
        protected override void OnShown(EventArgs e)
        {
            if (InputDevice.DeviceCount > 0)
            {
                AutomationInputCombobox.SelectedIndex = _AutomationInputDeviceID + 1;
            }

            if (OutputDevice.DeviceCount > 0)
            {
                SynthOutputComboBox.SelectedIndex = _SynthOutputDeviceID;
            }

            base.OnShown(e);
        }

        //-------------------------------------------------------------------------------
        private void okButton_Click(object sender, EventArgs e)
        {
            // midi ports update
            if (InputDevice.DeviceCount > 0)
            {
                AutomationInputDeviceName = AutomationInputCombobox.Text;
            }

            if (OutputDevice.DeviceCount > 0)
            {
                SynthOutputDeviceName = SynthOutputComboBox.Text;
            }

            // automation table
            foreach (ListViewItem item in LvAutomation.Items)
            {
                //update the control change number
                AutomationTable[item.Text] = (int)item.Tag;
            }

            //SysExTransmitDelay
            SysExTransmitDelay = (int)nUpDownDelay.Value;

            DialogResult = DialogResult.OK;
        }

        //-------------------------------------------------------------------------------
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //-------------------------------------------------------------------------------
        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            // Output devices
            if (OutputDevice.DeviceCount > 0)
            {
                for (int i = 0; i < OutputDevice.DeviceCount; i++)
                {
                    string name = OutputDevice.GetDeviceCapabilities(i).name;
                    SynthOutputComboBox.Items.Add(name);
                    if (name.CompareTo(_sSynthOutputDeviceName) == 0)
                    {
                        _SynthOutputDeviceID = i;
                    }
                    if (name.CompareTo(_sAutomationOutputDeviceName) == 0)
                    {
                        _AutomationOutputDeviceID = i;
                    }
                }
                SynthOutputComboBox.SelectedIndex = _AutomationInputDeviceID;
            }
            //Input Device
            if (InputDevice.DeviceCount > 0)
            {
                AutomationInputCombobox.Items.Add(DEVICE_NONE);

                for (int i = 0; i < InputDevice.DeviceCount; i++)
                {
                    string name = InputDevice.GetDeviceCapabilities(i).name;
                    AutomationInputCombobox.Items.Add(name);
                    if (name.CompareTo(_sAutomationInputDeviceName) == 0)
                    {
                        _AutomationInputDeviceID = i;
                    }
                }
                AutomationInputCombobox.SelectedIndex = _AutomationInputDeviceID + 1;
            }

            // Initialize the Automation Table
            foreach (DictionaryEntry entry in AutomationTable)
            {
                ListViewItem item = LvAutomation.Items.Add((string)entry.Key);
                item.Tag = (entry.Value); // tag is control change number
                item.SubItems.Add(GetControlChangeNameForNumber((int)entry.Value));
            }

            nUpDownDelay.Value = SysExTransmitDelay;
        }

        //-------------------------------------------------------------------------------
        // listview extension
        private void LvAutomation_SubItemClicked(object sender, SubItemEventArgs e)
        {
            // avoid editing of paramter name
            if (e.SubItem == 0) return;

            if (LvAutomation.SelectedItems.Count != 0)
            {
                comboControlChange.SelectedIndex = (int)LvAutomation.SelectedItems[0].Tag;
            }
            else
            {
                comboControlChange.SelectedIndex = 1;
            }
            LvAutomation.StartEditing(comboControlChange, e.Item, e.SubItem);
        }

        //-------------------------------------------------------------------------------
        // listview extension
        private void control_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (LvAutomation.SelectedItems.Count != 0)
            {
                ListViewItem item = LvAutomation.SelectedItems[0];
                // use index as CC number
                item.Tag = comboControlChange.SelectedIndex;
            }
            LvAutomation.EndEditing(true);
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// quick and dirty export of the automation table as html file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportAsTextFileToolStripMenuIte_Click(object sender, EventArgs e)
        {
            const string HTML_FILE_FILTER = "HTML files (*.htm)|*.htm";
            SaveFileDialog HtmtExportDialog = new SaveFileDialog();

            HtmtExportDialog.Filter = HTML_FILE_FILTER;
            HtmtExportDialog.RestoreDirectory = true;

            if (HtmtExportDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(HtmtExportDialog.FileName, false);
                    sw.WriteLine(

"<html><meta http-equiv=\"Content-" +
"Type\" content=\"text/html; charset=iso-8859-1\">\r\n<style type=\"text/css\"><!--body {" +
"font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 8pt}a {  font-" +
"family: Verdana, Arial, Helvetica, sans-serif; font-size: 8pt}td {  font-family:" +
"Verdana, Arial, Helvetica, sans-serif; font-size: 8pt}tr {  valign: top; align:" +
"left}--></style></head>" +
"\r\n<body><p><b>GB-800 PARAMETER MAP</b></p><table border=\"1\" cellspacing=\"1\" cellpadding=\"3\"><tr><td><b>Parameter</b></td><td><b>Control change number</b></td></tr>");

                    foreach (ListViewItem item in LvAutomation.Items)
                    {
                        //TODO PS: on devrait plutot exporter la listview que la table
                        sw.WriteLine(String.Format("<tr><td>{0}</td><td>{1}</td></tr>", item.Text, item.SubItems[1].Text));
                    }
                    sw.WriteLine("</table></body></html>");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sw != null) { sw.Close(); }
                }
            }//if
        }
    }
}