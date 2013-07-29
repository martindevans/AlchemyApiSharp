using System;
using System.IO;
using AlchemyAPI;
using ExampleCommon;

namespace Example_Author
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
            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();

            // Extract concept tags for a web URL.
            string xml = Api.URLGetAuthor("http://www.politico.com/blogs/media/2012/02/detroit-news-ed-upset-over-romney-edit-115247.html");
            Console.WriteLine(xml);

            // Extract concept tags for a web URL.
            xml = Api.HTMLGetAuthor(htmlDoc, "http://www.test.com/");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
