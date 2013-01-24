using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using HNAS.Framework4.WebCommon;
using HNAS.Framework4.BLBase;
using HNAS.Framework4.Common;

using Demo.BusinessLogic.MachineCode;
using Demo.BusinessModel.MachineCode;
using System.Data.Common;
using System.Data.SqlClient;


namespace Demo.UI.MachineCode
{
    /// <summary>
    ///  Student
    /// </summary>
    ///  Copyright (c) 2012-2015 海南海航航空信息系统有限公司
    /// 创 建 人：HNAS Framework 4.0 项目组
    /// 创建日期：2012/3/15 17:21:33
    /// 修 改 人：
    /// 修改日期：
    ///  版 本：1.0

    public partial class Student_UI_M : BasePage
    {
        StudentBM _studentBM = new StudentBM();//私有对象

        #region Page_Load
        /// <summary>
        /// Page_Load
        /// </summary>       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {          
                AspNetPager1.CurrentPageIndex = 1;
                AspNetPager1.RecordCount = 0;
                BindData(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            }
        }

        #endregion

        #region 查询按钮
        /// <summary>
        /// 查询按钮
        /// </summary>      
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = 0;
            BindData(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="iPageIndex">当前页数</param>
        /// <param name="iPageSize">每页显示行数</param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void BindData(int iPageIndex, int iPageSize)
        {

            _studentBM = new StudentBM();

            //获取textbox查询条件的值    
            base.GetObjValueByTextBox(_studentBM, "txb");
            /**** 自定义控件值得获取可在这里输入,例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/


            /*调用BF查询函数进行查询*/
            //CallResult<DataTable> result = new CommonBL().GetDataTableByLike(_studentBM);//默认

            int? iTotal = 0;//数据总数
            //CallResult<DataTable> result = new CommonBL().GetDataTableByLike(_studentBM, out iTotal, iPageSize, iPageIndex);//数据库分页默认

            #region 自定义查询Demo
            //列过滤
            const string strColumnFilter = "cniID,cniClassID,cnvcSID,cnvcName,cnvcPassword,cniSex,cndBirthDay,cnvcEmail,cniIsAdmin,cniValid";

            //自定义条件（支持比较操作符）
            Dictionary<string, DbParameter> dictionary = new Dictionary<string, DbParameter>();//操作符-参数键值对
            if (!string.IsNullOrEmpty(txbMin.Text.Trim()))
            {
                DbParameter parameter1 = new SqlParameter("cniID", txbMin.Text.Trim());
                dictionary.Add(">=", parameter1);
            }
            if (!string.IsNullOrEmpty(txbMax.Text.Trim()))
            {
                DbParameter parameter2 = new SqlParameter("1cniID", txbMax.Text.Trim());//如查询一个字段的多个区间，请将其中一个参数设置为数字开头的名称
                dictionary.Add("<=", parameter2);
            }

            //参数设置
            CallResult<DataTable> result = new CommonBL().GetDataTableByLike(_studentBM,
                out iTotal,                                                      //数据总数
                iPageSize,                                                      //每页个数
                iPageIndex,                                                   //第几页
                bCache: false, strCacheKey: "StudentCache", //是否缓存（默认false）
                strOrderBy: "cniID ASC",                               //自定义排序
                strColumnFilter: strColumnFilter,                   //列过滤（默认返回所有）
                dicOperator_Parameter: dictionary,               //自定义查询条件（支持比较操作符（等于,不等于,小于,大于,小于等于,大于等于）
                bValidate: false);                                            //是否验证实体（默认false）

            #endregion

            if (result.HasError)
            {
                AspNetPager1.RecordCount = 0;
                AlertMsn.PopMsn(result.Message);
            }

            if (result.Result != null)
            {
                //AspNetPager1.RecordCount = result.Result.Rows.Count;  //不应用数据库分页
                AspNetPager1.RecordCount = iTotal.Value;
                //动态设置用户自定义文本内容
                this.BindPagerCustomInfoHTML(AspNetPager1);
                //页面绑定           
                gvData.PageIndex = AspNetPager1.CurrentPageIndex - 1;
                //鼠标悬停高亮显示
                gvData.RowCreated += this.GridViewRowsChangeColor;
            }

            gvData.DataSource = result.Result;
            gvData.DataBind();
        }

        /// <summary>
        /// 翻页控件翻页
        /// </summary>       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：
        /// 创建日期：2012/2/29 10:57:38
        /// 修 改 人：
        /// 修改日期：
        protected void AspNetPager_PageChanged(object sender, EventArgs e)
        {
            BindData(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        }

        #endregion

        #region 添加事件--保存到数据库
        /// <summary>
        /// 添加事件--保存到数据库
        /// </summary>        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /*获取新添加对象的值*/
            GetBMNewInfor(_studentBM);
             /**** 自定义控件值得获取可在这里输入,或者在函数GetBMNewInfor里添加，例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            //存入数据库（默认添加方法：记录日志并验证实体）
            CallResult<string> cr = new CommonBL().Add(_studentBM);

            //自定义参数
            //CallResult<string> cr2 = new CommonBL().Add(_studentBM, bLogging: false, bValidate: false);//不记录日志，不验证实体

            AlertMsn.PopMsn(cr.Message);
            if (!cr.HasError )
            {
               //添加成功，并重新绑定数据
                this.AspNetPager1.CurrentPageIndex = 1;
                BindData(this.AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            }
          
        }
        #endregion

        #region 删除事件--从数据库中删除
        /// <summary>
        /// 删除事件--从数据库中删除
        /// </summary>
        /// <param name="studentBM"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void DelBM(StudentBM studentBM)
        {
            // 从数据库中删除（默认删除方法：根据主键删除，记录日志，不验证实体）
            CallResult<bool> cr = new CommonBL().Delete(studentBM);//直接使用BL基类方法//自定义删除参考ClassDA.cs

            AlertMsn.PopMsn(cr.Message);
            if (!cr.HasError || cr.Result)
            {
                //删除成功重新绑定数据
                this.AspNetPager1.CurrentPageIndex = 1;
                BindData(this.AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            }
           
        }
        #endregion

        #region 修改事件--保存到数据库
        /// <summary>
        /// 修改事件--保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["_studentBM"]!=null)
            {
                _studentBM = ViewState["_studentBM"] as StudentBM ;// 获取对象主键信息
            }
            /*获取对象的新值*/
            GetBMNewInfor(_studentBM);
            /**** 自定义控件值得获取可在这里输入,或者在函数GetBMNewInfor里添加，例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            //存入数据库（默认方法：根据主键更新，记录日志，验证实体）
            CallResult<bool> cr = new CommonBL().Update(_studentBM);
            AlertMsn.PopMsn(cr.Message);
            if (!cr.HasError || cr.Result)
            {
                //修改成功重新绑定数据
                this.AspNetPager1.CurrentPageIndex = 1;
                BindData(this.AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            }         
        }

        #endregion

        #region 自定义更新Demo
        /// <summary>
        /// 自定义更新Demo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：
        /// 创建日期：2012/2/29 10:57:38
        /// 修 改 人：
        /// 修改日期：
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //存入数据库（默认方法：根据主键更新，记录日志，验证实体）
            //CallResult<bool> cr = new CommonBL().Update(_studentBM);

            //自定义条件更新Demo
            //条件参数
            DbParameter[] parameters = new DbParameter[2];
            parameters[0] = new SqlParameter("cniClassID", txbClassID.Text.Trim());
            parameters[1] = new SqlParameter("cniValid", rblValid.SelectedValue);

            //更新内容
            _studentBM.M_Email = txbEmail.Text.Trim();
            //提交更新，不记录日志，不验证实体
            CallResult<bool> cr = new CommonBL().Update(_studentBM, parameters, bLogging: false, bValidate: false);

            #region 生成测试数据
            //IList<StudentBM> iList = new List<StudentBM>();
            //if (_studentBM != null)
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        StudentBM student = new StudentBM();
            //        GetBMNewInfor(student);
            //        if (i<5000)
            //        {
            //            student.M_ClassID = 40;
            //        }
            //        else
            //        {
            //            student.M_ClassID = 41;
            //        }
            //        student.M_SID = "Student" + i.ToString();
            //        student.M_Name = student.M_SID;
            //        iList.Add(student);
            //    }

            //    //批量添加方法（默认：记录日志，并验证BM实体）
            //    CallResult<bool> cr2 = new CommonBL().Add(iList);

            //    //可设置不记录，不验证BM实体
            //    //cr2 = new CommonBL().Add(iList, bLogging: false, bValidate: false);
            //}
            #endregion

            if (!cr.HasError || cr.Result)
            {
                //修改成功重新绑定数据
                BindData(this.AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            }
            AlertMsn.PopMsn(cr.Message);
        }

        #endregion


        #region 获得新添/修改后对象信息
        /// <summary>
        /// 获得新添/修改后对象信息
        /// </summary>        
        /// <param name="studentBM"></param>
        /// <returns></returns>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected StudentBM GetBMNewInfor(StudentBM studentBM)
        {
            this.GetObjValueByTextBox(studentBM, "txbNew");
            /**** 自定义控件值得获取可在这里输入,例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            return studentBM;
        } 
        #endregion


        #region gvData_RowCommand
        /// <summary>
        /// gvData_RowCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:33
        /// 修 改 人：
        /// 修改日期：
        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = ((GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent).RowIndex;//获得所选行
            if (e.CommandName == "Del")//删除
            {
                GetPrimaryKeyValue(_studentBM, gvData, rowIndex);//获取主键
                 /**** 自定义控件值得获取可在这里输入,例如：
                 * 
                 * student.ID = gvData.DataKeys[rowIndex].Values["cniid"] as int?,
                 * student.ClassID = gvData.DataKeys[rowIndex].Values["cniclassid"] as int?
                 * 
                 * ****/

                this.DelBM(_studentBM);

            }
            else if (e.CommandName == "EditShow")//编辑
            {
                GetPrimaryKeyValue(_studentBM, gvData, rowIndex, "txbNew");//获取主键并设置主键等不可更改信息为enabled
                  /**** 自定义控件值得获取可在这里输入,例如：
                 * 
                 * student.ID = gvData.DataKeys[rowIndex].Values["cniid"] as int?,
                 * student.ClassID = gvData.DataKeys[rowIndex].Values["cniclassid"] as int?
                 * 
                 * ****/

                //获取BM详细数据
                _studentBM = new CommonBL().GetOne(_studentBM).Result;
                if (_studentBM == null)
                {
                    return;
                }
                ViewState["_studentBM"] = _studentBM;// 保存对象主键信息

                base.SetTxbValue(_studentBM, "txbNew");//绑定对象值到txbbox，
                
                /**** set praimary key set Enabled false and set the other conctrols value,例如：
                 * 自定义控件的赋值等等 ddl.selectIndex=1；
                 * txbNewId.Enabled = false;    
                 * 
                 * ****/

                //显示div
                base.RegisterScript("$('#MaskDiv').show();$('#AddEdit').show();$('#btnAdd').hide();$('#btnEdit').show()");

            }
        } 
        #endregion
    }
}