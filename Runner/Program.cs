using System;
using Core;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;";
            XmlGenerator xml = new XmlGenerator();
            JsonGenerator json = new JsonGenerator(connection);
            xml.ConnectionString = connection;
            //Console.WriteLine(xml.GenerateDescription("D:\\file2.xml"));
            Console.WriteLine(json.GenerateUi("D:\\ui5.json"));
            Console.Read();
        }
    }
}
