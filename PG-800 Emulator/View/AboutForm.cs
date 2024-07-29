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
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MidiApp.GB800.View
{
    /// <summary>
    /// The about box
    /// </summary>
    internal partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.labelIntro.Parent = this.logoPictureBox;
            this.labelIntro.BackColor = Color.Transparent;
            this.labelIntro.Text = AssemblyProduct;
            this.labelIntro.Text += "\r\n\r\n" + AssemblyDescription;
            this.labelIntro.Text += "\r\nfor Roland JX-10/MKS-70/JX8-P";
            this.labelIntro.Text += "\r\nVersion " + AssemblyVersion;
            this.labelIntro.Text += "\r\n" + AssemblyCopyright;

            this.lbDescription.Text =
                "\r\nThis software is DONATIONWARE. This means that you are " +
                "kindly asked to send some money to the author if you use it. " +
                "\r\nPlease go to the author website and click the Paypal donation icon to make a donation of your choice.";
        }

        #region Accesseurs d'attribut de l'assembly

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion Accesseurs d'attribut de l'assembly

        /// <summary>
        /// Go to website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkGB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.linkGB.Text);
            }
            catch (System.ComponentModel.Win32Exception noBrowserException)
            {
                if (noBrowserException.ErrorCode == -2147467259)
                {
                    MessageBox.Show(noBrowserException.Message);
                }
            }
            catch (System.Exception otherException)
            {
                MessageBox.Show(otherException.Message);
            }
        }

        private void AboutFor_Load(object sender, EventArgs e)
        {
        }
    }
}