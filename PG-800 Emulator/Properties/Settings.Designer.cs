﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MidiApp.GB800.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SynthOutputDeviceName {
            get {
                return ((string)(this["SynthOutputDeviceName"]));
            }
            set {
                this["SynthOutputDeviceName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AutomationInputDeviceName {
            get {
                return ((string)(this["AutomationInputDeviceName"]));
            }
            set {
                this["AutomationInputDeviceName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public int SysexTransmitDelay {
            get {
                return ((int)(this["SysexTransmitDelay"]));
            }
            set {
                this["SysexTransmitDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>DCO1 Range;128</string>\r\n  <string>DCO1 Wave;128</string>\r\n  <string>DCO1 " +
            "Tune;128</string>\r\n  <string>DCO1 LFO;128</string>\r\n  <string>DCO1 Env;128</stri" +
            "ng>\r\n  <string>DCO2 Range;128</string>\r\n  <string>DCO2 Wave;128</string>\r\n  <str" +
            "ing>DCO XMOD;128</string>\r\n  <string>DCO2 Tune;128</string>\r\n  <string>DCO2 Fine" +
            " Tune;128</string>\r\n  <string>DCO2 LFO;128</string>\r\n  <string>DCO2 Env;128</str" +
            "ing>\r\n  <string>DCO Dynamics;128</string>\r\n  <string>DCO Env Mode;128</string>\r\n" +
            "  <string>Mixer DCO1 Level;128</string>\r\n  <string>Mixer DCO2 Level;128</string>" +
            "\r\n  <string>Mixer Env;128</string>\r\n  <string>Mixer Dynamics;128</string>\r\n  <st" +
            "ring>Mixer Env Mode;128</string>\r\n  <string>VCF HPF;128</string>\r\n  <string>VCF " +
            "Freq;128</string>\r\n  <string>VCF Q;128</string>\r\n  <string>VCF LFO;128</string>\r" +
            "\n  <string>VCF Env;128</string>\r\n  <string>VCF Key;128</string>\r\n  <string>VCF D" +
            "ynamics;128</string>\r\n  <string>VCF Env Mode;128</string>\r\n  <string>VCA Level;1" +
            "28</string>\r\n  <string>VCA Dynamics;128</string>\r\n  <string>VCA Chorus;128</stri" +
            "ng>\r\n  <string>LFO Wave;128</string>\r\n  <string>LFO Delay;128</string>\r\n  <strin" +
            "g>LFO Rate;128</string>\r\n  <string>EG1 Attack;128</string>\r\n  <string>EG1 Decay;" +
            "128</string>\r\n  <string>EG1 Sustain;128</string>\r\n  <string>EG1 Release;128</str" +
            "ing>\r\n  <string>EG1 Key;128</string>\r\n  <string>EG2 Attack;128</string>\r\n  <stri" +
            "ng>EG2 Decay;128</string>\r\n  <string>EG2 Sustain;128</string>\r\n  <string>EG2 Rel" +
            "ease;128</string>\r\n  <string>EG2 Key;128</string>\r\n  <string>VCA Env Mode;128</s" +
            "tring>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection AutomationTable {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["AutomationTable"]));
            }
            set {
                this["AutomationTable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SynthetizerTypeIsJX10 {
            get {
                return ((bool)(this["SynthetizerTypeIsJX10"]));
            }
            set {
                this["SynthetizerTypeIsJX10"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MIDIChannel {
            get {
                return ((int)(this["MIDIChannel"]));
            }
            set {
                this["MIDIChannel"] = value;
            }
        }
    }
}