using System;
using System.IO;
using AlchemyAPI;
using ExampleCommon;

namespace Example_Categories
{
    public class Program
        :BaseExample
    {
        static public void Main()
        {
            new Program().Example();
        }

        protected override void Example()
        {
            // Categorize a web URL by topic.
            string xml = Api.URLGetCategory("http://www.techcrunch.com/");
            Console.WriteLine(xml);

            // Categorize some text.
            xml = Api.TextGetCategory("Latest on the War in Iraq.");
            Console.WriteLine(xml);

            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();

            // Categorize a HTML document by topic.
            xml = Api.HTMLGetCategory(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}

