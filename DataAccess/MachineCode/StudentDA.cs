using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HNAS.Framework4.Data;
using Demo.BusinessModel.MachineCode;
using System.Data.SqlClient;
using System.Data.Common;

namespace Demo.DataAccess.MachineCode
{
    /// <summary>
    /// 自定义 DataAccess 类
    /// </summary>
    /// Copyright (c) 2011 海南海航航空信息系统有限公司
    /// 创 建 人：HNAS Framework 4.0 项目组
    /// 创建日期：2012-03-15
    /// 修 改 人：
    /// 修改日期：
    /// 版 本：1.0

    public class StudentDA : CommonDA
    {
        /// <summary>
        /// 构造函数（针对非默认数据库）
        /// </summary>
        /// <param name="strDBName">配置文件数据库连接名</param>
        /// 创 建 人：HNAS .Net Framework 4.0 项目组
        /// 创建日期：2012-03-19
        public StudentDA(string strDBName = "")
            : base(strDBName)
        {
        }

        #region 通过自定义SQL语句执行数据库操作
        /// <summary>
        /// 通过自定义SQL语句执行数据库操作
        /// </summary>
        /// <param name="studentBM"></param>
        /// <returns></returns>
        public DataTable GetStudentWithClass(StudentBM studentBM)
        {
            string sql = "SELECT s.* FROM tbStudent s LEFT JOIN tbClass c ON s.cniClassID=c.cniID WHERE s.cniValid = @Valid AND s.cnvcName LIKE %@Name%";

            //参数化
            List<SqlParameter> paramerList = new List<SqlParameter>();
            SqlParameter para1 = new SqlParameter("@Valid", studentBM.M_Valid);
            SqlParameter para2 = new SqlParameter("@Name", studentBM.M_Name);

            paramerList.Add(para1);
            paramerList.Add(para2);

            DbCommand dcmd = DataAccess.db.GetSqlStringCommand(sql);
            dcmd.CommandType = CommandType.Text;
            dcmd.Parameters.AddRange(paramerList.ToArray());

            //执行SQL语句
            //返回DataReader
            //IDataReader iReader = DataAccess.db.ExecuteReader(dcmd);

            //返回DataTable
            return DataAccess.db.ExecuteDataSet(dcmd).Tables[0];

        }
        #endregion

    }
}
