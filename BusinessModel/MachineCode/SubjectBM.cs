using System;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using HNAS.Framework4.Validation.Validators;
using HNAS.Framework4.Validation;

namespace Demo.BusinessModel.MachineCode
{
   /// <summary>
   ///
   /// </summary>
   /// Copyright (c) 2012-2015 海南海航航空信息系统有限公司
   /// 创 建 人：HNAS Framework 4.0 项目组
   /// 创建日期：2012-03-15
   /// 修 改 人：
   /// 修改日期：
   /// 版 本：1.0

   [Serializable]
   [Table(Name = "tbSubject")]
   public class SubjectBM :BaseClass<SubjectBM>
   {
      /// <summary>
      /// cnuID
      /// </summary>
      [IgnoreNulls(MessageTemplate = "cnuID可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cnuID",DbType="uniqueidentifier" , Storage ="cnuID"
      ,IsPrimaryKey = true     )]
      public Guid? M_cnuID { get; set; }
      /// <summary>
      /// Name
      /// </summary>
      [IgnoreNulls(MessageTemplate = "Name可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [StringLengthValidator(0, 50,
          MessageTemplate = "Name的长度必须在{3}-{5}之间!")]
      [Column(Name="cnvcName",DbType="nvarchar" , Storage =""
     )]
      public string M_Name { get; set; }
      /// <summary>
      /// Score
      /// </summary>
      [IgnoreNulls(MessageTemplate = "Score可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cnfScore",DbType="float" , Storage =""
     )]
      public double? M_Score { get; set; }
   }
}
