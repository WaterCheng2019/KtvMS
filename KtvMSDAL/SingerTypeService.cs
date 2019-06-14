using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using System.Data;

namespace KtvMSDAL
{
    public class SingerTypeService
    {
        string sql = "";

        /// <summary>
        /// 获取所有歌曲类型
        /// </summary>
        /// <returns></returns>
        public List<SingerType> GetAllTypes()
        {
            List<SingerType> types = new List<SingerType>();
            try
            {
                sql = "select * from tb_singerTypes";
                DataSet ds = DatabaseHelper.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow r in dt.Rows)
                    {
                        SingerType t = new SingerType();
                        t.Id = Convert.ToInt32(r["Id"]);
                        t.singType = r["singerType"].ToString();
                        types.Add(t);
                    }
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            return types;
        }

    }
}
