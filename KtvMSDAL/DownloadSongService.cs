using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using System.Data;
using System.Data.SqlClient;

namespace KtvMSDAL
{
    public class DownloadSongService
    {
        String sql = "";
        /// <summary>
        /// 增加下载记录
        /// </summary>
        /// <returns></returns>
        public int AddDownloadSong(int songId)
        {
            try
            {
                sql = String.Format("insert into tb_DownloadHistory(SongId,DownloadTime) values({0},'{1}')",songId,DateTime.Now);
                return DatabaseHelper.GetExecuteNonuery(sql);
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
            List<SongHistoy> songHistoys = null;
            try
            {
                sql = "select a.Id,b.name,c.name singer,b.songName,b.playTime,b.songSize,b.source,b.playCount,b.addTime,a.DownloadTime from  tb_DownloadHistory a inner join tb_songs b on a.SongId=b.Id inner join tb_sings c on c.id=b.singerId order by DownloadTime desc";
                DataSet ds = DatabaseHelper.GetDataSet(sql);

                if (ds!=null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt!=null&&dt.Rows.Count>0)
                    {
                        songHistoys = new List<SongHistoy>();
                        foreach (DataRow r in dt.Rows)
                        {
                            SongHistoy s = new SongHistoy();
                            s.Id = r["Id"].ToString();
                            s.Name = r["name"].ToString();
                            s.Singer = r["singer"].ToString();
                            s.AllName = r["songName"].ToString();
                            s.PlayTime = r["playTime"].ToString();
                            s.Size = r["songSize"].ToString();
                            s.Soure = r["source"].ToString();
                            s.Date = r["DownloadTime"].ToString();
                            s.PlayCount= r["playCount"].ToString();
                            songHistoys.Add(s);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return songHistoys;
        }

    }
}
