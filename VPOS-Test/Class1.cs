using System;
using System.Collections.Generic;
using System.Text;
using Utils.MAC;

namespace VPOS_Test
{
    class Test
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("OPERATOR", "operator");
            var encoder = new MACEncoder();
            Console.WriteLine(encoder.GetMac(dict, "key"));
        }
    }
}