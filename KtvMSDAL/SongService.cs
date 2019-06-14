using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using System.Data;

namespace KtvMSDAL
{
    public class SongService
    {
        String sql = "";
        /// <summary>
        /// 获取所有歌曲
        /// </summary>
        /// <returns></returns>
        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();

            try
            {
                sql = "select a.Id,a.name,a.songName,a.playTime,a.songSize,a.source,a.pinyin,a.songtypeID,a.singerId,a.songURL,a.playCount,a.addTime,b.name SingerName,c.songType from tb_songs a left join tb_sings b on a.singerId=b.id left join tb_songTypes c on a.songtypeID=c.id order by playCount desc";
                DataSet ds = DatabaseHelper.GetDataSet(sql);
                if (ds!=null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt!=null&&dt.Rows.Count>0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            Song s = new Song();
                            s.Id = r["Id"].ToString();
                            s.name = r["name"].ToString();
                            s.songName = r["songName"].ToString();
                            s.pinyin = r["pinyin"].ToString();
                            s.songURL = r["songURL"].ToString();
                            s.playCount = Convert.ToInt32(r["playCount"]);
                            s.addTime = Convert.ToDateTime((r["addTime"].ToString() == "" ? "2018-1-1 00:00:00": r["addTime"]));
                            s.songtypeID = r["songType"].ToString();
                            s.singerId= r["SingerName"].ToString();
                            s.playTime= r["playTime"].ToString();
                            s.songSize = r["songSize"].ToString();
                            s.source = r["source"].ToString();
                            songs.Add(s);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return songs;
        }
        
        /// <summary>
        /// 根据条件查搜索歌曲
        /// </summary>
        /// <returns></returns>
        public List<Song> GetAllSongs(String name)
        {
            List<Song> songs = new List<Song>();

            try
            {
                sql = "select a.Id,a.name,a.songName,a.playTime,a.songSize,a.source,a.pinyin,a.songtypeID,a.singerId,a.songURL,a.playCount,a.addTime,b.name SingerName,c.songType from tb_songs a left join tb_sings b on a.singerId=b.id left join tb_songTypes c on a.songtypeID=c.id ";

                if (!String.IsNullOrEmpty(name))
                {
                    sql += String.Format(" where a.name like '%{0}%' or b.name like '%{1}%' or a.playCount  like '%{2}%'", name, name, name); ;
                }

                DataSet ds = DatabaseHelper.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            Song s = new Song();
                            s.Id = r["Id"].ToString();
                            s.name = r["name"].ToString();
                            s.songName = r["songName"].ToString();
                            s.pinyin = r["pinyin"].ToString();
                            s.songURL = r["songURL"].ToString();
                            s.playCount = Convert.ToInt32(r["playCount"]);
                            s.addTime = Convert.ToDateTime((r["addTime"].ToString() == "" ? "2018-1-1 00:00:00" : r["addTime"]));
                            s.songtypeID = r["songType"].ToString();
                            s.singerId = r["SingerName"].ToString();
                            s.playTime = r["playTime"].ToString();
                            s.songSize = r["songSize"].ToString();
                            s.source = r["source"].ToString();
                            songs.Add(s);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return songs.OrderByDescending(i=>i.playCount).ToList();
        }

        /// <summary>
        /// 保存歌曲信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public  int SaveSong(Song s)
        {
            int row = 0;
            try
            {
                if (String.IsNullOrEmpty(s.Id))
                {
                    sql = String.Format("insert into tb_songs(name,songName, pinyin, songtypeID, singerId, songURL, playCount, addTime) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}')", s.name,s.songName,s.pinyin,s.songtypeID,s.singerId,s.songURL,0,DateTime.Now);
                }
                else
                {
                    sql = String.Format("update tb_songs set name='{0}',pinyin='{1}', songtypeID='{2}', singerId='{3}', songURL='{4}',songName='{5}' where Id='{6}' ", s.name, s.pinyin, s.songtypeID, s.singerId, s.songURL,s.songName, s.Id);
                }
                row = DatabaseHelper.GetExecuteNonuery(sql);
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
                sql = "delete from tb_songs where Id="+SongId;
                row = DatabaseHelper.GetExecuteNonuery(sql);
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
            int row = 0;
            try
            {
                sql = String.Format("update tb_songs set playCount=playCount+1 where Id='{0}'", sondId);
                row = DatabaseHelper.GetExecuteNonuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return row;
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
                sql = String.Format("insert into  tb_PlayHistory(SongId,PlayTime) values({0},'{1}')",songId,DateTime.Now);
                return DatabaseHelper.GetExecuteNonuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// 获取歌曲播放记录信息
        /// </summary>
        /// <returns></returns>
        public List<SongHistoy> GetPlayHistoryList()
        {
            List<SongHistoy> songHistoys = null;
            try
            {
                sql = "select a.Id,b.name,c.name singer,b.songName,b.playTime,b.songSize,b.source,b.playCount,b.addTime,a.PlayTime date from  tb_PlayHistory a inner join tb_songs b on a.SongId=b.Id inner join tb_sings c on c.id=b.singerId order by date desc";
                DataSet ds = DatabaseHelper.GetDataSet(sql);

                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
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
                            s.Date = r["date"].ToString();
                            s.PlayCount = r["playCount"].ToString();
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
