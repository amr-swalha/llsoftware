using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Pages
    {
       
        public int Id { get; set; }
        public string PageName { get; set; }
        public List<PageControls> Controles { get; set; }
    }
}
