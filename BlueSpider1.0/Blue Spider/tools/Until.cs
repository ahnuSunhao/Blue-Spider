using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Blue_Spider.tools
{
    public class Until
    {
        public static void Log(params System.Object[] message)
        {
            string str = "";
            if (message == null || message.Length == 0)
            {
                str = "null";
            }
            else
            {
                for (int i = 0; i < message.Length; i++)
                {
                    str += message[i];
                }
            }
            Debug.WriteLine(str);
        }
    }
}
