<%@ page language="C#" autoeventwireup="true" inherits="Demo.UI.MachineCode.Student_UI_M, App_Web_c22efipp" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student</title>
    <!--[if IE 6]>
<script src="../Scripts/iepng.js" type="text/javascript"></script>
<![endif]-->
    <link href="../style/basic.css" rel="stylesheet" type="text/css" />
    <link href="../style/base.css" type="text/css" rel="stylesheet" />
    <link href="../style/FrameWork.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Scripts/JScript.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-validation-1.9.0/jquery.validate.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-validation-1.9.0/jquery.validate.vaidationgroup.js"
        type="text/javascript"></script>
    <script src="../Scripts/jquery-validation-1.9.0/localization/messages_cn.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-validation-1.9.0/additional-methods.HNAS4.0.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {


            if (isValidationGroup) {
                if (opts != undefined || opts != null) {
                    jQuery("#<%=form1.ClientID %>").validate(jQuery.extend(opts, { onsubmit: false }));
                } else {
                    jQuery("#<%=form1.ClientID %>").validate({
                        onsubmit: false
                    });
                }
                InitValidationGroup();
            } else {
                if (opts != undefined || opts != null) {
                    jQuery("#<%=form1.ClientID %>").validate(opts);
                } else {
                    jQuery("#<%=form1.ClientID %>").validate();
                }
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <!-- 标记(logo)区域 -->
        <!-- end 标记(logo)区域 -->
        <!-- 主导航 -->
        <div id="dd-navigation">
            <div id="nav-strip">
                <ul>
                    <li class="nav-item no-subnav " id="nav-item_1"><a href="#"><span class="primary-link">
                        框架Demo</span></a></li>
                    <li class="nav-item no-subnav " id="nav-item_2"><a href="Class_M.aspx"><span class="primary-link">
                        班级管理</span></a></li>
                    <li class="nav-item no-subnav active" id="nav-item_3"><a href="Student_M.aspx"><span
                        class="primary-link">学员管理</span></a> </li>
                    <li class="nav-item no-subnav" id="nav-item_4"><a href="Subject_M.aspx"><span class="primary-link">
                        科目管理</span></a></li>
                </ul>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <!-- end 主导航 -->
        <!-- 主要内容 -->
        <div id="content" class="p_5 clearfix">
            <!-- 查询 -->
            <div class="searchModule clearfix m_b_10" id="searchRequest">
                <div class="hd_left">
                    <div class="hd_right">
                        <div class="hd_main">
                            <h3>
                                <img src="../images/icon_01.gif" />
                                Student</h3>
                            <span>
                                <input id="Button1" type="button" class="btn_style01" onclick="javascript:$('#searchRequest').hide();"
                                    value="隐 藏" /></span></div>
                    </div>
                </div>
                <div class="bg_left">
                    <div class="bg_right">
                        <div class="bg_main">
                            <%--  查询条件--%>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_style02 validationGroup">
                                <tr>
                                    <th>
                                        ID：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_ID' runat='server' onkeyup='javascript:clearNoNum(this);' CssClass='input_style1 IntegerNum' />
                                    </td>
                                    <th>
                                        CLASSI：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_ClassID' runat='server' onkeyup='javascript:clearNoNum(this);'
                                            CssClass='input_style1 IntegerNum' />
                                    </td>
                                    <th>
                                        SID1：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_SID' runat='server' CssClass='input_style1' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        密码：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_Password' runat='server' CssClass='input_style1' />
                                    </td>
                                    <th>
                                        名字：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_Name' runat='server' CssClass='input_style1' />
                                    </td>
                                    <th>
                                        性别：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_Sex' runat='server' onkeyup='javascript:clearNoNum(this);'
                                            CssClass='input_style1 IntegerNum' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        生日：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_Birthday' runat='server' class='Wdate' onFocus='WdatePicker({isShowClear:true,readOnly:true})' />
                                    </td>
                                    <th>
                                        邮箱：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_Email' runat='server' CssClass='input_style1' />
                                    </td>
                                    <th>
                                        是否管理员：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_IsAdmin' runat='server' onkeyup='javascript:clearNoNum(this);'
                                            CssClass='input_style1 IntegerNum' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        是否有效：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbM_Valid' runat='server' onkeyup='javascript:clearNoNum(this);'
                                            CssClass='input_style1 IntegerNum' />
                                    </td>
                                    <th>
                                        （自定义查询）ID介于
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbMin' runat='server' onkeyup='javascript:clearNoNum(this);' CssClass='input_style1 IntegerNum' />和
                                        <asp:TextBox ID='txbMax' runat='server' onkeyup='javascript:clearNoNum(this);' CssClass='input_style1 IntegerNum' />之间
                                    </td>
                                    <th colspan="2" style="text-align: center">
                                        <asp:Button ID="btnSearch" CssClass="btn_style02 causesValidation" runat="server"
                                            Text="查 询" OnClick="btnSearch_Click" />
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        （自定义更新）条件：
                                    </th>
                                    <td>
                                        班级：
                                        <asp:TextBox ID='txbClassID' runat='server' onkeyup='javascript:clearNoNum(this);'
                                            CssClass='input_style1 IntegerNum' />
                                    </td>
                                    <th>
                                        是否有效：
                                    </th>
                                    <td>
                                        <asp:RadioButtonList ID="rblValid" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        更新内容：Email
                                        <asp:TextBox ID='txbEmail' runat='server' CssClass='input_style1 email' />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" CssClass="btn_style02 causesValidation" runat="server"
                                            Text="自定义更新" OnClick="btnUpdate_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="ft_left">
                    <div class="ft_right">
                        <div class="ft_main">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end 查询-->
            <!-- 数据绑定 -->
            <div class="searchModule clearfix">
                <div class="hd_left">
                    <div class="hd_right">
                        <div class="hd_main">
                            <h3>
                                <img src="../images/icon_01.gif" />
                                Student</h3>
                            <span>
                                <input id="btnSearchhb" type="button" class="btn_style01" onclick="javascript:$('#searchRequest').show();"
                                    value="筛选条件" />&nbsp;&nbsp;
                                <input id="btnAddbhb" type="button" class="btn_style01" onclick="javascript:btnaddClickShow();"
                                    value="添 加" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class="bg_left">
                    <div class="bg_right">
                        <div class="bg_main">
                            <asp:GridView ID="gvData" runat="server" DataKeyNames=" cniID" CssClass="tb_style01"
                                Width="100%" AllowPaging="True" PagerSettings-Visible="false" OnRowCommand="gvData_RowCommand"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField HeaderText='ID' DataField='cniID' />
                                    <asp:BoundField HeaderText='CLASSI' DataField='cniClassID' />
                                    <asp:BoundField HeaderText='SID1' DataField='cnvcSID' />
                                    <asp:BoundField HeaderText='密码' DataField='cnvcPassword' />
                                    <asp:BoundField HeaderText='名字' DataField='cnvcName' />
                                    <asp:BoundField HeaderText='性别' DataField='cniSex' />
                                    <asp:BoundField HeaderText='生日' DataField='cndBirthday' />
                                    <asp:BoundField HeaderText='邮箱' DataField='cnvcEmail' />
                                    <asp:BoundField HeaderText='是否管理员' DataField='cniIsAdmin' />
                                    <asp:BoundField HeaderText='是否有效' DataField='cniValid' />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lbtShowBM" CommandName='EditShow'>编辑</asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lbtDel" OnClientClick="javascript:return confirm('确定要删除吗？');"
                                                CommandName='Del'>删除</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <%=CreateTitle(this.gvData, false)%>
                                </EmptyDataTemplate>
                                <PagerSettings Visible="False"></PagerSettings>
                            </asp:GridView>
                            <webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
                                runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
                                OnPageChanged="AspNetPager_PageChanged" ShowCustomInfoSection="Left" HorizontalAlign="Right"
                                PageIndexBoxType="TextBox" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                                TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
                <div class="ft_left">
                    <div class="ft_right">
                        <div class="ft_main">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end 数据绑定-->
            <!-- 添加/修改 -->
            <!-- 遮罩层 -->
            <div id="MaskDiv" class="MaskDiv">
            </div>
            <!--end 遮罩层 -->
            <div id="AddEdit" runat="server" class="searchModule clearfix m_b_10" style="position: absolute;
                display: none; z-index: 99; left: 80px; top: 100px; width: 80%;">
                <div class="hd_left">
                    <div class="hd_right">
                        <div class="hd_main">
                            <h3>
                                添加/编辑</h3>
                        </div>
                    </div>
                </div>
                <div class="bg_left">
                    <div class="bg_right">
                        <div class="bg_main">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_style02 validationGroup">
                                <tr>
                                    <th>
                                        ID：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_ID' onkeyup='javascript:clearNoNum(this);' runat='server'
                                            CssClass='input_style1 IntegerNum  ' />
                                    </td>
                                    <th>
                                        <em>* </em>CLASSI：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_ClassID' onkeyup='javascript:clearNoNum(this);' runat='server'
                                            CssClass='input_style1 IntegerNum required ' />
                                    </td>
                                    <th>
                                        <em>* </em>SID1：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_SID' runat='server' CssClass='input_style1 required' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        密码：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_Password' runat='server' CssClass='input_style1 ' />
                                    </td>
                                    <th>
                                        名字：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_Name' runat='server' CssClass='input_style1 ' />
                                    </td>
                                    <th>
                                        性别：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_Sex' onkeyup='javascript:clearNoNum(this);' runat='server'
                                            CssClass='input_style1 IntegerNum  ' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        生日：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_Birthday' runat='server' class='Wdate ' onFocus='WdatePicker({isShowClear:true,readOnly:true})' />
                                    </td>
                                    <th>
                                        邮箱：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_Email' runat='server' CssClass='input_style1 ' />
                                    </td>
                                    <th>
                                        是否管理员：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_IsAdmin' onkeyup='javascript:clearNoNum(this);' runat='server'
                                            CssClass='input_style1 IntegerNum  ' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        是否有效：
                                    </th>
                                    <td>
                                        <asp:TextBox ID='txbNewM_Valid' onkeyup='javascript:clearNoNum(this);' runat='server'
                                            CssClass='input_style1 IntegerNum  ' />
                                    </td>
                                    <tr>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td>
                                            <asp:Button ID="btnAdd" CssClass="btn_style02 causesValidation" runat="server" Text="添 加"
                                                OnClick="btnAdd_Click" />
                                            <asp:Button ID="btnEdit" CssClass="btn_style02 causesValidation" runat="server" Text="修 改"
                                                OnClick="btnEdit_Click" />
                                            <input type="button" class="btn_style02" onclick="javascript:$('#AddEdit').hide();$('#MaskDiv').hide();"
                                                value="关 闭" />
                                        </td>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="ft_left">
                    <div class="ft_right">
                        <div class="ft_main">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end 添加/修改-->
        </div>
        <!-- end 主要内容 -->
    </div>
    </form>
</body>
</html>
