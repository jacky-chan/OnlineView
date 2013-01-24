
/// <summary>
/// 页面基类
/// </summary>
/// Copyright (c) 2011 海航航空信息系统有限公司
/// 创 建 人：HNAS .Net Framework 4.0 项目组
/// 创建日期：2011-12-5
/// 修 改 人：
/// 修改日期：
/// 版 本：1.0
[Microsoft.Security.Application.SecurityRuntimeEngine.SupressAntiXssEncoding()] //防XSS跨站脚本攻击
public class BasePage : HNAS.Framework4.WebCommon.UIBase
{
    /// <summary>
    /// Bind Pager CustomInfoHtml
    /// </summary>
    /// Copyright (c) 
    /// 创 建 人：王好(hao-wang@hnair.net)
    /// 创建日期：2012年2月1日
    /// 修 改 人：王好
    /// 修改日期：
    /// 版 本:
    /// <param name="aspNetPager"></param>
    public new void BindPagerCustomInfoHTML(Wuqi.Webdiyer.AspNetPager aspNetPager)
    {
        base.BindPagerCustomInfoHTML(aspNetPager);
    //    aspNetPager.CustomInfoHTML += "记录总数：<font color=\"blue\"><b>" + aspNetPager.RecordCount.ToString() + "</b></font>";
    //    aspNetPager.CustomInfoHTML += " 总页数：<font color=\"blue\"><b>" + aspNetPager.PageCount.ToString() + "</b></font>";
    //    aspNetPager.CustomInfoHTML += " 当前页：<font color=\"red\"><b>" + aspNetPager.CurrentPageIndex.ToString() + "</b></font>";
    }

   

}
