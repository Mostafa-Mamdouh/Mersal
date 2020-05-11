#region Using ...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace MersalAccountingService.Core.Models.ViewModels
{
	[Obsolete]
	[DebuggerDisplay("Id={Id}")]
	public class UserLoggedInViewModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public long Id { get; set; }
        public string UserName { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
        public string FirstName { get; set; }
        public string FirstNameOther { get; set; }
        public string MiddleName { get; set; }
        public string MiddleNameOther { get; set; }
        public string LastName { get; set; }
        public string LastNameOther { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string LocationId { get; set; }
        public string Privileges { get; set; }
        public string MenuItems { get; set; }
        public List<int?> Permissions { get; set; }
		public long? BranchId { get; set; }

        public IList<SidebarMenuItemLightViewModel> MenuItemList { get; set; }

        public IList<MersalPrivilegeViewModel> PrivilegeList { get; set; }
        //public IList<MersalMenuItemViewModel> MenuItemList { get; set; }

        public DateTime? issued { get; set; }
        public DateTime? expires { get; set; }
    }
}
