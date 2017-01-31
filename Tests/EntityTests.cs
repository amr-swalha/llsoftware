using System.Linq;
using Core;
using Core.SqlServer;
using NUnit.Framework;

namespace Tests
{

    public class EntityTests
    {
        [TestFixture]
        public class Json
        {
            [TestCase("Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;",
           "D:\\file2.json")]
            public void CheckJson(string connection, string path)
            {
                JSONGenerator json = new JSONGenerator();
                json.ConnectionString = connection;
                Assert.AreEqual(json.GenerateDescription(path), true);
            }

            [TestCase("Check Value")]
            public void CheckConn(string test)
            {
                JSONGenerator json = new JSONGenerator();
                json.ConnectionString = test;
                Assert.AreEqual("Check Value", json.ConnectionString);
            }

            [TestCase("Data Source =.\\sql; Initial Catalog = LLProject; Integrated Security = True; MultipleActiveResultSets = True;")]
            public void CheckTableCount(string connection)
            {
                JSONGenerator json = new JSONGenerator();
                json.ConnectionString = connection;
                Assert.Greater(json.ReadSqlTable().Count, 0);
            }
        }
        [TestFixture]
        public class Xml
        {
            [TestCase("Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;",
           "D:\\file2.xml")]
            public void CheckXml(string connection, string path)
            {
                XmlGenerator xml = new XmlGenerator();
                xml.ConnectionString = connection;
                Assert.AreEqual(xml.GenerateDescription(path), true);
            }
            [TestCase("Check Value")]
            public void CheckConn(string test)
            {
                XmlGenerator xml = new XmlGenerator();
                xml.ConnectionString = test;
                Assert.AreEqual("Check Value", xml.ConnectionString);
            }
            [TestCase("Data Source =.\\sql; Initial Catalog = LLProject; Integrated Security = True; MultipleActiveResultSets = True;")]
            public void CheckTableCount(string connection)
            {
                XmlGenerator xml = new XmlGenerator();
                xml.ConnectionString = connection;
                Assert.Greater(xml.ReadSqlTable().Count, 0);
            }
        }
        [TestFixture]
        public class SqlTableTest
        {
            [TestCase("Data Source =.\\sql; Initial Catalog = LLProject; Integrated Security = True; MultipleActiveResultSets = True;")]
            public void CheckConvertTables(string connection)
            {
                SqlToTable table = new SqlToTable();
                Assert.GreaterOrEqual(table.ConverTables(connection).Count, 0);
            }
            [TestCase("Data Source =.\\sql; Initial Catalog = LLProject; Integrated Security = True; MultipleActiveResultSets = True;")]
            public void CheckConvertTablesData(string connection)
            {
                SqlToTable table = new SqlToTable();
                var tables = table.ConverTables(connection);
                var getTable = tables.First(x => x.Name == "Subject");
                Assert.GreaterOrEqual(getTable.Columns.Count, 0);
            }
        }

    }
}
