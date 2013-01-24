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
   [Table(Name = "tbClass")]
   public class ClassBM :BaseClass<ClassBM>
   {
      /// <summary>
      /// ClassID
      /// </summary>
      [IgnoreNulls(MessageTemplate = "ClassI可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cniClassID",DbType="int" , Storage ="cniClassID"
      ,IsPrimaryKey = true,IsDbGenerated=true     )]
      public int? M_ClassID { get; set; }
      /// <summary>
      /// 名字
      /// </summary>
      [IgnoreNulls(MessageTemplate = "名字可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [StringLengthValidator(0, 50,
          MessageTemplate = "名字的长度必须在{3}-{5}之间!")]
      [Column(Name="cnvcName",DbType="nvarchar" , Storage =""
     )]
      public string M_Name { get; set; }
   }
}
