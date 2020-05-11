#region Using ...
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, Date={Date}")]
	public class ListBrandsLightViewModel : BaseViewModel
	{
		#region Properties
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		#endregion
	}
}
