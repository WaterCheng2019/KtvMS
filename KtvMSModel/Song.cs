using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public class Song
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string songName { get; set; }
        public string pinyin { get; set; }
        public string songtypeID { get; set; }
        public string singerId { get; set; }
        public string songURL { get; set; }
        public int playCount { get; set; }
        public DateTime addTime { get; set; }
        public string playTime { get; set; }
        public string songSize { get; set; }
        public string source { get; set; }
    }
}
