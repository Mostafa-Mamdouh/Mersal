#region Using ...
using Framework.Common.Enums;
using Framework.Common.Interfaces;
using MersalAccountingService.Common.Enums;
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
    /// Provides a MenuItem entity.
    /// </summary>
    [DebuggerDisplay("Id={Id}, Name={Name}")]
    /*
	 * @EntityDescription: 
	 * 
	 */
    public class MenuItem : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        #region Data Members

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type MenuItem.
        /// </summary>
        public MenuItem()
        {
            this.ChildTranslatedMenuItems = new HashSet<MenuItem>();
            this.ChildMenuItems = new HashSet<MenuItem>();
            this.UserMenuItems = new HashSet<UserMenuItem>();
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
        public string Title { get; set; }
        public string ResourceKey { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string AreaName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string URL { get; set; }
        public string RootUrl { get; set; }
        public string OnErrorGoToURL { get; set; }
        public Nullable<long> ApplicationId { get; set; }
        public string Icon { get; set; }
        public int? ItemOrder { get; set; }
        public bool? AllowAnonymous { get; set; }

        public Nullable<long> ParentMenuItemId { get; set; }
        public MenuItem ParentMenuItem { get; set; }


        public virtual ICollection<MenuItem> ChildMenuItems { get; set; }
        public virtual ICollection<UserMenuItem> UserMenuItems { get; set; }

        #region Translation Functionality
        public Language? Language { get; set; }

        public long? ParentKeyMenuItemId { get; set; }
        public virtual MenuItem ParentKeyMenuItem { get; set; }


        public virtual ICollection<MenuItem> ChildTranslatedMenuItems { get; set; }
        #endregion

        #endregion
    }
}
