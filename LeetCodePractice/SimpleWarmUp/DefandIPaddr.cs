using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

/*
Given a valid (IPv4) IP address, return a defanged version of that IP address.

A defanged IP address replaces every period "." with "[.]".

Example 1:

Input: address = "1.1.1.1"
Output: "1[.]1[.]1[.]1"
Example 2:

Input: address = "255.100.50.0"
Output: "255[.]100[.]50[.]0"
*/

namespace LeetCodePractice.SimpleWarmUp
{
    class DefandIPaddr
    {
        //static void Main()
        static void Main1108()
        {
            string s = "1.1.1.1";
            Console.Out.WriteLine(DefangIPaddr(s));
            Console.In.ReadLine();
        }
        public static string DefangIPaddr(string address)
        {
            return address.Replace(".", "[.]");
        }
    }
}
