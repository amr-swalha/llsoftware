using System.Collections.Generic;

namespace Core.Models
{
    public class Table
    {
        public string Name { get; set; }
        public List<Columns> Columns { get; set; }
    }
}
