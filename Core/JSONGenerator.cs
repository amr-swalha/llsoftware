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
        /// <summary>
        /// Generates the description.
        /// </summary>
        /// <param name="outputFilePath">The output file path. Where the json file will be stored.</param>
        /// <returns><c>true</c> if generation is successful, <c>false</c> otherwise.</returns>
        public bool GenerateDescription(string outputFilePath)
        {
            try
            {
                List<Table> tables = ReadSqlTable();
                string json = JsonConvert.SerializeObject(tables);
                File.AppendAllText(outputFilePath, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
