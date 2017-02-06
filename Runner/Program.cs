using System;
using Core;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;";
            XmlGenerator xml = new XmlGenerator(connection);
            JsonGenerator json = new JsonGenerator(connection);
            //Console.WriteLine(xml.GenerateDescription("D:\\file2.xml"));
            Console.WriteLine(json.GenerateUi("D:\\UI.json"));
            //Console.WriteLine(xml.GenerateUi(@"D:\UI.xml"));
            Console.Read();
        }
    }
}
