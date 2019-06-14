using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;

namespace KtvMSDAL
{
    public  class NewSongService
    {
        String sql = "";
        /// <summary>
        /// 添加歌曲
        /// </summary>
        /// <param name="song1"></param>
        /// <returns></returns>
        public int AddSong(Song1 song1)
        {
            int row = 0;
            try
            {
                int singerId = GetSingerIdByName(song1.Singer);

                StringBuilder sb = new StringBuilder();
                sb.Append("insert into tb_songs(name,songName,singerId,playTime,songSize,source,playCount,addTime) values(");
                sb.AppendFormat("'{0}',", song1.SongName);
                sb.AppendFormat("'{0}',", song1.getFileName());
                sb.AppendFormat("'{0}',", singerId);
                sb.AppendFormat("CONVERT(VARCHAR(50),{0}/60)+'分'+CONVERT(VARCHAR(50),{1}%60)+'秒',", song1.Duration,song1.Duration);
                sb.AppendFormat("'{0}MB',", song1.Size);
                sb.AppendFormat("'{0}',", song1.Source);
                sb.AppendFormat("'{0}',", 0);
                sb.AppendFormat("'{0}')", DateTime.Now);

                row = DatabaseHelper.GetExecuteNonuery(sb.ToString());

            }
            catch (Exception)
            {
                throw;
            }
            return row;
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
                sql =string.Format("select id from dbo.tb_sings where name='{0}'", singerName);
                return Convert.ToInt32(DatabaseHelper.GetExexuteScalar(sql));
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
                sql = string.Format("select Id from dbo.tb_songs where name='{0}'", songName);
                return Convert.ToInt32(DatabaseHelper.GetExexuteScalar(sql));
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
        public int isExeitsSongByName(string songName)
        {
            try
            {
                sql = "select COUNT(*) from dbo.tb_songs  where name='" + songName+"'";
                return Convert.ToInt32(DatabaseHelper.GetExexuteScalar(sql));
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
