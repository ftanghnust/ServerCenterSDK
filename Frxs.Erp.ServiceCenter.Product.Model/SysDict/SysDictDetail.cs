using System;
namespace Frxs.Erp.ServiceCenter.Product.Model
{
	/// <summary>
	/// 数据字典明细表
	/// </summary>
	[Serializable]
    public partial class SysDictDetail : BaseModel
	{
		public SysDictDetail()
		{}
		#region Model
		private int _id;
		private string _dictvalue;
		private string _dictlabel;	
		private string _remark;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 对应各个表的值(字典值)
		/// </summary>
		public string DictValue
		{
			set{ _dictvalue=value;}
			get{return _dictvalue;}
		}
		/// <summary>
		/// 显示用 标签名称(同一个字典不能重复)
		/// </summary>
		public string DictLabel
		{
			set{ _dictlabel=value;}
			get{return _dictlabel;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

