using System.Collections.Generic;
using Core.Models;

namespace Core.Generator
{
    /// <summary>
    /// <list type="bullet">
    /// <item>
    /// <description>Created By: Amr Swalha</description>
    /// </item>
    /// <item>
    /// <description>Created At: 29-01-2017</description>
    /// </item>
    /// <item>
    /// <description>Modified At: 29-01-2017</description>
    /// </item>
    /// </list>
    /// Interface IGenerator, to give this interface to the different generators
    /// </summary>
    public interface IGenerator
    {
        List<Table> ReadSqlTable();
        bool GenerateDescription(string outputFilePath);
    }
}
