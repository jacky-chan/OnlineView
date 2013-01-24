using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    public const string strMessage = "系统错误，请返回重试，如有问题请联系系统管理员。";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["msg"]))
        {
            ltMessage.Text = Request.QueryString["msg"].ToString();
        }
        else
        {
            ltMessage.Text = strMessage;
        }
        //返回错误页面
        hlReturn.NavigateUrl = Request.QueryString["aspxerrorpath"];

    }
}