using System;
using System.IO;
using ExampleCommon;

namespace Example_Concepts
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
            // Extract concept tags for a web URL.
            string xml = Api.URLGetRankedConcepts("http://www.techcrunch.com/");
            Console.WriteLine(xml);

            // Extract concept tags for a text string.
            xml = Api.TextGetRankedConcepts("This thing has a steering wheel, tires, and an engine.  Do you know what it is?");
            Console.WriteLine(xml);

            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();

            // Extract concept tags for a HTML document.
            xml = Api.HTMLGetRankedConcepts(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
