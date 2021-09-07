using Dapper;
using LoginAPI.Common;
using LoginAPI.IService;
using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
    public class LoginInfoService : ILoginInfoService
    {
        LoginInfo _ologininfo = new LoginInfo();
        public async Task<string> confirmMail(string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName)) return "Invalid username";
                LoginInfo ologinInfo = new LoginInfo()
                {
                    UserName = userName
                };
                LoginInfo loginInfo = await this.CheckRecordExistence(ologinInfo);
                if (loginInfo == null)
                {
                    return Message.InvalidUser;
                }
                else
                {
                    using(IDbConnection con=new SqlConnection(Global.ConnectionString))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        var ologinInfos = await con.QueryAsync<LoginInfo>("Sp_LoginInfo"
                            , this.SetParameters(ologinInfo, (int)OperationType.UpdateConfirmMail)
                            , commandType: CommandType.StoredProcedure);
                        if (ologinInfos != null && ologinInfos.Count() > 0)
                        {
                            _ologininfo = ologinInfos.FirstOrDefault();
                        }
                        return "Mail Confirm";
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<LoginInfo> SignUp(LoginInfo ologinInfo)
        {
            _ologininfo = new LoginInfo();
            try
            {
                LoginInfo loginInfo = await this.CheckRecordExistence(ologinInfo);
                if (loginInfo == null)
                {
                    using(IDbConnection con=new SqlConnection(Global.ConnectionString))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        var ologinInfos = await con.QueryAsync<LoginInfo>("Sp_LoginInfo"
                            , this.SetParameters(ologinInfo, (int)OperationType.Signup)
                            , commandType: CommandType.StoredProcedure);
                        if(ologinInfos!=null && ologinInfos.Count() > 0)
                        {
                            _ologininfo = ologinInfos.FirstOrDefault();
                        }
                        _ologininfo.Message = Message.Success;
                    }
                }
                else
                {
                    _ologininfo = loginInfo;
                }
            }
            catch (Exception ex)
            {

              _ologininfo.Message=ex.Message;
            }
            return _ologininfo;
        }
        private async Task<LoginInfo> CheckRecordExistence(LoginInfo ologinInfo)
        {
            LoginInfo loginInfo = new LoginInfo();
            if (!string.IsNullOrEmpty(ologinInfo.UserName))
            {
                loginInfo = await this.GetLoginUser(ologinInfo.UserName);
                if (loginInfo != null)
                {
                    if (!loginInfo.isMailConfirm)
                    {
                        loginInfo.Message = Message.VerifyMail;
                    }
                    else if(loginInfo.isMailConfirm)
                    {
                        loginInfo.Message = Message.UserAlreadyCreated;
                    }
                }
            }
            return loginInfo;
        }
        public async Task<LoginInfo> GetLoginUser(string username)
        {
            _ologininfo = new LoginInfo();
            using(IDbConnection con=new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                string sSQL = "SELECT * FROM [User] wHERE 1=1";
                if (!string.IsNullOrEmpty(username)) sSQL += " AND UserName='" + username + "'";
                var oLoginInfos = (await con.QueryAsync<LoginInfo>(sSQL)).ToList();
                if (oLoginInfos != null && oLoginInfos.Count > 0) _ologininfo = oLoginInfos.SingleOrDefault();
                else return null;
            }
            return _ologininfo;
        }

        private DynamicParameters SetParameters(LoginInfo ologinInfo,int nOperationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", ologinInfo.UserId);
            parameters.Add("@Email", ologinInfo.EmailId);
            parameters.Add("@UserName", ologinInfo.UserName);
            parameters.Add("@PasswordHash", ologinInfo.Password);
            parameters.Add("@EmailConfirmed", ologinInfo.isMailConfirm);
            parameters.Add("@OperationType", nOperationType);
            return parameters;
        }
    }
}
