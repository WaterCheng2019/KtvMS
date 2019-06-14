using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using KtvMSDAL;

namespace KtvSYSBLL
{
    public class SongTypeManager
    {
        SongTypeService songService = new SongTypeService();
        /// <summary>
        /// 获取所有歌曲类型
        /// </summary>
        /// <returns></returns>
        public List<SongType> GetAllSongType()
        {
            List<SongType> types = null;

            try
            {
                types = songService.GetAllSongType();
            }
            catch (Exception)
            {
                throw;
            }

            return types;
        }
    }
}
