using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public class Singer
    {
        public int SingId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Remake { get; set; }
        public string PhotoURL { get; set; }
        public DateTime AddTime { get; set; }
    }
}
