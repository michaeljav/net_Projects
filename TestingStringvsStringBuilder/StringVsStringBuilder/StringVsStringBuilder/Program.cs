using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringVsStringBuilder
{
    public class Program
    {
        /*tESTING  STRING  */
        public static void StringTest()
        {
            Console.WriteLine("String Builder Test");

            var sw = new Stopwatch();
            sw.Start();
            string str = "";
            for (int i = 0; i < 100000; i++)
            {
                str += i.ToString();
            }

            sw.Stop();

            //Console.WriteLine("Result: " + str);
            Console.WriteLine("Exectution Time " + sw.ElapsedMilliseconds + " ms");
        }

        /*tESTING  STRING BUILDER */
        public static void StringBuilderTest()
        {
            Console.WriteLine("String Builder Test");

            var sw = new Stopwatch();
            sw.Start();
            var sb = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                sb.Append(i.ToString());
            }

            sw.Stop();
            //Console.WriteLine("Result: " + sb);
            Console.WriteLine("Exectution Time " + sw.ElapsedMilliseconds + " ms");
        }





        public static void Main(string[] args)
        {


            StringTest();
            StringBuilderTest();


            
        }
    }

}