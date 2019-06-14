using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using System.Data;

namespace KtvMSDAL
{
   public  class SongTypeService
    {
        String sql = "";
        /// <summary>
        /// 获取所有歌曲类型
        /// </summary>
        /// <returns></returns>
        public List<SongType> GetAllSongType()
        {
            List<SongType> types = new List<SongType>();

            try
            {
                sql = "select id,songType  from tb_songTypes";
                DataSet ds = DatabaseHelper.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt!=null&&dt.Rows.Count>0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            SongType t = new SongType();
                            t.id = Convert.ToInt32(r["id"]);
                            t.songType = r["songType"].ToString();
                            types.Add(t);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return types;
        }
    }
}
