#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace MersalAccountingService.Entities.Entity
{
	/// <summary>
	/// Provides a Location entity.
	/// </summary>
	[DebuggerDisplay("Id={Id}, Code={Code}, Title={Title}, Date={Date}")]
	/*
	 * @EntityDescription: 
	 * اماكن الاصول
	 */
	public class Location : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type Location.
        /// </summary>
        public Location()
        {
            this.AssetLocations = new HashSet<AssetLocation>();
            this.ChildLocations = new HashSet<Location>();
            this.ChildTranslatedLocations = new HashSet<Location>();
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


        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }


        public long? ParentLocationId { get; set; }
        public virtual Location ParentLocation { get; set; }


        public virtual ICollection<Location> ChildLocations { get; set; }

        public virtual ICollection<AssetLocation> AssetLocations { get; set; }


        #region Translation Functionality
        public Language? Language { get; set; }

		public long? ParentKeyLocationId { get; set; }
		public virtual Location ParentKeyLocation { get; set; }


		public virtual ICollection<Location> ChildTranslatedLocations { get; set; }
		#endregion

		#endregion
	}
}
