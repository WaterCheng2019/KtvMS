using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using KtvMSDAL;

namespace KtvSYSBLL
{
    public class SongManager
    {
        SongService songService = new SongService();
        /// <summary>
        /// 获取所有歌曲
        /// </summary>
        /// <returns></returns>
        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();

            try
            {
                songs = songService.GetAllSongs();
            }
            catch (Exception)
            {
                throw;
            }

            return songs;
        }
        /// <summary>
        /// 根据条件搜索歌曲
        /// </summary>
        /// <returns></returns>
        public List<Song> GetAllSongs(String name)
        {
            List<Song> songs = new List<Song>();

            try
            {
                songs = songService.GetAllSongs(name);
            }
            catch (Exception)
            {
                throw;
            }

            return songs;
        }



        /// <summary>
        /// 保存歌曲信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int SaveSong(Song s)
        {
            int row = 0;

            try
            {
                row = songService.SaveSong(s);
            }
            catch (Exception)
            {
                throw;
            }

            return row;
        }

        /// <summary>
        /// 删除歌曲
        /// </summary>
        /// <returns></returns>
        public int DeleteSongById(int SongId)
        {
            int row = 0;
            try
            {
                row = songService.DeleteSongById(SongId);
            }
            catch (Exception)
            {
                throw;
            }

            return row;
        }

        /// <summary>
        /// 更新播放次数
        /// </summary>
        /// <param name="sondId"></param>
        /// <returns></returns>
        public int UpatePlayCount(int sondId)
        {
            try
            {
                return songService.UpatePlayCount(sondId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 歌曲播放记录
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        public int SavePlayHistory(int songId)
        {
            try
            {
                return songService.SavePlayHistory(songId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取播放记录集合
        /// </summary>
        /// <returns></returns>
        public List<SongHistoy> GetPlayHistoryList()
        {
            try
            {
                return songService.GetPlayHistoryList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
