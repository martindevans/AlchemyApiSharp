using System;
using System.IO;
using ExampleCommon;

namespace Example_Keywords
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
            // Extract topic keywords for a web URL.
            string xml = Api.URLGetRankedKeywords("http://www.techcrunch.com/");
            Console.WriteLine(xml);


            // Extract topic keywords for a text string.
            xml = Api.TextGetRankedKeywords("Hello there, my name is Bob Jones.  I live in the United States of America.  Where do you live, Fred?");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract topic keywords for a HTML document.
            xml = Api.HTMLGetRankedKeywords(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
