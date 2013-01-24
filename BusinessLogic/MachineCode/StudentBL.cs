using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HNAS.Framework4.BLBase;
using Demo.BusinessModel.MachineCode;
using Demo.DataAccess.MachineCode;

namespace Demo.BusinessLogic.MachineCode
{
    /// <summary>
    /// 自定义 BusinessLogic 类
    /// </summary>
    /// Copyright (c) 2011 海南海航航空信息系统有限公司
    /// 创 建 人：HNAS Framework 4.0 项目组
    /// 创建日期：2012-03-15
    /// 修 改 人：
    /// 修改日期：
    /// 版 本：1.0

    public class StudentBL : CommonBL
    {
        /// <summary>
        /// 构造函数（针对非默认数据库）
        /// </summary>
        /// <param name="strDBName">配置文件数据库连接名</param>
        /// <param name="strAccount">日志记录账号</param>
        /// 创 建 人：王宇(wang_yu5)
        /// 创建日期：2012-03-19
        public StudentBL(string strDBName = "", string strAccount = "Admin")
            : base(strDBName, strAccount)
        {
        }

        #region 删除数据（删除班级同时删除班级所在学员）
        /// <summary>
        /// 删除数据（删除班级同时删除班级所在学员）
        /// </summary>
        /// <param name="studentBM">数据实体</param>
        /// <returns>操作结果集</returns>
        /// 创 建 人：HNAS .Net Framework 4.0 项目组
        /// 创建日期：2011-12-5
        /// 修 改 人：
        /// 修改日期：
        public CallResult<DataTable> GetStudentWithClass(StudentBM studentBM)
        {
            CallResult<DataTable> result = new CallResult<DataTable>();

            try
            {
                result.Result = new StudentDA().GetStudentWithClass(studentBM);
                result.Message = Message.Operate_Success;
            }
            catch (Exception ex)
            {
                result.Result = null;
                result.Message = Message.Operate_Unsuccess;
                result.Error = ex;

                //处理异常
                HandleException(ex);
            }

            return result;
        }
        #endregion
    }
}
