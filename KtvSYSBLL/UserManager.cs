using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KtvMSModel;
using KtvMSDAL;

namespace KtvSYSBLL
{
    public class UserManager
    {
        UserService userService = new UserService();

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUser()
        {
            try
            {
                return userService.GetAllUser();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool isUserName(String userName)
        {
            bool isBool = false;
            try
            {
                if (userService.isUserName(userName) >0)
                {
                    isBool = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isBool;

        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUser(User u)
        {
            try
            {
                return userService.AddUser(u);
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUserById(int userId)
        {
            try
            {
                return userService.DeleteUserById(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 是否登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool isLogin(String userName,String pwd)
        {
            bool flag = false;
            try
            {
                if (userService.isLogin(userName, pwd) >0)
                {
                    flag = true;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return flag;

        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int EditUserPwd(String userName, String oldPwd, String newPwd)
        {
            try
            {
                return userService.EditUserPwd(userName, oldPwd, newPwd);
            }
            catch (Exception)
            {

                throw;
            }

          
        }
        /// <summary>
        /// 登陆日志
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int LoginLog()
        {
            try
            {
                return userService.LoginLog();
            }
            catch (Exception)
            { 
                throw;
            }
        }


        }
}
