using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HNAS.Framework4.Data;

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

    public class SubjectDA : CommonDA
    {
        /// <summary>
        /// 构造函数（针对非默认数据库）
        /// </summary>
        /// <param name="strDBName">配置文件数据库连接名</param>
        /// 创 建 人：HNAS .Net Framework 4.0 项目组
        /// 创建日期：2012-03-19
        public SubjectDA(string strDBName = "")
            : base(strDBName)
        {
        }

    }
}
