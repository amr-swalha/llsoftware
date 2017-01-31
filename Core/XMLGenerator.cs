using System;
using System.Collections.Generic;
using System.Xml;
using Core.Generator;
using Core.Models;
using Core.SqlServer;

namespace Core
{
    public class XmlGenerator : IGenerator
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
        /// <param name="outputFilePath">The output file path. Where the xml file will be stored.</param>
        /// <returns><c>true</c> if generation is successful, <c>false</c> otherwise.</returns>
        public bool GenerateDescription(string outputFilePath)
        {
            try
            {
                List<Table> tables = ReadSqlTable();
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("tables");
                xmlDoc.AppendChild(rootNode);
                for (int i = 0; i < tables.Count; i++)
                {
                    XmlNode tableNode = xmlDoc.CreateElement("table");
                    XmlAttribute attribute = xmlDoc.CreateAttribute("Name");
                    attribute.Value = tables[i].Name;
                    for (int j = 0; j < tables[i].Columns.Count; j++)
                    {
                        XmlNode columnNode = xmlDoc.CreateElement("column");
                        XmlAttribute attributeName = xmlDoc.CreateAttribute("Name");
                        XmlAttribute attributeType = xmlDoc.CreateAttribute("Type");
                        attributeName.Value = tables[i].Columns[j].ColumnName;
                        attributeType.Value = tables[i].Columns[j].ColumnType;
                        columnNode.Attributes.Append(attributeName);
                        columnNode.Attributes.Append(attributeType);
                        tableNode.AppendChild(columnNode);
                    }
                    tableNode.Attributes.Append(attribute);
                    rootNode.AppendChild(tableNode);
                }
                xmlDoc.Save(outputFilePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
