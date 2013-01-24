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


namespace Demo.UI.MachineCode
{
    /// <summary>
    ///  Class
    /// </summary>
    ///  Copyright (c) 2012-2015 海南海航航空信息系统有限公司
    /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
    ///  版 本：1.0

    public partial class Class_UI_M : BasePage
    {
        ClassBM _classBM = new ClassBM();//私有对象

        #region Page_Load
        /// <summary>
        /// Page_Load
        /// </summary>       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:32
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
        /// 创建日期：2012/3/15 17:21:32
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
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
        protected void BindData(int iPageIndex, int iPageSize)
        {
            
            _classBM = new ClassBM();
            
            //获取textbox查询条件的值    
            base.GetObjValueByTextBox(_classBM, "txb");
            /**** 自定义控件值得获取可在这里输入,例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            int? iTotal = 0;
            /*调用BF查询函数进行查询*/
            CallResult<DataTable> result = new CommonBL("dbDemo1").GetDataTableByLike(_classBM, out iTotal, iPageSize, iPageIndex);//非默认数据库操作
            //CallResult<DataTable> result = new CommonBL().GetDataTableByLike(_classBM);//不分页
            if (result.HasError)
            {
                AspNetPager1.RecordCount = 0;
                AlertMsn.PopMsn( result.Message);
            }

            if (result.Result != null)
            {
                AspNetPager1.RecordCount = iTotal.Value;//result.Result.Rows.Count;（不分页）
                //动态设置用户自定义文本内容
                this.BindPagerCustomInfoHTML(AspNetPager1);
                //页面绑定           
                gvData.PageIndex = AspNetPager1.CurrentPageIndex - 1;
                //鼠标悬停高亮显示
                gvData.RowCreated += new GridViewRowEventHandler(this.GridViewRowsChangeColor);
            }

            gvData.DataSource = result.Result;

            gvData.DataBind();
        }
       
        /// <summary>
        /// 翻页控件翻页
        /// </summary>       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:32
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
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /*获取新添加对象的值*/
            GetBMNewInfor(_classBM);
             /**** 自定义控件值得获取可在这里输入,或者在函数GetBMNewInfor里添加，例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            //存入数据库
            CallResult<string> cr = new CommonBL().Add(_classBM);

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
        /// <param name="classBM"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
        protected void DelBM(ClassBM classBM)
        {
            // 从数据库中删除
            //CallResult<bool> cr = new CommonBL().Delete(classBM);//直接使用BL基类方法
            // 从数据库中删除
            CallResult<bool> cr = new ClassBL("dbDemo1").DeleteWithTransation(classBM);//

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
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["_classBM"]!=null)
            {
                _classBM = ViewState["_classBM"] as ClassBM ;// 获取对象主键信息
            }
            /*获取对象的新值*/
            GetBMNewInfor(_classBM);
            /**** 自定义控件值得获取可在这里输入,或者在函数GetBMNewInfor里添加，例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            //存入数据库
            CallResult<bool> cr = new CommonBL().Update(_classBM);
            AlertMsn.PopMsn(cr.Message);
            if (!cr.HasError || cr.Result)
            {
                //修改成功重新绑定数据
                this.AspNetPager1.CurrentPageIndex = 1;
                BindData(this.AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
            }         
        }

        #endregion


        #region 获得新添/修改后对象信息
        /// <summary>
        /// 获得新添/修改后对象信息
        /// </summary>        
        /// <param name="classBM"></param>
        /// <returns></returns>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
        protected ClassBM GetBMNewInfor(ClassBM classBM)
        {
            this.GetObjValueByTextBox(classBM, "txbNew");
            /**** 自定义控件值得获取可在这里输入,例如：
             * 
             * student.Email = this.ddlContry.Text;
             * student.IfDelete = this.radio.check;
             * 
             * ****/

            return classBM;
        } 
        #endregion


        #region gvData_RowCommand
        /// <summary>
        /// gvData_RowCommand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 创 建 人：HNAS Framework 4.0 项目组
        /// 创建日期：2012/3/15 17:21:32
        /// 修 改 人：
        /// 修改日期：
        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = ((GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent).RowIndex;//获得所选行
            if (e.CommandName == "Del")//删除
            {
                GetPrimaryKeyValue(_classBM, gvData, rowIndex);//获取主键
                 /**** 自定义控件值得获取可在这里输入,例如：
                 * 
                 * student.ID = gvData.DataKeys[rowIndex].Values["cniid"] as int?,
                 * student.ClassID = gvData.DataKeys[rowIndex].Values["cniclassid"] as int?
                 * 
                 * ****/

                this.DelBM(_classBM);

            }
            else if (e.CommandName == "EditShow")//编辑
            {
                GetPrimaryKeyValue(_classBM, gvData, rowIndex, "txbNew");//获取主键并设置主键等不可更改信息为enabled
                  /**** 自定义控件值得获取可在这里输入,例如：
                 * 
                 * student.ID = gvData.DataKeys[rowIndex].Values["cniid"] as int?,
                 * student.ClassID = gvData.DataKeys[rowIndex].Values["cniclassid"] as int?
                 * 
                 * ****/

                //获取BM详细数据
                _classBM = new CommonBL().GetOne(_classBM).Result;
                if (_classBM == null)
                {
                    return;
                }
                ViewState["_classBM"] = _classBM;// 保存对象主键信息

                base.SetTxbValue(_classBM, "txbNew");//绑定对象值到txbbox，
                
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