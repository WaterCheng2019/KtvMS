using Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public class KugouProvider : IMusicProvider
    {
        static HttpConfig DEFAULT_CONFIG = new HttpConfig { Referer= "http://www.kugou.com/" };

        public string Name { get; } = "酷狗";


        public List<Song1> SearchSongs(string keyword, int page, int pageSize)
        {
            var searchResult = HttpHelper.GET(string.Format("http://songsearch.kugou.com/song_search_v2?keyword={0}&platform=WebFilter&format=json&page={1}&pagesize={2}",keyword,page,pageSize),DEFAULT_CONFIG);
            List<Song1> resut = new List<Song1>();

            try
            {
                var songList = JObject.Parse(searchResult)["data"]["lists"];
                int index = 1;

                foreach (var songItem in songList)
                {
                    Song1 song = new Song1
                    {
                        Id = songItem["FileHash"].ToString(),
                        SongName = songItem["SongName"].ToString(),
                        Singer = songItem["SingerName"].ToString(),
                        Album = songItem["AlbumName"].ToString(),
                        Rate = 128,
                        Index = index++,
                        Size = Convert.ToDouble(songItem["FileSize"].ToString()),
                        Source = Name,
                        Duration = Convert.ToDouble(songItem["Duration"].ToString())
                    };

                    resut.Add(song);
                }

            }
            catch (Exception)
            {
            }

            return resut;
        }

        public string getDownloadUrl(Song1 song)
        {
            var urlInfo = JsonParser.Deserialize(HttpHelper.GET(string.Format("http://m.kugou.com/app/i/getSongInfo.php?cmd=playInfo&hash={0}", song.Id), DEFAULT_CONFIG));
            return urlInfo.url;
        }

       
    }
}
