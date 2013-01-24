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
   [Table(Name = "tbStudent")]
   public class StudentBM :BaseClass<StudentBM>
   {
      /// <summary>
      /// ID
      /// </summary>
      [IgnoreNulls(MessageTemplate = "ID可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cniID",DbType="int" , Storage ="cniID"
      ,IsPrimaryKey = true,IsDbGenerated=true     )]
      public int? M_ID { get; set; }
      /// <summary>
      /// CLASSID
      /// </summary>
      [NotNullValidator(MessageTemplate = "CLASSI不可为空!")]
      [ValidatorComposition(CompositionType.And)]
      [Column(Name="cniClassID",DbType="int" , Storage =""
     )]
      public int? M_ClassID { get; set; }
      /// <summary>
      /// SID1
      /// </summary>
      [NotNullValidator(MessageTemplate = "SID1不可为空!")]
      [ValidatorComposition(CompositionType.And)]
      [StringLengthValidator(0, 50,
          MessageTemplate = "SID1的长度必须在{3}-{5}之间!")]
      [Column(Name="cnvcSID",DbType="nvarchar" , Storage =""
     )]
      public string M_SID { get; set; }
      /// <summary>
      /// 密码
      /// </summary>
      [IgnoreNulls(MessageTemplate = "密码可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [StringLengthValidator(0, 256,
          MessageTemplate = "密码的长度必须在{3}-{5}之间!")]
      [Column(Name="cnvcPassword",DbType="nvarchar" , Storage =""
     )]
      public string M_Password { get; set; }
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
      /// <summary>
      /// $性别$1为男,0为女
      /// </summary>
      [IgnoreNulls(MessageTemplate = "性别可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cniSex",DbType="int" , Storage =""
     )]
      public int? M_Sex { get; set; }
      /// <summary>
      /// 生日
      /// </summary>
      [IgnoreNulls(MessageTemplate = "生日可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [DateTimeRangeValidator("1753-01-01T00:00:00", RangeBoundaryType.Inclusive, null, 
          RangeBoundaryType.Ignore)]
      [Column(Name="cndBirthday",DbType="datetime" , Storage =""
     )]
      public DateTime? M_Birthday { get; set; }
      /// <summary>
      /// 邮箱
      /// </summary>
      [IgnoreNulls(MessageTemplate = "邮箱可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [StringLengthValidator(0, 100,
          MessageTemplate = "邮箱的长度必须在{3}-{5}之间!")]
      [Column(Name="cnvcEmail",DbType="nvarchar" , Storage =""
     )]
      public string M_Email { get; set; }
      /// <summary>
      /// 是否管理员
      /// </summary>
      [IgnoreNulls(MessageTemplate = "是否管理员可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cniIsAdmin",DbType="int" , Storage =""
     )]
      public int? M_IsAdmin { get; set; }
      /// <summary>
      /// 是否有效
      /// </summary>
      [IgnoreNulls(MessageTemplate = "是否有效可为空!")]
      [ValidatorComposition(CompositionType.Or)]
      [Column(Name="cniValid",DbType="int" , Storage =""
     )]
      public int? M_Valid { get; set; }
   }
}
