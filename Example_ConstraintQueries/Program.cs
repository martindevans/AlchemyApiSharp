using System;
using System.IO;
using ExampleCommon;

namespace Example_ConstraintQueries
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
            // Extract first link from an URL.
            string xml = Api.URLGetConstraintQuery("http://microformats.org/wiki/hcard", "1st link");
            Console.WriteLine(xml);


            // Load a HTML document to analyze.
            StreamReader streamReader = new StreamReader("example.html");
            string htmlDoc = streamReader.ReadToEnd();
            streamReader.Close();


            // Extract first link from a HTML.
            xml = Api.HTMLGetConstraintQuery(htmlDoc, "http://www.test.com/", "1st link");
            Console.WriteLine(xml);

            base.Example();
        }
    }
}
