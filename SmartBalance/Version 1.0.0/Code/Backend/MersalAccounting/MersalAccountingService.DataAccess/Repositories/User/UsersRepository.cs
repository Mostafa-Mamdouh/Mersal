#region Using ...
using Framework.DataAccess.Repositories.Base;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.DataAccess.Contexts;
using MersalAccountingService.DataAccess.Repositories.Base;
using MersalAccountingService.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MersalAccountingService.DataAccess.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersRepository : BaseServiceRepository<User, long>, IUsersRepository
    {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of 
		/// type UsersRepository.
		/// </summary>
		/// <param name="context"></param>
		public UsersRepository(MersalAccountingContext context)
            : base(context)
        {

        }
        #endregion


        public User Login(string userName)
        {
            //password = HashPassword(password);
            return this.Entities.FirstOrDefault(x => x.UserName == userName );
            
        }


        

    }
}
