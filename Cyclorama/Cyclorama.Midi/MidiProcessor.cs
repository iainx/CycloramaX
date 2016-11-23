using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using AppKit;
using CoreMidi;

namespace Cyclorama.Midi
{
    public static class MidiProcessor
    {
        public enum MessageType
        {
            Aftertouch,
            AftertouchChange,
            ControlChange,
            NoteOff,
            NoteOn,
            Other,
            PitchWheel,
            ProgramChange
        };

        static MidiClient client;
        static MidiPort inputPort;

        static MidiEndpoint endPoint;

        static Dictionary<byte, Action<byte>> messageRouter;

        static MidiProcessor ()
        {
            MidiObject endPointObject;

            MidiError error = MidiObject.FindByUniqueId (1759718006, out endPointObject);

            if (error != MidiError.Ok) {
                Console.WriteLine ($"Midi Error: {error}");
                return;
            }

            endPoint = endPointObject as MidiEndpoint;

            if (endPoint == null) {
                Console.WriteLine ("Endpoint was not MidiEndpoint");
                return;
            }

            client = new MidiClient ("Cyclorama client");
            inputPort = client.CreateInputPort ("Input port");
            inputPort.MessageReceived += ProcessMidiMessage;

            error = inputPort.ConnectSource (endPoint);

            if (error != MidiError.Ok) {
                return;
            }
        }

        static void ProcessMidiMessage (object sender, MidiPacketsEventArgs args)
        {
            foreach (var packet in args.Packets) {
                byte [] data = new byte [packet.Length];
                Marshal.Copy (packet.Bytes, data, 0, packet.Length);

                ushort idx = 0;
                while (idx < packet.Length) {
                    MessageType type = MessageType.Other;
                    byte status = data [idx];
                    ushort size;

                    if (status < 0xC0) {
                        size = 3;
                    } else if (status < 0xE0) {
                        size = 2;
                    } else if (status < 0xF0) {
                        size = 3;
                    } else if (status == 0xF0) {
                        size = (ushort) (packet.Length - idx);
                    } else if (status < 0xF3) {
                        size = 2;
                    } else {
                        size = 1;
                    }

                    byte data1 = 0;
                    byte data2 = 0;
                    int channel;

                    channel = status & 0xF;
                    switch (status & 0xF0) {
                    case 0x80:
                        type = MessageType.NoteOff;
                        data1 = data [idx + 1];
                        data2 = data [idx + 2];
                        break;

                    case 0x90:
                        HandleNote (data [idx + 1], data [idx + 2]);
                        break;

                    case 0xA0:
                        type = MessageType.Aftertouch;
                        data1 = data [idx + 1];
                        data2 = data [idx + 2];
                        break;

                    case 0xB0:
                        type = MessageType.ControlChange;
                        data1 = data [idx + 1];
                        data2 = data [idx + 2];
                        break;

                    case 0xC0:
                        type = MessageType.ProgramChange;
                        data1 = data [idx + 1];
                        data2 = 0;
                        break;

                    case 0xD0:
                        type = MessageType.AftertouchChange;
                        data1 = data [idx + 1];
                        data2 = 0;
                        break;

                    case 0xE0:
                        type = MessageType.PitchWheel;
                        data1 = data [idx + 1];
                        data2 = data [idx + 2];
                        break;

                    default:
                        break;
                    }

                    idx += size;
                }
            }
        }

        static void HandleNote (byte noteNumber, byte value)
        {
            Action<byte> handler;

            if (messageRouter.TryGetValue (noteNumber, out handler)) {

                NSApplication.SharedApplication.InvokeOnMainThread (() => handler (value));
            }
        }

        public static void AddNoteHandler (byte noteNumber, Action<byte> handler)
        {
            messageRouter [noteNumber] = handler;
        }

        public static void RemoveNoteHandler (byte noteNumber)
        {
            messageRouter.Remove (noteNumber);
        }
    }
}
