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
	[DebuggerDisplay("Id={Id}, Code={Code}, Name={Name}, Date={Date}")]
	public class ListUsersLightViewModel : BaseViewModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public bool IsActive { get; set; }
		public DateTime? BirthDate { get; set; }
		public int? Gender { get; set; }
		public decimal? MaxPaymentLimit { get; set; }
	}
}
