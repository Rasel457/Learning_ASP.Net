using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BEnt
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public System.DateTime Publish_date { get; set; }
        public int Author_id { get; set; }
        public int Catagory_id { get; set; }
       // public virtual CatagoryModel Catagory { get; set; }
    }
}
