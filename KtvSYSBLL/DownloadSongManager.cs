using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using KtvMSDAL;

namespace KtvSYSBLL
{
   public  class DownloadSongManager
    {
        DownloadSongService downloadSongService = new DownloadSongService();
        /// <summary>
        /// 增加下载记录
        /// </summary>
        /// <returns></returns>
        public int AddDownloadSong(int songId)
        {
            try
            {
                return downloadSongService.AddDownloadSong(songId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 获取下载集合
        /// </summary>
        /// <returns></returns>
        public List<SongHistoy> GetDownloadHistoyList()
        {
            try
            {
                return downloadSongService.GetDownloadHistoyList();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
