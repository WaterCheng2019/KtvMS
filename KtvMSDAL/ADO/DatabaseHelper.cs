using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KtvMSDAL
{
    public class DatabaseHelper
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["connStr2"].ToString();
        public static SqlConnection conn = new SqlConnection(connStr);

        /// <summary>
        /// 获取受影响的行数，增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetExecuteNonuery(string sql)
        {
            int row = 0;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(),"异常信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                throw;
            }
            finally
            {
                conn.Close();
            }

            return row;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }

            return ds;
        }

        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetExexuteScalar(string sql)
        {
            object obj = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
            finally
            {
                conn.Close();
            }
            return obj;
        }
        
    }
}
