using System;
using Core;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlGenerator xml = new XmlGenerator();
            JSONGenerator json = new JSONGenerator();
            xml.ConnectionString =
                "Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;";
            json.ConnectionString =
                "Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;";
            Console.WriteLine(xml.GenerateDescription("D:\\file2.xml"));
            Console.WriteLine(json.GenerateDescription("D:\\file2.json"));
            Console.Read();
        }
    }
}
