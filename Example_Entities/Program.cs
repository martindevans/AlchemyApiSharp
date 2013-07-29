using System;
using System.IO;
using ExampleCommon;

namespace Example_Entities
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
            // Extract a ranked list of named entities from a web URL.
            string xml = Api.URLGetRankedNamedEntities("http://www.techcrunch.com/");
            Console.WriteLine(xml);


            // Extract a ranked list of named entities from a text string.
            xml = Api.TextGetRankedNamedEntities("Hello there, my name is Bob Jones.  I live in the United States of America.  Where do you live, Fred?");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract a ranked list of named entities from a HTML document.
            xml = Api.HTMLGetRankedNamedEntities(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
