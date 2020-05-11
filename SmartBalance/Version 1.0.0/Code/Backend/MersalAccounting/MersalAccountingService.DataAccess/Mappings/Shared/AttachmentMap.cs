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
	public class AttachmentMap : EntityTypeConfiguration<Attachment>
	{
		#region Constructors
		/// <summary>
		/// Initialize a new instance of type
		/// AttachmentMap.
		/// </summary>
		public AttachmentMap()
		{
			#region Configure Relations For Foreign Key ParentKeyAttachmentId
			this.HasMany(entity => entity.ChildTranslatedAttachments)
					.WithOptional(entity => entity.ParentKeyAttachment)
					.HasForeignKey(entity => entity.ParentKeyAttachmentId);
			#endregion
		}
		#endregion
	}
}
