#region Using ...
using Framework.Common.Enums;
using Framework.Core.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels.LightViewModels
{
	/// <summary>
	/// Provides a lite model for entity 
	/// Currency, and this lite model 
	/// do not contains a children 
	/// relations for speeding up the 
	/// retrivement process.
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class CurrencyLightViewModel : BaseViewModel
	{
		#region Properties

		#region IEntityIdentity<T>
		public long Id { get; set; }
		#endregion

		#region IEntityDateTime
		public DateTime CreationDate { get; set; }
		public DateTime? FirstModificationDate { get; set; }
		public DateTime? LastModificationDate { get; set; }
		#endregion

		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public string Symbol { get; set; }
        public string DisplyedName { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyCurrencyId { get; set; }
		public  CurrencyLightViewModel ParentKeyCurrency { get; set; }
		#endregion

		#endregion
	}
}
