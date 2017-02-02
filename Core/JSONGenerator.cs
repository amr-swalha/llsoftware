using System;
using System.Collections.Generic;
using System.IO;
using Core.Generator;
using Core.Models;
using Core.SqlServer;
using Newtonsoft.Json;
namespace Core
{
    public class JsonGenerator : IGenerator
    {
        private readonly SqlToTable _data = new SqlToTable();
        public string ConnectionString { get; set; }
        public JsonGenerator(string connectionString)
        {
            ConnectionString = connectionString;
        }
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
        /// <summary>
        /// Generates the UI. Make sure that you have _Pages 
        /// and _PageControls Tables in the database witht he defenations of pages and controls
        /// </summary>
        /// <param name="outputFilePath">The output file path.</param>
        /// <returns><c>true</c> if the generation is successful, <c>false</c> otherwise.</returns>
        public bool GenerateUi(string outputFilePath)
        {
            try
            {
                SqlToTable sqlToTable = new SqlToTable();
                List<Pages> pages = sqlToTable.GetPages(ConnectionString);
                string json = JsonConvert.SerializeObject(pages);
                if (File.Exists(outputFilePath))
                    File.Delete(outputFilePath);
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
