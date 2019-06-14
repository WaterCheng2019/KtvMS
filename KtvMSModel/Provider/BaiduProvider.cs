using Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KtvMSModel
{
    public class BaiduProvider : IMusicProvider
    {
        static HttpConfig DEFAULT_CONFIG = new HttpConfig { Referer= "http://music.baidu.com/" };

        public string Name { get; } = "百度";

        public List<Song1> SearchSongs(string keyword, int page, int pageSize)
        {
            var searchResult = HttpHelper.GET(string.Format("http://musicapi.qianqian.com/v1/restserver/ting?query={0}&method=baidu.ting.search.common&format=json&page_no={1}&page_size={2}", keyword, page, pageSize), DEFAULT_CONFIG);
            List<Song1> result = new List<Song1>();
            try
            {
                var searchResultJson = JsonParser.Deserialize(searchResult).song_list;
                var songIds = new List<string>();

                foreach (var item in searchResultJson)
                {
                    songIds.Add(item["song_id"]);
                }

                var songIdsStr = string.Join(",", songIds.ToArray());

                var songInfos = HttpHelper.GET(string.Format("http://music.taihe.com/data/music/links?songIds={0}", songIdsStr), DEFAULT_CONFIG);
                var songList = JObject.Parse(songInfos)["data"]["songlist"];
                int index = 1;

                foreach (var songItem in songList)
                {
                    Song1 song = new Song1
                    {
                        Id = songItem["queryId"].ToString(),
                        SongName = songItem["songName"].ToString(),
                        Singer = songItem["artistName"].ToString(),
                        Album = songItem["albumName"].ToString(),
                        Rate = 128,
                        Index = index++,
                        Size = Convert.ToDouble(songItem["size"].ToString()),
                        Source = Name,
                        URL= songItem["songLink"].ToString(),
                        Duration= Convert.ToDouble(songItem["time"].ToString())
                    };
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
            return song.URL;
        }
    }
}
