using System;
using System.Collections.Generic;
using System.IO;
using Core.Generator;
using Core.Models;
using Core.SqlServer;
using Newtonsoft.Json;
namespace Core
{
    public class JSONGenerator : IGenerator
    {
        private readonly SqlToTable _data = new SqlToTable();
        public string ConnectionString { get; set; }
        public List<Table> ReadSqlTable()
        {
            List<Table> tables = _data.ConverTables(ConnectionString);
            return tables;
        }

        public bool GenerateDescription(string outputFilePath)
        {
            try
            {
                List<Table> tables = ReadSqlTable();
                string json = JsonConvert.SerializeObject(tables);
                File.AppendAllText(outputFilePath, json);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
