using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BEnt
{
   public class ReactModel
    {
        public int Id { get; set; }
        public int News_id { get; set; }
        public string Reacts { get; set; }
        public int User_id { get; set; }
    }
}
