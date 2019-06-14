using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public class Song1
    {
        public string Id { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
        public string Source { get; set; }
        public double Duration { get; set; }
        public double Size { get; set; }
        public string URL { get; set; }
        public int Rate { get; set; }
        public int Index { get; set; }

        public string getFileName()
        {
            return Singer.Trim() + "-" + SongName.Trim() + ".mp3";
        }

        public string getMergeKey()
        {
            return Singer.Replace(" ", "") + SongName.Replace(" ","");
        }
    }

    public class MergedSong1
    {
        public List<Song1> items { get; set; }
        public MergedSong1(List<Song1> items)
        {
            this.items = items;
        }

        public string SongName
        {
            get
            {
                return this.items[0].SongName;
            }
        }

        public string Singer
        {
            get
            {
                return this.items[0].Singer;
            }
        }

        public string Album
        {
            get
            {
                return this.items[0].Album;
            }
        }

        public string Source
        {
            get
            {
                return string.Join(",", this.items.Select(i => i.Source).ToArray());
            }
        }

        public double Duration
        {
            get
            {
                return this.items[0].Duration;
            }
        }

        public double Size
        {
            get
            {
                return this.items[0].Size;
            }
        }

        public double Rate
        {
            get
            {
                return this.items[0].Rate;
            }
        }

        public string getFileName
        {
            get
            {
                return this.items[0].getFileName();
            }
        }

        public double Score
        {
            get
            {
                // 投票+排序加权  (各50%）
                //return this.items.Count /(MusicProviders.Instance.Providers.Count-1)+(20-this.items.Average(i=>i.Index))/20;
                return this.items.Count / (MusicProviders.Instance.Providers.Count-1) + (20 - this.items.Average(i => i.Index)) / 20;
            }
        }

    }
}
