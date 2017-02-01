using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PageControls
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public string ControlName { get; set; }
        public string ControlType { get; set; }
        public string ControlValue { get; set; }
    }
}
