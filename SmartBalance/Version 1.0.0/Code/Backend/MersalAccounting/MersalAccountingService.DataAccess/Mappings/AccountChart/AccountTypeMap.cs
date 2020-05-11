#region Using ...
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Mappings
{
	public class AccountTypeMap : EntityTypeConfiguration<AccountType>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// AccountTypeMap.
		/// </summary>
		public AccountTypeMap()
		{
			#region Configure Relations For Foreign Key ParentKeyAccountTypeId
			this.HasMany(entity => entity.ChildTranslatedAccountTypes)
					.WithOptional(entity => entity.ParentKeyAccountType)
					.HasForeignKey(entity => entity.ParentKeyAccountTypeId);
			#endregion
		}
		#endregion
	}
}
