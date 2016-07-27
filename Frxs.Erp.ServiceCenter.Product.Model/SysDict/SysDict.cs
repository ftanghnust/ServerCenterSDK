using System;
namespace Frxs.Erp.ServiceCenter.Product.Model
{
	/// <summary>
	/// 数据字典表
	/// </summary>
	[Serializable]
    public partial class SysDict : BaseModel
	{
		public SysDict()
		{}
		#region Model
		private string _dictcode;
		private string _dictname;
		private int _dicttype;
		private int? _isdeleted;
		private string _remark;
		private DateTime _createtime;
		private int? _createuserid;
		private string _createusername;
		private DateTime? _modifytime;
		private int? _modifyuserid;
		private string _modifyusername;
		/// <summary>
		/// 数据字典编号(手工输入，用表名加字段名标识)
		/// </summary>
		public string DictCode
		{
			set{ _dictcode=value;}
			get{return _dictcode;}
		}
		/// <summary>
		/// 数据字段名称
		/// </summary>
		public string DictName
		{
			set{ _dictname=value;}
			get{return _dictname;}
		}
		/// <summary>
		/// 字段类型(0:用户不能修改;1:用户可以修改)
		/// </summary>
		public int DictType
		{
			set{ _dicttype=value;}
			get{return _dicttype;}
		}
		/// <summary>
		/// 删除标识(0:未删除;1:已删除)
		/// </summary>
		public int? IsDeleted
		{
			set{ _isdeleted=value;}
			get{return _isdeleted;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 创建用户ID
		/// </summary>
		public int? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 创建用户名称
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 最新修改删除时间
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 最后修改删除用户ID
		/// </summary>
		public int? ModifyUserID
		{
			set{ _modifyuserid=value;}
			get{return _modifyuserid;}
		}
		/// <summary>
		/// 最后修改删除用户名称
		/// </summary>
		public string ModifyUserName
		{
			set{ _modifyusername=value;}
			get{return _modifyusername;}
		}
		#endregion Model

	}
}

