using System;
using System.IO;
using ExampleCommon;

namespace Example_Language
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
            // Detect the language for a web URL.
            string xml = Api.URLGetLanguage("http://news.google.de/");
            Console.WriteLine(xml);


            // Detect the language for a text string (requires at least 15 characters).
            xml = Api.TextGetLanguage("Hello there, my name is Bob Jones.  I live in the United States of America.  Where do you live, Fred?");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Detect the language for a HTML document.
            xml = Api.HTMLGetLanguage(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
