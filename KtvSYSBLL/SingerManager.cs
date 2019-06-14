using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using KtvMSDAL;

namespace KtvSYSBLL
{
    public class SingerManager
    {
        SingerService singerService = new SingerService();
        /// <summary>
        /// 获取所有歌手信息
        /// </summary>
        /// <returns></returns>
        public List<Singer> GetAllSingers()
        {
            List<Singer> singers = new List<Singer>();
            try
            {
                singers = singerService.GetAllSingers();
            }
            catch (Exception)
            {
                throw;
            }
            return singers;
        }

        /// <summary>
        /// 保存歌手信息
        /// </summary>
        public int AddSingerInfo(Singer s)
        {
            return singerService.AddSingerInfo(s);
        }

        /// <summary>
        /// 修改歌手信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateSingerInfo(Singer s)
        {
            return singerService.UpdateSingerInfo(s);
        }

        /// <summary>
        /// 删除歌手
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteSingerById(int Id)
        {
            return singerService.DeleteSingerById(Id);
        }

        /// <summary>
        /// 获取新插入的ID
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            try
            {
                return singerService.GetNewId();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
