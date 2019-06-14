using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace KtvMSDAL
{
    public class UserService
    {
        String sql = "";
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUser()
        {
            List<User> Users = new List<User>();

            try
            {
                sql = "select id,userName,passWord,userType from dbo.tb_users";
                DataSet ds = DatabaseHelper.GetDataSet(sql);
                if (ds!=null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt!=null&&dt.Rows.Count>0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            User u = new User();
                            u.UserId = r["id"].ToString();
                            u.UserName = r["userName"].ToString();
                            u.UserPwd = r["passWord"].ToString();
                            u.UserType = r["userType"].ToString();
                            Users.Add(u);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Users;
        }

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int isUserName(String userName)
        {
            try
            {
                sql = String.Format("select COUNT(*) from dbo.tb_users where userName='{0}'",userName);
                return Convert.ToInt32(DatabaseHelper.GetExexuteScalar(sql));
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUser(User u)
        {
            int row = 0;

            try
            {
                sql = String.Format("insert into tb_users(userName,passWord,userType) values('{0}','{1}','{2}')",u.UserName,u.UserPwd,u.UserType);
                row = DatabaseHelper.GetExecuteNonuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
            return row;
        }
        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUserById(int userId)
        {
            int row = 0;

            try
            {
                sql = "delete from tb_users where id =" + userId;
                row = DatabaseHelper.GetExecuteNonuery(sql);
            }
            catch (Exception)
            {

                throw;
            }

            return row;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public int isLogin(String userName,String  pwd)
        {
            int row = 0;
            try
            {
                sql = String.Format("select COUNT(*) from tb_users where userName='{0}' and passWord='{1}'", userName, pwd);
                row = Convert.ToInt32(DatabaseHelper.GetExexuteScalar(sql));
            }
            catch (Exception)
            {

                throw;
            }
            return row;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int EditUserPwd(String userName, String oldPwd,String newPwd)
        {
            int row = 0;
            try
            {
                sql = String.Format("update tb_users set passWord='{0}'  where userName='{1}' and passWord='{2}'", newPwd, userName, oldPwd);
                row = DatabaseHelper.GetExecuteNonuery(sql);
            }
            catch (Exception)
            { 
                throw;
            }
            return row;
        }
        /// <summary>
        /// 登陆日志
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int LoginLog()
        {
            int row = 0;
            try
            {
                String IP = "";
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                     //从IP地址列表中筛选出IPv4类型的IP地址
                     //AddressFamily.InterNetwork表示此IP为IPv4,
                     //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                     if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                     {
                        IP=IpEntry.AddressList[i].ToString();
                     }
                }
                sql = String.Format("insert into tb_LoginLog(UserName,LoginTime,HostName,LoginIp) values('{0}','{1}','{2}','{3}')",UserHelpercs.UserName,DateTime.Now.ToString(), HostName, IP);
                row = DatabaseHelper.GetExecuteNonuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return row;

        }
    }
}
