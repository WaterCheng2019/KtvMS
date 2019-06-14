using Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public class NeteaseProvider : IMusicProvider
    {
        static HttpConfig DEFAULT_CONFIG = new HttpConfig
        {
            Referer = "http://music.163.com/"
        };

        public string Name { get; } = "网易";

        public List<Song1> SearchSongs(string keyword, int page, int pageSize)
        {
            var searchResult = HttpHelper.GET(string.Format("http://music.163.com/api/cloudsearch/pc?s={0}&type=1&offset={1}&limit={2}",keyword,(page-1)*pageSize, pageSize),DEFAULT_CONFIG);
            List<Song1> result = new List<Song1>();

            try
            {
                var songList = JObject.Parse(searchResult)["result"]["songs"];
                int index = 1;

                foreach (var songItem in songList)
                {
                    if (Convert.ToInt32(songItem["privilege"]["fl"])==0)
                    {
                        continue;//无版权
                    }

                    Song1 song = new Song1
                    {
                        Id = songItem["id"].ToString(),
                        SongName = songItem["name"].ToString(),
                        Album = songItem["al"]["name"].ToString(),
         
                        Index = index++,
                       
                        Source=Name,
                        Duration= Convert.ToDouble(songItem["dt"].ToString())/1000

                    };
                    song.Singer = "";
                    foreach (var ar in songItem["ar"])
                    {
                        song.Singer += ar["name"] + " ";
                    }
                    song.Rate = Convert.ToInt32(songItem["privilege"]["fl"])/1000;

                    int fl = Convert.ToInt32(songItem["privilege"]["fl"]);
                    if (songItem["h"]!=null&&fl>32000)
                    {
                        song.Size = Convert.ToDouble(songItem["h"]["size"]);
                    }
                    else if (songItem["m"] != null && fl >= 192000)
                    {
                        song.Size = Convert.ToDouble(songItem["m"]["size"]);
                    }
                    else if (songItem["l"] != null)
                    {
                        song.Size = Convert.ToDouble(songItem["l"]["size"]);
                    }
                    result.Add(song);
                }

            }
            catch (Exception ex)
            {
            }

            return result;
        }
        public string getDownloadUrl(Song1 song)
        {
            var param = new JObject();
            var urlInfo = JsonParser.Deserialize(HttpHelper.GET(string.Format("http://music.163.com/api/song/enhance/player/url?id={0}&ids=%5B{0}%5D&br=3200000", song.Id),DEFAULT_CONFIG));
            return urlInfo.data[0]["url"];
        }

       
    }
}
