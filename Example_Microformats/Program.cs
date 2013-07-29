using System;
using System.IO;
using ExampleCommon;

namespace Example_Microformats
{
    class Program
        :BaseExample
    {
        static void Main(string[] args)
        {
            new Program().Example();
        }

        protected override void Example()
        {
            // Extract microformats from a web URL.
            string xml = Api.URLGetMicroformats("http://microformats.org/wiki/hcard");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("microformats.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract microformats from a HTML document.
            xml = Api.HTMLGetMicroformats(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
