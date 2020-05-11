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

namespace MersalAccountingService.Core.Models.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	[DebuggerDisplay("Id={Id}")]
	public class BrandViewModel : BaseViewModel
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

		#region IEntityUserSignature		
		public long? CreatedByUserId { get; set; }
		public long? FirstModifiedByUserId { get; set; }
		public long? LastModifiedByUserId { get; set; }
		#endregion

		public string Code { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? Date { get; set; }
		public string DisplyedName { get; set; }


		public string NameAr { get; set; }
		public string NameEn { get; set; }

		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }


		public IList<ProductViewModel> Products { get; set; }

		public long? ParentBrandId { get; set; }
		public string ParentBrandName { get; set; }

		public virtual ICollection<BrandViewModel> ChildBrands { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyBrandId { get; set; }
		public virtual BrandViewModel ParentKeyBrand { get; set; }


		public IList<BrandViewModel> ChildTranslatedBrands { get; set; }
		#endregion

		#endregion
	}
}
