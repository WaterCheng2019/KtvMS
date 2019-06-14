using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public enum StateSong
    {
        play,stop,cut,replay
    }
    public class Songing
    {
        public String Name { get; set; }
        public String Singer { get; set; }
        public int SongName { get; set; }
        public StateSong StateSong { get; set; }
    }
}
