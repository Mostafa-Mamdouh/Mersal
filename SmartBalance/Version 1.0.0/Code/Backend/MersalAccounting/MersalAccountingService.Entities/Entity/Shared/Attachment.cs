#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a Attachment entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Name={Name}")]
	/*
	 * @EntityDescription: 
	 * المرفقات
	 */
	public class Attachment : IEntityIdentity<long>, IEntityDateTimeSignature
	{
		#region Data Members

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type Attachment.
		/// </summary>
		public Attachment()
		{
			this.ChildTranslatedAttachments = new HashSet<Attachment>();
		}
		#endregion

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
		public int Type { get; set; }
		public string Description { get; set; }
		public string ObjectType { get; set; }
		public long ObjectId { get; set; }
		public long Size { get; set; }


		#region Translation Functionality
		public Language? Language { get; set; }

		public long? ParentKeyAttachmentId { get; set; }
		public virtual Attachment ParentKeyAttachment { get; set; }


		public virtual ICollection<Attachment> ChildTranslatedAttachments { get; set; }
		#endregion

		#endregion
	}
}
