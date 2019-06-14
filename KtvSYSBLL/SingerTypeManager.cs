using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSDAL;
using KtvMSModel;

namespace KtvSYSBLL
{
    public class SingerTypeManager
    {
        SingerTypeService singType = new SingerTypeService();
        /// <summary>
        /// 获取所有歌手类型
        /// </summary>
        /// <returns></returns>
        public List<SingerType> GetAllTypes()
        {
            List<SingerType> types = new List<SingerType>();

            try
            {
                types = singType.GetAllTypes();
            }
            catch (Exception)
            {
                throw;
            }

            return types;
        }
    }
}
