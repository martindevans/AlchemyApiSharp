using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExampleCommon;

namespace Example_TextExtract
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
            // Extract page text from a web URL. (ignoring ads, navigation links, etc.)
            string xml = Api.URLGetText("http://www.techcrunch.com/");
            Console.WriteLine(xml);

            PauseForUserInput();

            // Extract raw page text from a web URL. (including ads, navigation links, etc.)
            xml = Api.URLGetRawText("http://www.techcrunch.com/");
            Console.WriteLine(xml);

            PauseForUserInput();

            // Extract a title from a web URL.
            xml = Api.URLGetTitle("http://www.techcrunch.com/");
            Console.WriteLine(xml);

            PauseForUserInput();

            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();

            // Extract page text from a HTML document. (ignoring ads, navigation links, etc.)
            xml = Api.HTMLGetText(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            PauseForUserInput();

            // Extract raw page text from a HTML document. (including ads, navigation links, etc.)
            xml = Api.HTMLGetRawText(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            PauseForUserInput();

            // Extract a title from a HTML document.
            xml = Api.HTMLGetTitle(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
