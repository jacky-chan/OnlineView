<%@ Application Language="C#" %>
<%@ Import Namespace="HNAS.Framework4.Caching" %>
<%@ Import Namespace="HNAS.Framework4.ExceptionHandling" %>
<%@ Import Namespace="HNAS.Framework4.Logging" %>
<%@ Import Namespace="HNAS.Framework4.Security" %>
<%@ Import Namespace="HNAS.Framework4.WebCommon" %>

<script runat="server">
    //数据连接字符串
    readonly string strConn = ConfigurationManager.ConnectionStrings["dbDemo"].ToString();
    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        
        //开启缓存通知
        SqlCacheDep sqlDep = new SqlCacheDep(strConn);
        //创建通知表
        sqlDep.EnableNotifications();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码
        //停用通知表
        SqlCacheDep sqlDep = new SqlCacheDep(strConn);
        sqlDep.DisableNotifications();

    }
        
    /// <summary>
    /// 当应用程序中遇到一个未处理的异常时，该事件被触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 创 建 人：HNAS .Net Framework 4.0 项目组
    /// 创建日期：2011-12-5
    /// 修 改 人：
    /// 修改日期：
    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码
        var ex = Server.GetLastError();

        //异常处理
        HandleException(ex, "GeneralPolicy");
        Server.ClearError();
    }

    /// <summary>
    /// 异常处理
    /// </summary>
    /// <param name="ex">异常</param>
    /// <param name="policy">处理策略</param>
    /// 创 建 人：HNAS .Net Framework 4.0 项目组
    /// 创建日期：2011-12-5
    /// 修 改 人：
    /// 修改日期：
    protected void HandleException(Exception ex, string policy)
    {
        bool rethrow = ExceptionPolicy.HandleException(ex, "GeneralPolicy");
        if (rethrow)
        {
            //写入日志
            WriteLogToDB.WriteLog(ex.Message, "Demo");

            AlertMsn.PopMsn("系统异常，请重试。");
        }
    }


    /// <summary>
    /// 在一个用户的会话超时、结束或他们离开应用程序 Web 站点时，该事件被触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 创 建 人：HNAS .Net Framework 4.0 项目组
    /// 创建日期：2011-12-5
    /// 修 改 人：
    /// 修改日期：
    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为 InProc 时，才会引发 Session_End 事件。
        // 如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
    }

    /// <summary>
    /// 在接收到一个应用程序请求时触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 创 建 人：HNAS .Net Framework 4.0 项目组
    /// 创建日期：2011-12-5
    /// 修 改 人：
    /// 修改日期：
    void Application_BeginRequest(object sender, EventArgs e)
    {
        //防SQL注入
        //SiteSecurity.CheckSQLInjection(this);//使用框架默认关键字检查
        SiteSecurity.CheckSQLInjection(this, strIllegalChars: "IllegalChars", strIllegalSQLKeys: "IllegalSQLKeys");//使用自定义关键字过滤
    }
</script>
