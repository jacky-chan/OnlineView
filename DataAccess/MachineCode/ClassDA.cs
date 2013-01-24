using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HNAS.Framework4.Data;
using Demo.BusinessModel.MachineCode;
using System.Data.Common;
using System.Data.SqlClient;

namespace Demo.DataAccess.MachineCode
{
    /// <summary>
    /// 自定义 DataAccess 类
    /// </summary>
    /// Copyright (c) 2011 自定义 BusinessLogic 类海航航空信息系统有限公司
    /// 创 建 人：HNAS Framework 4.0 项目组
    /// 创建日期：2012-03-15
    /// 修 改 人：
    /// 修改日期：
    /// 版 本：1.0

    public class ClassDA : CommonDA
    {
        /// <summary>
        /// 构造函数（针对非默认数据库）
        /// </summary>
        /// <param name="strDBName">配置文件数据库连接名</param>
        /// 创 建 人：HNAS .Net Framework 4.0 项目组
        /// 创建日期：2012-03-19
        public ClassDA(string strDBName = "")
            : base(strDBName)
        {
        }


        #region 事务处理Demo（删除班级同时删除班级所在学员）
        /// <summary>
        /// 事务处理Demo
        /// </summary>
        /// <param name="classBM">数据实体</param>
        /// 创 建 人：HNAS .Net Framework 4.0 项目组
        /// 创建日期：2011-12-5
        /// 修 改 人：
        /// 修改日期：
        public bool DeleteWithTransation(ClassBM classBM)
        {
            using (DataAccess.dbConnection = DataAccess.db.CreateConnection())
            {
                //打开数据库连接
                DataAccess.dbConnection.Open();
                //开始数据库事务
                DataAccess.dbTransaction = DataAccess.dbConnection.BeginTransaction();

                try
                {
                    //删除班级所有学员（自定义条件删除）
                    DbParameter[] param = new DbParameter[2];
                    param[0] = new SqlParameter("cniClassID", classBM.M_ClassID);//条件1
                    param[1] = new SqlParameter("cniIsAdmin", 0);                  //条件2（不是管理员）

                    bool bSuccess = Delete(new StudentBM(), param);


                    //删除班级
                    //classBM.M_ID = null;//删除失败回滚
                    if (bSuccess)
                    {
                        bSuccess = Delete(classBM);
                    }

                    //提交数据库事务
                    DataAccess.dbTransaction.Commit();
                    return bSuccess;
                }
                catch (Exception)
                {
                    //从挂起状态回滚事务
                    DataAccess.dbTransaction.Rollback();
                    throw;
                }
            }
        }
        #endregion

    }
}
