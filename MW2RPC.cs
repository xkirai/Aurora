using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;

namespace Aurora
{
    class MW2RPC
    {
        private static uint function_address = 0x38EDE8;
        public static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);


        public static int Call(UInt32 func_address, params object[] parameters)
        {

            int length = parameters.Length;

            int index = 0;

            UInt32 num3 = 0;

            UInt32 num4 = 0;

            UInt32 num5 = 0;

            UInt32 num6 = 0;

            while (index < length)
            {

                if (parameters[index] is int)
                {

                    PS3.Extension.WriteInt32(0x10050000 + (num3 * 4), (int)parameters[index]);
                    
                    num3++;

                }

                else if (parameters[index] is UInt32)
                {

                    PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), (UInt32)parameters[index]);

                    num3++;

                }

                else
                {

                    UInt32 num7;

                    if (parameters[index] is string)
                    {

                        num7 = 0x10052000 + (num4 * 0x400);

                        PS3.Extension.WriteString(num7, Convert.ToString(parameters[index]));

                        PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), num7);

                        num3++;

                        num4++;

                    }

                    else if (parameters[index] is float)
                    {

                        PS3.Extension.WriteFloat(0x10050024 + (num5 * 4), (float)parameters[index]);

                        num5++;

                    }

                    else if (parameters[index] is float[])
                    {

                        float[] input = (float[])parameters[index];

                        num7 = 0x10051000 + (num6 * 4);

                        PS3.Extension.WriteFloat(num7, Convert.ToSingle(input));

                        PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), num7);

                        num3++;

                        num6 += (UInt32)input.Length;

                    }

                }

                index++;

            }

            PS3.Extension.WriteUInt32(0x1005004C, func_address);

            System.Threading.Thread.Sleep(20);

            return PS3.Extension.ReadInt32(0x10050050);

        }



        public static void EnableRPC()
        {

            byte[] RPC = { 0xF8, 0x21, 0xFF, 0x91, 0x7C, 0x08, 0x02, 0xA6, 0xF8, 0x01, 0x00, 0x80, 0x3C, 0x40, 0x00, 0x72, 0x30, 0x42, 0x4C, 0x38, 0x3C, 0x60, 0x10, 0x05, 0x81, 0x83, 0x00, 0x4C, 0x2C, 0x0C, 0x00, 0x00, 0x41, 0x82, 0x00, 0x64, 0x80, 0x83, 0x00, 0x04, 0x80, 0xA3, 0x00, 0x08, 0x80, 0xC3, 0x00, 0x0C, 0x80, 0xE3, 0x00, 0x10, 0x81, 0x03, 0x00, 0x14, 0x81, 0x23, 0x00, 0x18, 0x81, 0x43, 0x00, 0x1C, 0x81, 0x63, 0x00, 0x20, 0xC0, 0x23, 0x00, 0x24, 0xC0, 0x43, 0x00, 0x28, 0xC0, 0x63, 0x00, 0x2C, 0xC0, 0x83, 0x00, 0x30, 0xC0, 0xA3, 0x00, 0x34, 0xC0, 0xC3, 0x00, 0x38, 0xC0, 0xE3, 0x00, 0x3C, 0xC1, 0x03, 0x00, 0x40, 0xC1, 0x23, 0x00, 0x48, 0x80, 0x63, 0x00, 0x00, 0x7D, 0x89, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x21, 0x3C, 0x80, 0x10, 0x05, 0x38, 0xA0, 0x00, 0x00, 0x90, 0xA4, 0x00, 0x4C, 0x90, 0x64, 0x00, 0x50, 0x3C, 0x40, 0x00, 0x73, 0x30, 0x42, 0x4B, 0xE8, 0xE8, 0x01, 0x00, 0x80, 0x7C, 0x08, 0x03, 0xA6, 0x38, 0x21, 0x00, 0x70, 0x4E, 0x80, 0x00, 0x20 };

            PS3.SetMemory(function_address, RPC);

            PS3.SetMemory(0x10050000, new byte[0x2854]);

            MW2RPC.ExecuteCommand("r_fog 1");

        }

        public static void SV_GameSendServerCommand(Int32 clientIndex, String Cmd)
        {

            Call(0x0021A0A0, clientIndex, 0, Cmd);

        }

        public static void iPrintln(Int32 clientIndex, String Txt)
        {

            SV_GameSendServerCommand(clientIndex, "f \"" + Txt + "\"");

        }

        public static void iPrintlnBold(Int32 clientIndex, String Txt)
        {

            SV_GameSendServerCommand(clientIndex, "c \"" + Txt + "\"");

        }

        public static void SetDvar(Int32 clientIndex, String Txt)
        {

            SV_GameSendServerCommand(clientIndex, "v " + Txt);

        }

        public static void iPrintlnForState(Int32 clientIndex, String OptionName, Boolean Function)//will be usefull for the coming Toggle Funcs
        {

            iPrintln(clientIndex, OptionName + ": " + (Function ? "Enabled" : "Disabled"));

        }

        public static void ExecuteCommand(string command)
        {
            object[] parameters = new object[] { 0, command };
            Call(0x001D9EC0, parameters);
        }

        public static void Cbuf_AddText(Int32 clientIndex, string cmd)
        {
            Call(0x001D9EC0, clientIndex, 0, cmd);
        }

    }
}
