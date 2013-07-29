using System;
using System.IO;
using ExampleCommon;

namespace Example_FeedLinks
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
            // Extract RSS / ATOM feed links from a web URL.
            string xml = Api.URLGetFeedLinks("http://www.techcrunch.com/");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract RSS / ATOM feed links from a HTML document.
            xml = Api.HTMLGetFeedLinks(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
