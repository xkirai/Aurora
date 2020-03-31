using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;

namespace Aurora
{
    class GhostsRPC
    {
        private static PS3API PS3 = new PS3API();


        private uint function_address = 0x00495d10;//RPC Made By Unknuawn
        public int CallFunction(uint func_address, params object[] parameters)
        {
            int length = parameters.Length;
            uint num2 = 0;
            for (uint i = 0; i < length; i++)
            {
                byte[] buffer;
                if (parameters[i] is int)
                {
                    buffer = BitConverter.GetBytes((int)parameters[i]);
                    Array.Reverse(buffer);
                    PS3.SetMemory(0x10050000 + ((i + num2) * 4), buffer);
                }
                else if (parameters[i] is uint)
                {
                    buffer = BitConverter.GetBytes((uint)parameters[i]);
                    Array.Reverse(buffer);
                    PS3.SetMemory(0x10050000 + ((i + num2) * 4), buffer);
                }
                else if (parameters[i] is string)
                {
                    byte[] buffer2 = Encoding.UTF8.GetBytes(Convert.ToString(parameters[i]) + "\0");
                    PS3.SetMemory(0x10050054 + (i * 0x400), buffer2);
                    uint num4 = 0x10050054 + (i * 0x400);
                    byte[] array = BitConverter.GetBytes(num4);
                    Array.Reverse(array);
                    PS3.SetMemory(0x10050000 + ((i + num2) * 4), array);
                }
                else if (parameters[i] is float)
                {
                    num2++;
                    buffer = BitConverter.GetBytes((float)parameters[i]);
                    Array.Reverse(buffer);
                    PS3.SetMemory(0x10050024 + ((num2 - 1) * 4), buffer);
                }
            }
            byte[] bytes = BitConverter.GetBytes(func_address);
            Array.Reverse(bytes);
            PS3.SetMemory(0x1005004c, bytes);
            System.Threading.Thread.Sleep(20);
            byte[] buffer5 = new byte[4];
            PS3.GetMemory(0x10050050, buffer5);
            Array.Reverse(buffer5);
            return BitConverter.ToInt32(buffer5, 0);
        }
        public void ExecuteCommand(string command)
        {
            object[] parameters = new object[] { 0, command };
            CallFunction(0x2B1C14, parameters);
        }

        private void WritePPC()
        {
            PS3.SetMemory(function_address, new byte[] { 0x4e, 0x80, 0, 0x20 });
            System.Threading.Thread.Sleep(20);
            byte[] buffer = new byte[] { 
                0x7c, 8, 2, 0xa6, 0xf8, 1, 0, 0x80, 60, 0x60, 0x10, 5, 0x81, 0x83, 0, 0x4c, 
                0x2c, 12, 0, 0, 0x41, 130, 0, 100, 0x80, 0x83, 0, 4, 0x80, 0xa3, 0, 8, 
                0x80, 0xc3, 0, 12, 0x80, 0xe3, 0, 0x10, 0x81, 3, 0, 20, 0x81, 0x23, 0, 0x18, 
                0x81, 0x43, 0, 0x1c, 0x81, 0x63, 0, 0x20, 0xc0, 0x23, 0, 0x24, 0xc0, 0x43, 0, 40, 
                0xc0, 0x63, 0, 0x2c, 0xc0, 0x83, 0, 0x30, 0xc0, 0xa3, 0, 0x34, 0xc0, 0xc3, 0, 0x38, 
                0xc0, 0xe3, 0, 60, 0xc1, 3, 0, 0x40, 0xc1, 0x23, 0, 0x48, 0x80, 0x63, 0, 0, 
                0x7d, 0x89, 3, 0xa6, 0x4e, 0x80, 4, 0x21, 60, 0x80, 0x10, 5, 0x38, 160, 0, 0, 
                0x90, 0xa4, 0, 0x4c, 0x80, 100, 0, 80, 0xe8, 1, 0, 0x80, 0x7c, 8, 3, 0xa6, 
                0x38, 0x21, 0, 0x70, 0x4e, 0x80, 0, 0x20
             };
            PS3.SetMemory(function_address + 4, buffer);
            PS3.SetMemory(0x10050000, new byte[0x2854]);
            PS3.SetMemory(function_address, new byte[] { 0xf8, 0x21, 0xff, 0x91 });
        }
    }
}
