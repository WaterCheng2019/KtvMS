using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KtvMSModel
{
    public  class MusicProviders
    {
        public static MusicProviders Instance
        {
            get
            {
                return Holder.providers;
            }
        }

        public List<IMusicProvider> Providers { get; set; } = new List<IMusicProvider>();

        Dictionary<string, IMusicProvider> type2Provider = new Dictionary<string, IMusicProvider>();

        public string Name=> "MusicProviders";


        public void AddMusicProvider(IMusicProvider provider)
        {
            Providers.Add(provider);
            type2Provider.Add(provider.Name,provider);
        }
        /// <summary>
        /// 获取下载路径
        /// </summary>
        /// <param name="song1"></param>
        /// <returns></returns>
        public string getDownloadUrl(Song1 song1)
        {
            return type2Provider[song1.Source].getDownloadUrl(song1);
        }
        /// <summary>
        /// 搜索歌曲
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<MergedSong1> SearchSongs(string keyword,int page,int pageSize)
        {
            var songs = new List<Song1>();
            Providers.AsParallel().ForAll(provider =>
            {
                var currentSongs = provider.SearchSongs(keyword, page, pageSize);
                songs.AddRange(currentSongs);
            });

            //foreach (var provider in Providers)
            //{
            //    var currentSongs = provider.SearchSongs(keyword, page, pageSize);
            //    songs.AddRange(currentSongs);
            //}

            return songs.GroupBy(s => s.getMergeKey()).Select(g=>new MergedSong1(g.ToList())).OrderByDescending(s=>s.Score).ToList() ;
        }

        /// <summary>
        /// 从当前Assembly加载
        /// </summary>
        static class Holder
        {
            public static MusicProviders providers = Load();

            public static MusicProviders Load()
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                List<Type> hostTypes = new List<Type>();

                foreach (var type in assembly.GetExportedTypes())
                {
                    if (type.Name== "MusicProviders")
                    {
                        continue;
                    }

                    //确定type为类并且继承且实现IMyInstance
                    if (type.IsClass&&typeof(IMusicProvider).IsAssignableFrom(type)&&!type.IsAbstract)
                    {
                        hostTypes.Add(type);
                    }
                }

                MusicProviders musicProviders = new MusicProviders();
                foreach (var type in hostTypes)
                {
                    IMusicProvider instance = (IMusicProvider)Activator.CreateInstance(type);
                    musicProviders.AddMusicProvider(instance);
                }

                return musicProviders;
            }
        }

    }
}
