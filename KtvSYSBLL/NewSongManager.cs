using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using KtvMSDAL;

namespace KtvSYSBLL
{ 
    public  class NewSongManager
    {
        NewSongService newSongService = new NewSongService();

        /// <summary>
        /// 添加歌曲
        /// </summary>
        /// <param name="song1"></param>
        /// <returns></returns>
        public int AddSong(Song1 song1)
        {
            try
            {
                return newSongService.AddSong(song1);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 判断歌曲是否已存在
        /// </summary>
        /// <param name="SongId"></param>
        /// <returns></returns>
        public bool isExeitsSongByName(string songName)
        {
            try
            {
                if (newSongService.isExeitsSongByName(songName) >0)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        /// <summary>
        /// 根据歌手姓名获取歌手ID
        /// </summary>
        /// <param name="singerName"></param>
        /// <returns></returns>
        public int GetSingerIdByName(string singerName)
        {
            try
            {
                return newSongService.GetSingerIdByName(singerName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据歌名获取歌曲ID
        /// </summary>
        /// <param name="singerName"></param>
        /// <returns></returns>

        public int GetSongIdByName(string songName)
        {
            try
            {
                return newSongService.GetSongIdByName(songName);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
