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
//using System.IO;
//using System.Threading;
//using System.Collections;
//using System.Collections.Generic;

//using Sanford.Multimedia;
//using Sanford.Multimedia.Midi;
//using Baumont.GB800.Model;
//using System;


//namespace Baumont.GB800.Controller
//{
//    /// <summary>
//    /// this implementation samples each m_SysExTransmitDelay the values and send them to send. result
//    /// is inaccurate in values (we miss some of them) but accurate in time
//    /// </summary>
//    partial class GB800Controller
//    {
//        /// <summary>
//        /// The sysex message queue. Message have to be queued since
//        /// we are not sending them in real time (transmit delay).
//        /// see ctor for init
//        /// </summary>
//        private object m_EntryLockObject = new object();
//        private DictionaryEntry m_LastSysExEntryToSend = new DictionaryEntry("",null);

//        // the worker thread for dequeuing messages
//        private Thread m_SysExWorkerThread = null;

//        /// <summary>
//        /// starts the dequeuing worker thread
//        /// </summary>
//        private void StartSysExWorkerThread()
//        {
//            m_SysExWorkerThread.Start();
//        }
//        //-----------------------------------------------------------------------
//        /// <summary>
//        /// starts the dequeuing worker thread
//        /// </summary>
//        private void StopSysExWorkerThread()
//        {
//            m_SysExWorkerThread.Abort();
//        }

//        //-----------------------------------------------------------------------
//        private void SysExWorkerThreadProc()
//        {
//            try
//            {
//                while (true)
//                {
//                    //wait for transmission delay to elapse
//                    //TODO : optimiser en faisant un vrai decompte
//                    Thread.Sleep(this.m_SysExTransmitDelay);


//                    if (DequeueSysExEntry(out m_LastSysExEntryToSend))
//                    {
//                        // check for changes
//                        if (m_LastSysExEntryToSend.Value == null)
//                        {
//                            continue;
//                        }

//                        SysExMessage Message = (SysExMessage)m_LastSysExEntryToSend.Value;

//                        //TODO à supprimer
//                        DateTime now = DateTime.Now;
//                        System.Diagnostics.Debug.WriteLine(String.Format("{0} {1}ms [SysExWorkerThreadProc] sendinf {2}:{3}", now.ToLongTimeString(), now.Millisecond,
//                            (string)m_LastSysExEntryToSend.Key,
//                            Message.ToString()));
//                        //

//                        // send the message
//                        SendSysSexMessageToSynth(Message);

//                        // sets the tone message value to the sent value
//                        ((SysExMessage)m_Tone.ParameterMap[(string)m_LastSysExEntryToSend.Key])[JXParameter.SYSEX_VALUE_INDEX] = Message[JXParameter.SYSEX_VALUE_INDEX];

//                        // feedback to automation output
//                        int ControlChangeNumber = m_ControlChangeAutomationTable[(string)m_LastSysExEntryToSend.Key];
//                        if (ControlChangeNumber != int.MaxValue)
//                        {
//                            SendControlChangeMessageToAutomationOutput(ControlChangeNumber, Message[JXParameter.SYSEX_VALUE_INDEX]);
//                        }

//                        m_LastSysExEntryToSend.Value = null;
//                    } //entry!=null
//                } // while

//            }//try
//            catch (ThreadAbortException e)
//            {
                
//            }
//        }
//        //-----------------------------------------------------------------------
//        /// <summary>
//        /// returns the next message to send or null if none available
//        /// </summary>
//        /// <returns></returns>
//        private bool DequeueSysExEntry(out DictionaryEntry entry)
//        {
//            lock (m_EntryLockObject)
//            {
//                entry=m_LastSysExEntryToSend;
//                return true;
//            }
//        }
//        //-----------------------------------------------------------------------
//        private void EnQueueSysExEntry(DictionaryEntry entry)
//        {
//            lock (m_EntryLockObject)
//            {
//                m_LastSysExEntryToSend = entry;
//            }
//        }


//    }
//}
