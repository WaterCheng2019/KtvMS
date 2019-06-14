using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using System.Data;

namespace KtvMSDAL
{
    public class SingerService
    {

        string sql = "";
        /// <summary>
        /// 获取所有歌手信息
        /// </summary>
        /// <returns></returns>
        public List<Singer> GetAllSingers()
        {
            List<Singer> singers = new List<Singer>();
            try
            {
                sql = "select s.id 编号,s.name 歌手,s.gender 性别,t.singerType 类型,s.photoURL 图片,s.remark 简介,s.addTime 添加时间 from tb_sings s left join tb_singerTypes t on s.singTypeId=t.Id order by addTime desc";
                DataTable dt = DatabaseHelper.GetDataSet(sql).Tables[0];

                foreach (DataRow r in dt.Rows)
                {
                    Singer s = new Singer();
                    s.SingId = Convert.ToInt32(r["编号"]);
                    s.Name = r["歌手"].ToString();
                    s.Gender = r["性别"].ToString();
                    s.Type = r["类型"].ToString();
                    s.Remake = r["简介"].ToString();
                    s.PhotoURL = r["图片"].ToString();
                    s.AddTime= Convert.ToDateTime(r["添加时间"].ToString());
                    singers.Add(s);
                }

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
            sql = string.Format("insert into dbo.tb_sings(name,gender,singTypeId,photoURL,remark,addTime) values('{0}','{1}','{2}','{3}','{4}','{5}')", s.Name, s.Gender,(s.Type==null)?"1":s.Type,s.PhotoURL,s.Remake,DateTime.Now);
            return DatabaseHelper.GetExecuteNonuery(sql);
        }

        /// <summary>
        /// 修改歌手信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateSingerInfo(Singer s)
        {
            sql = string.Format("update tb_sings set name='{0}',gender='{1}',singTypeId='{2}',photoURL='{3}',remark='{4}' where id='{5}'", s.Name, s.Gender, s.Type, s.PhotoURL, s.Remake,s.SingId);
            return DatabaseHelper.GetExecuteNonuery(sql);
        }


        /// <summary>
        /// 删除歌手
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteSingerById(int Id)
        {
            sql = "delete from  dbo.tb_sings where id="+Id;
            return DatabaseHelper.GetExecuteNonuery(sql);
        }

        /// <summary>
        /// 获取新插入的ID
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            try
            {
                sql = "SELECT max(id) FROM dbo.tb_sings";
                return DatabaseHelper.GetExexuteScalar(sql).ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
