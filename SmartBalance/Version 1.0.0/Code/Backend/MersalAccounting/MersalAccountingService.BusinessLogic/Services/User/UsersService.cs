#region Using ...
using Framework.Common.Enums;
using Framework.Common.Exceptions;
using Framework.Core.Common;
using Framework.Core.Filters;
using Framework.Core.IRepositories;
using Framework.Core.Models.ViewModels;
using MersalAccountingService.Common.Enums;
using MersalAccountingService.Common.Exceptions;
using MersalAccountingService.Core.AutoMapperConfig;
using MersalAccountingService.Core.Common;
using MersalAccountingService.Core.IRepositories;
using MersalAccountingService.Core.IServices;
using MersalAccountingService.Core.Models.ViewModels;
using MersalAccountingService.Core.Models.ViewModels.LightViewModels;
using MersalAccountingService.Entities.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
#endregion

namespace MersalAccountingService.BusinessLogic.Services
{
    /// <summary>
    /// Provides User service for 
    /// business functionality.
    /// </summary>
    public class UsersService : IUsersService
    {
        #region Data Members
        private readonly IMobilesRepository _MobilesRepository;
        private readonly IMailsRepository _MailsRepository;
        private readonly IAddresssRepository _AddresssRepository;
        private readonly IUsersRepository _UsersRepository;
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IUserGroupsRepository _userGroupsRepository;
        private readonly IUserPermissionsRepository _UserPermissionsRepository;
        private readonly IUserPermissionsService _UserPermissionsService;
        private readonly IUserMenuItemsRepository _userMenuItemsRepository;
        private readonly IBranchsRepository _branchsRepository;
        private readonly IUserBranchsRepository _userBranchsRepository;
        private readonly ILanguageService _languageService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of 
        /// type UsersService.
        /// </summary>
        /// <param name="UsersRepository"></param>
        /// <param name="unitOfWork"></param>
        public UsersService(
            IMobilesRepository MobilesRepository,
            IMailsRepository MailsRepository,
            IAddresssRepository AddresssRepository,
            IUsersRepository UsersRepository,
            IUserRolesRepository userRolesRepository,
            IUserGroupsRepository userGroupsRepository,
            IUserPermissionsRepository UserPermissionsRepository,
            IUserPermissionsService UserPermissionsService,
            IUserMenuItemsRepository userMenuItemsRepository,
            IBranchsRepository branchsRepository,
            IUserBranchsRepository userBranchsRepository,
            ILanguageService languageService,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
        {
            this._MobilesRepository = MobilesRepository;
            this._MailsRepository = MailsRepository;
            this._AddresssRepository = AddresssRepository;
            this._UsersRepository = UsersRepository;
            this._userRolesRepository = userRolesRepository;
            this._userGroupsRepository = userGroupsRepository;
            this._UserPermissionsRepository = UserPermissionsRepository;
            this._UserPermissionsService = UserPermissionsService;
            this._userMenuItemsRepository = userMenuItemsRepository;
            this._branchsRepository = branchsRepository;
            this._userBranchsRepository = userBranchsRepository;
            this._languageService = languageService;
            this._currentUserService = currentUserService;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Throw an exception if name is exist.
        /// </summary>
        /// <param name="model">User view model</param>
        public void ThrowExceptionIfExist(UserViewModel model)
        {
            ConditionFilter<User, long> condition = new ConditionFilter<User, long>
            {
                Query = (entity =>
                    entity.UserName == model.UserName &&
                    entity.Id != model.Id)
            };
            var existEntity = this._UsersRepository.Get(condition).FirstOrDefault();

            if (existEntity != null)
                throw new ItemAlreadyExistException((int)ErrorCodeEnum.UserNameAlreadyExist);
        }
        public void ThrowExceptionIfExistEmail(UserViewModel model)
        {
            if (model.Email != null)
            {
                Mail mail = this._MailsRepository.Get().FirstOrDefault(x =>
                    x.Email == model.Email &&
                    x.ObjectId != model.Id &&
                    x.ObjectType == ObjectType.User);

                if (mail != null)
                {
                    throw new ItemAlreadyExistException((int)ErrorCodeEnum.EmailAlreadyExist);
                }
            }
        }
        public void ThrowExceptionIfExistMobile(UserViewModel model)
        {
            if (model.Phone != null)
            {
                Mobile phone = this._MobilesRepository.Get().FirstOrDefault(x =>
                    x.Number == model.Phone &&
                    x.ObjectId != model.Id &&
                    x.ObjectType == ObjectType.User);

                if (phone != null)
                {
                    throw new ItemAlreadyExistException((int)ErrorCodeEnum.PhoneAlreadyExist);
                }
            }
        }

        public bool GetHasPermissionToChangePostedAccounts()
        {
            bool result = false;
            var userId = this._currentUserService.CurrentUserId;

            if (userId.HasValue)
            {
                var permission = this._UserPermissionsRepository.Get(null).Where(x =>
                    x.UserId == userId &&
                    x.PermissionId.HasValue &&
                    x.Permission.IsActive &&
                    x.Permission.Code == (int)Permissions.ControlPostingJournalEntries).FirstOrDefault();

                result = (permission != null);

                if (result == false)
                {
                    var role = this._userRolesRepository.Get(null).Where(x =>
                        x.UserId == userId &&
                        x.RoleId.HasValue &&
                        x.Role.IsActive &&
                        x.Role.RolePermissions.FirstOrDefault(y =>
                            y.Permission.IsActive &&
                            y.Permission.Code == (int)Permissions.ControlPostingJournalEntries) != null
                            );

                    result = (role != null);
                }
            }

            return result;
        }

        public decimal? GetMaxPaymentLimit(long userId)
        {
            var user = this._UsersRepository.Get(userId);
            return user.MaxPaymentLimit;
        }

        public decimal? GetMaxPaymentLimitForCurrentUser()
        {
            long? userId = this._currentUserService.CurrentUserId;
            var user = this._UsersRepository.Get(userId.Value);
            return user.MaxPaymentLimit;
        }

        public BranchLightViewModel GetUserBranch(long userId)
        {
            var user = this._UsersRepository.Get(userId);

            if (user.UserBranches.Count > 0)
            {
                if (user.UserBranches != null)
                    return user.UserBranches.FirstOrDefault().Branch.ToLightModel();
                //else
                //{
                //    var entity = this._branchsRepository.Get(user.BranchId.Value);
                //    return entity.ToLightModel();
                //}
            }

            return null;
        }
        public BranchLightViewModel GetCurrentUserBranch()
        {
            var userId = this._currentUserService.CurrentUserId;

            if (userId.HasValue)
            {
                var user = this._UsersRepository.Get(userId.Value);

                var branch = user.UserBranches.FirstOrDefault().Branch;

                if (branch != null)
                    return branch.ToLightModel();
                //if (user.BranchId.HasValue)
                //{
                //    if (user.Branch != null)
                //        return user.Branch.ToLightModel();
                //    else
                //    {
                //        var entity = this._branchsRepository.Get(user.BranchId.Value);
                //        return entity.ToLightModel();
                //    }
                //}
            }

            return null;
        }


        public bool IsUserHassPermission(long? userId, Permissions permissionItem)
        {
            var permisstion = this._UserPermissionsRepository
                .Get(null)
                .Where(x =>
                    x.UserId == userId &&
                    x.Permission.Code == (int)permissionItem &&
                    x.Permission.IsActive)
                .FirstOrDefault();

            return (permisstion != null);
        }

        public bool IsCurrentUserHassPermission(Permissions permissionItem)
        {
            var userId = this._currentUserService.CurrentUserId;
            var result = this.IsUserHassPermission(userId, permissionItem);
            return result;
        }




        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserViewModel> Get(ConditionFilter<User, long> condition)
        {
            var entityCollection = this._UsersRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<UserViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserViewModel> Get(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<User, long> condition = new ConditionFilter<User, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._UsersRepository.Get(condition).ToList();
            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            var result = new GenericCollectionViewModel<UserViewModel>
            {
                Collection = modelCollection,
                TotalCount = modelCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by condition.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserLightViewModel> GetLightModel(ConditionFilter<User, long> condition)
        {
            var entityCollection = this._UsersRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<UserLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = condition.PageIndex,
                PageSize = condition.PageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a GenericCollectionViewModel of UserViewModel by pagination.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public GenericCollectionViewModel<UserLightViewModel> GetLightModel(int? pageIndex, int? pageSize)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<User, long> condition = new ConditionFilter<User, long>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = (item =>
                    item.Language == lang)
            };
            var entityCollection = this._UsersRepository.Get(condition).ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToLightModel()).ToList();
            var result = new GenericCollectionViewModel<UserLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = dtoCollection.Count,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return result;
        }

        /// <summary>
        /// Gets a UserViewModel by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserViewModel Get(long id)
        {
            var entity = this._UsersRepository.Get(id);
            var model = entity.ToModel();

            Mail mail = this._MailsRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.User);
            if (mail != null) model.Email = mail.Email;

            Mobile phone = this._MobilesRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.User);
            if (phone != null) model.Phone = phone.Number;

            Address address = this._AddresssRepository.Get().FirstOrDefault(x => x.ObjectId == entity.Id && x.ObjectType == ObjectType.User);
            if (address != null) model.Address = address.Description;

            return model;
        }

        public GenericCollectionViewModel<ListUsersLightViewModel> GetByFilter(UserFilterViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            ConditionFilter<User, long> condition = new ConditionFilter<User, long>()
            {
                Order = Order.Descending
            };

            if (model.Sort?.Count > 0)
            {
                if (model.Sort[0].Dir != "desc") condition.Order = Order.Ascending;
            }

            ////if (model.DateFrom.HasValue) model.DateFrom = model.DateFrom.SetTimeToNow();
            //if (model.DateTo.HasValue) model.DateTo = model.DateTo.SetTimeToNow();

            // The IQueryable data to query.  
            IQueryable<User> queryableData = this._UsersRepository.Get(condition);

            queryableData = queryableData.Where(x => x.Language == lang && x.ParentKeyUser != null);

            if (string.IsNullOrEmpty(model.UserName) == false)
                queryableData = queryableData.Where(x => x.ParentKeyUser.UserName.Contains(model.UserName));

            if (string.IsNullOrEmpty(model.Name) == false)
                queryableData = queryableData.Where(x => x.Name != null && x.Name.Contains(model.Name));

            if (model.IsActive.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyUser.IsActive == model.IsActive.Value);

            if (model.BirthDateFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyUser.BirthDate >= model.BirthDateFrom.Value);

            if (model.BirthDateTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyUser.BirthDate <= model.BirthDateTo.Value);

            if (model.MaxPaymentLimitFrom.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyUser.MaxPaymentLimit >= model.MaxPaymentLimitFrom.Value);

            if (model.MaxPaymentLimitTo.HasValue)
                queryableData = queryableData.Where(x => x.ParentKeyUser.MaxPaymentLimit <= model.MaxPaymentLimitTo.Value);


            var entityCollection = queryableData.ToList();
            var dtoCollection = entityCollection.Select(entity => entity.ToListModel()).ToList();

            //foreach (var item in entityCollection)
            //{
            //	var ViewModel = dtoCollection.Find(x => x.Id == item.ParentKeyUserId.Value);
            //	//ViewModel.Amount = item.Amount.ToString() + " " + item.Currency.ChildTranslatedCurrencys.FirstOrDefault(z => z.Language == lang).Name;
            //	//if (item.ParentKeyBankMovement.Bank != null)
            //	//{
            //	//	ViewModel.BankName = item.ParentKeyBankMovement.Bank.ChildTranslatedBanks.First(x => x.Language == lang).Name;
            //	//}
            //	//if (item.ParentKeyBankMovement.JournalType != null)
            //	//{
            //	//	ViewModel.JournalTypeName = item.ParentKeyBankMovement.JournalType.ChildTranslatedJournalTypes.First(x => x.Language == lang).Name; ;
            //	//}
            //}

            var total = dtoCollection.Count();
            dtoCollection = dtoCollection.Skip(model.PageIndex * model.PageSize).Take(model.PageSize).ToList();
            var result = new GenericCollectionViewModel<ListUsersLightViewModel>
            {
                Collection = dtoCollection,
                TotalCount = total,
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };

            return result;
        }

        /// <summary>
        /// Add entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<UserViewModel> Add(IEnumerable<UserViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._UsersRepository.Add(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserViewModel Add(UserViewModel model)
        {
            this.ThrowExceptionIfExist(model);
            this.ThrowExceptionIfExistEmail(model);
            this.ThrowExceptionIfExistMobile(model);

            var entity = model.ToEntity();
            entity.Password = HashPassword(entity.Password);
            entity.Name = null;
            entity = this._UsersRepository.Add(entity);

            User entityAR = new User
            {
                Id = entity.Id,
                Name = model.NameAr,
                Language = Language.Arabic
            };
            entity.ChildTranslatedUsers.Add(entityAR);
            this._UsersRepository.Add(entityAR);

            User entityEn = new User
            {
                Id = entity.Id,
                Name = model.NameEn,
                Language = Language.English
            };
            entity.ChildTranslatedUsers.Add(entityEn);
            this._UsersRepository.Add(entityEn);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            bool needCommit = false;
            if (model.Email != null)
            {
                Mail newMail = new Mail
                {
                    Email = model.Email,
                    IsActive = true,
                    IsMain = true,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.User
                };
                this._MailsRepository.Add(newMail);
                needCommit = true;
            }

            if (model.Phone != null)
            {
                Mobile newMobile = new Mobile
                {
                    Number = model.Phone,
                    IsActive = true,
                    IsMain = true,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.User
                };
                this._MobilesRepository.Add(newMobile);
                needCommit = true;
            }

            if (model.Address != null)
            {
                Address newAddress = new Address
                {
                    Description = model.Address,
                    IsActive = true,
                    IsMain = true,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.User
                };
                this._AddresssRepository.Add(newAddress);
                needCommit = true;
            }

            if (needCommit) this._unitOfWork.Commit();

            model = entity.ToModel();
            return model;
        }



        /// <summary>
        /// Update entities.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IList<UserViewModel> Update(IEnumerable<UserViewModel> collection)
        {
            foreach (var model in collection)
            {
                this.ThrowExceptionIfExist(model);
            }

            var entityCollection = collection.Select(model => model.ToEntity());
            entityCollection = this._UsersRepository.Update(entityCollection).ToList();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            var modelCollection = entityCollection.Select(entity => entity.ToModel()).ToList();
            return modelCollection;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserViewModel Update(UserViewModel model)
        {
            this.ThrowExceptionIfExist(model);
            this.ThrowExceptionIfExistEmail(model);
            this.ThrowExceptionIfExistMobile(model);

            //var entity = model.ToEntity();
            var entity = this._UsersRepository.Get(model.Id);

            var currentUserId = this._currentUserService.CurrentUserId;
            if (model.Id != currentUserId)
            {
                entity.IsActive = model.IsActive;
            }
            else if (model.Id == currentUserId &&
                    entity.IsActive != model.IsActive)
            {
                throw new GeneralException((int)ErrorCodeEnum.CurrentUserCannotDiactivateHimself);
            }

            entity.BirthDate = model.BirthDate;
            entity.DefaultPageUrl = model.DefaultPageUrl;
            entity.Gender = model.Gender;
            entity.MaxPaymentLimit = model.MaxPaymentLimit;
            entity.UserName = model.UserName;
            //entity.BranchId = model.BranchId;

            entity = this._UsersRepository.Update(entity);


            var childs = this._UsersRepository.Get(null).Where(x =>
                x.ParentKeyUserId == entity.Id);

            if (childs.Count() > 0)
            {
                var ar = childs.FirstOrDefault(x => x.Language == Language.Arabic);
                ar.Name = model.NameAr;
                this._UsersRepository.Update(ar);

                var en = childs.FirstOrDefault(x => x.Language == Language.English);
                en.Name = model.NameEn;
                this._UsersRepository.Update(en);
            }


            Mobile mobile = this._MobilesRepository.Get().FirstOrDefault(x =>
                x.ObjectId == entity.Id &&
                x.ObjectType == ObjectType.User);
            if (mobile != null)
            {
                mobile.Number = model.Phone;
                this._MobilesRepository.Update(mobile);
            }
            else
            {
                Mobile newMobile = new Mobile
                {
                    Number = model.Phone,
                    IsActive = true,
                    IsMain = true,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.User
                };
                this._MobilesRepository.Add(newMobile);
            }


            Mail mail = this._MailsRepository.Get().FirstOrDefault(x =>
                x.ObjectId == entity.Id &&
                x.ObjectType == ObjectType.User);
            if (mail != null)
            {
                mail.Email = model.Email;
                this._MailsRepository.Update(mail);
            }
            else
            {
                Mail newMail = new Mail
                {
                    Email = model.Email,
                    IsActive = true,
                    IsMain = true,
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.User
                };
                this._MailsRepository.Add(newMail);
            }

            Address address = this._AddresssRepository.Get().FirstOrDefault(x =>
                x.ObjectId == entity.Id &&
                x.ObjectType == ObjectType.User);
            if (address != null)
            {
                address.Description = model.Address;
                this._AddresssRepository.Update(address);
            }
            else
            {
                address = new Address
                {
                    ObjectId = entity.Id,
                    ObjectType = ObjectType.User,
                    Description = model.Address,
                    IsActive = true,
                    IsMain = true
                };
                this._AddresssRepository.Add(address);
            }

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion

            model = entity.ToModel();
            return model;
        }


        public UserPermissionListViewModel GetUserPermission(long userId)
        {
            var lang = this._languageService.CurrentLanguage;
            var entityCollection = this._UserPermissionsRepository.Get(null).Where(x => x.UserId == userId).ToList();

            UserPermissionListViewModel result = new UserPermissionListViewModel
            {
                UserId = userId,
                List = new List<NmaeValueViewModel>()
            };

            foreach (var item in entityCollection)
            {
                result.List.Add(new NmaeValueViewModel
                {
                    Value = item.PermissionId.Value,
                    Name = item.Permission.ChildTranslatedPermissions.FirstOrDefault(x => x.Language == lang).Name
                });
            }
            return result;
        }
        public UserPermissionListViewModel UpdateUserPermission(UserPermissionListViewModel model)
        {
            var currentUserId = this._currentUserService.CurrentUserId;
            if (currentUserId == model.UserId)
            {
                bool userCanChangeHisPermissions = false;
                string userCanChangeHisPermissionsString = ConfigurationManager.AppSettings["UserCanChangeHisPermissions"];

                if (string.IsNullOrEmpty(userCanChangeHisPermissionsString) == false)
                {
                    try
                    {
                        userCanChangeHisPermissions = bool.Parse(userCanChangeHisPermissionsString);
                    }
                    catch
                    {
                        // do nothing at all
                    }
                }

                if (userCanChangeHisPermissions == false)
                {
                    throw new GeneralException((int)ErrorCodeEnum.CurrentUserCannotChangeHisPermissions);
                }
            }

            var entityCollection = this._UserPermissionsRepository.Get(null).Where(x => x.UserId == model.UserId);

            if (entityCollection.Count() > 0)
            {
                foreach (var item in entityCollection)
                {
                    this._UserPermissionsRepository.Delete(item);
                }
                this._unitOfWork.Commit();
            }

            if (model.List?.Count > 0)
            {
                foreach (var item in model.List)
                {
                    UserPermission newEntity = new UserPermission
                    {
                        UserId = model.UserId,
                        PermissionId = item.Value
                    };
                    this._UserPermissionsRepository.Add(newEntity);
                }
                this._unitOfWork.Commit();
            }

            return model;
        }

        public UserRoleListViewModel GetUserRole(long userId)
        {
            var lang = this._languageService.CurrentLanguage;
            var entityCollection = this._userRolesRepository.Get(null).Where(x => x.UserId == userId).ToList();

            UserRoleListViewModel result = new UserRoleListViewModel
            {
                UserId = userId,
                List = new List<NmaeValueViewModel>()
            };

            foreach (var item in entityCollection)
            {
                result.List.Add(new NmaeValueViewModel
                {
                    Value = item.RoleId.Value,
                    Name = item.Role.ChildTranslatedRoles.FirstOrDefault(x => x.Language == lang).Name
                });
            }
            return result;
        }
        public UserRoleListViewModel UpdateUserRole(UserRoleListViewModel model)
        {
            var currentUserId = this._currentUserService.CurrentUserId;
            if (currentUserId == model.UserId)
            {
				bool UserCanChangeHisRoles = false;
				string UserCanChangeHisRolesString = ConfigurationManager.AppSettings["UserCanChangeHisRoles"];

				if (string.IsNullOrEmpty(UserCanChangeHisRolesString) == false)
				{
					try
					{
						UserCanChangeHisRoles = bool.Parse(UserCanChangeHisRolesString);
					}
					catch
					{
						// do nothing at all
					}
				}

				if (UserCanChangeHisRoles == false)
				{
					throw new GeneralException((int)ErrorCodeEnum.CurrentUserCannotChangeHisRoles);
				}
			}

            var entityCollection = this._userRolesRepository.Get(null).Where(x => x.UserId == model.UserId);

            if (entityCollection.Count() > 0)
            {
                foreach (var item in entityCollection)
                {
                    this._userRolesRepository.Delete(item);
                }
                this._unitOfWork.Commit();
            }

            if (model.List?.Count > 0)
            {
                foreach (var item in model.List)
                {
                    UserRole newEntity = new UserRole
                    {
                        UserId = model.UserId,
                        RoleId = item.Value
                    };
                    this._userRolesRepository.Add(newEntity);
                }
                this._unitOfWork.Commit();
            }

            return model;
        }

        public UserGroupListViewModel GetUserGroup(long userId)
        {
            var lang = this._languageService.CurrentLanguage;
            var entityCollection = this._userGroupsRepository.Get(null).Where(x => x.UserId == userId).ToList();

            UserGroupListViewModel result = new UserGroupListViewModel
            {
                UserId = userId,
                List = new List<NmaeValueViewModel>()
            };

            foreach (var item in entityCollection)
            {
                result.List.Add(new NmaeValueViewModel
                {
                    Value = item.GroupId.Value,
                    Name = item.Group.ChildTranslatedGroups.FirstOrDefault(x => x.Language == lang).Name
                });
            }
            return result;
        }
        public UserGroupListViewModel UpdateUserGroup(UserGroupListViewModel model)
        {
            var currentUserId = this._currentUserService.CurrentUserId;
            if (currentUserId == model.UserId)
            {
				bool UserCanChangeHisGroups = false;
				string UserCanChangeHisGroupsString = ConfigurationManager.AppSettings["UserCanChangeHisGroups"];

				if (string.IsNullOrEmpty(UserCanChangeHisGroupsString) == false)
				{
					try
					{
						UserCanChangeHisGroups = bool.Parse(UserCanChangeHisGroupsString);
					}
					catch
					{
						// do nothing at all
					}
				}

				if (UserCanChangeHisGroups == false)
				{
					throw new GeneralException((int)ErrorCodeEnum.CurrentUserCannotChangeHisGroups);
				}
			}

            var entityCollection = this._userGroupsRepository.Get(null).Where(x => x.UserId == model.UserId);

            if (entityCollection.Count() > 0)
            {
                foreach (var item in entityCollection)
                {
                    this._userGroupsRepository.Delete(item);
                }
                this._unitOfWork.Commit();
            }

            if (model.List?.Count > 0)
            {
                foreach (var item in model.List)
                {
                    UserGroup newEntity = new UserGroup
                    {
                        UserId = model.UserId,
                        GroupId = item.Value
                    };
                    this._userGroupsRepository.Add(newEntity);
                }
                this._unitOfWork.Commit();
            }

            return model;
        }

        public UserBranchListViewModel GetUserBranchs(long userId)
        {
            var lang = this._languageService.CurrentLanguage;
            var entityCollection = this._userBranchsRepository.Get(null).Where(x => x.UserId == userId).ToList();

            UserBranchListViewModel result = new UserBranchListViewModel
            {
                UserId = userId,
                List = new List<NmaeValueViewModel>()
            };
            //List<Branch> branchs = new List<Branch>();
            foreach (var item in entityCollection)
            {
                //Branch branch = branchs.FirstOrDefault(x => x.Id == item.BranchId);
                //if(branch == null)
                //{
                //    branch = this._branchsRepository.Get().FirstOrDefault(x => x.Id == item.BranchId);
                //    branchs.Add(branch);
                //}
                result.List.Add(new NmaeValueViewModel
                {
                    Value = item.BranchId.Value,
                    Name = item.Branch.ChildTranslatedBranchs.FirstOrDefault(x => x.Language == lang).Name
                });
            }
            return result;
        }
        public UserBranchListViewModel UpdateUserBranch(UserBranchListViewModel model)
        {
            var currentUserId = this._currentUserService.CurrentUserId;
            if (currentUserId == model.UserId)
            {
                bool userCanChangeHisPermissions = false;
                //string userCanChangeHisPermissionsString = ConfigurationManager.AppSettings["UserCanChangeHisPermissions"];

                //if (string.IsNullOrEmpty(userCanChangeHisPermissionsString) == false)
                //{
                //    try
                //    {
                //        userCanChangeHisPermissions = bool.Parse(userCanChangeHisPermissionsString);
                //    }
                //    catch
                //    {
                //        // do nothing at all
                //    }
                //}

                //if (userCanChangeHisPermissions == false)
                //{
                //    throw new GeneralException((int)ErrorCodeEnum.CurrentUserCannotChangeHisPermissions);
                //}
            }

            var entityCollection = this._userBranchsRepository.Get(null).Where(x => x.UserId == model.UserId);

            if (entityCollection.Count() > 0)
            {
                foreach (var item in entityCollection)
                {
                    this._userBranchsRepository.Delete(item);
                }
                this._unitOfWork.Commit();
            }

            if (model.List?.Count > 0)
            {
                foreach (var item in model.List)
                {
                    UserBranch newEntity = new UserBranch
                    {
                        UserId = model.UserId,
                        BranchId = (int)item.Value
                    };
                    this._userBranchsRepository.Add(newEntity);
                }
                this._unitOfWork.Commit();
            }

            return model;
        }





        /// <summary>
        /// Delete entities.
        /// </summary>
        /// <param name="collection"></param>
        public void Delete(IEnumerable<UserViewModel> collection)
        {
            var entityCollection = collection.Select(model => model.ToEntity());
            this._UsersRepository.Delete(entityCollection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete entities by its id collection.
        /// </summary>
        /// <param name="collection"></param>
        public void Delete(IEnumerable<long> collection)
        {
            this._UsersRepository.Delete(collection);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="model"></param>
        public void Delete(UserViewModel model)
        {
            var entity = model.ToEntity();
            this._UsersRepository.Delete(entity);

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }
        /// <summary>
        /// Delete an entity by id.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            var result = this._UsersRepository.Delete(id);

            if (result == 0)
                throw new ItemNotFoundException();

            #region Commit Changes
            this._unitOfWork.Commit();
            #endregion
        }

        [Obsolete]
        public IList<MersalPrivilegeViewModel> GetUserPrivileges(long userId)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["mersal-user-management-api"];
            RestClient client = new RestClient(url);
            var request = new RestRequest("api/User/GetAllUserPrivilegesByUserId", Method.GET);
            request.AddParameter("userId", userId, ParameterType.QueryString);
            var result = client.Execute<List<MersalPrivilegeViewModel>>(request);

            return result.Data;
        }
        [Obsolete]
        public IList<MersalMenuItemViewModel> GetUserMenuItems(long userId)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["mersal-user-management-api"];
            RestClient client = new RestClient(url);
            var request = new RestRequest("api/User/GetMenuItemsByuserId", Method.GET);
            request.AddParameter("userId", userId, ParameterType.QueryString);
            var result = client.Execute<List<MersalMenuItemViewModel>>(request);

            return result.Data;
        }


        public UserLoggedInViewModel Login(LoginViewModel model)
        {
            var lang = this._languageService.CurrentLanguage;
            if (lang == Language.None) lang = Language.Arabic;

            UserLoggedInViewModel viewModel = new UserLoggedInViewModel();
            var user = this._UsersRepository.Login(model.UserName);
            if (user != null)
            {
                if (VerifyHashedPassword(user.Password, model.Password))
                //if (true)
                {
                    //var permissions = this._UserPermissionsRepository.Get().Where(x => x.UserId == user.Id).ToList();

                    viewModel.Id = user.Id;
                    viewModel.UserName = user.UserName;
                    viewModel.token_type = "Bearer";
                    viewModel.issued = DateTime.Now;
                    viewModel.NameAr = user.ChildTranslatedUsers.FirstOrDefault(x => x.Language == Language.Arabic && x.ParentKeyUserId == user.Id)?.Name;
                    viewModel.NameEn = user.ChildTranslatedUsers.FirstOrDefault(x => x.Language == Language.English && x.ParentKeyUserId == user.Id)?.Name;
                    //viewModel.BranchId = user.BranchId;

                    viewModel.Permissions = this._UserPermissionsRepository.Get()
                        .Where(x => x.UserId == user.Id)
                        .Select(x => x.Permission)
                        .Select(c => c.Code).ToList();

                    var userMenuItems = this._userMenuItemsRepository.Get(null)
                        .OrderBy(m => m.MenuItem.ItemOrder)
                        .Where(x =>
                        x.UserId == user.Id &&
                        x.MenuItem != null &&
                        x.MenuItem.IsActive.HasValue &&
                        x.MenuItem.IsActive.Value == true
                        );

                    IList<SidebarMenuItemLightViewModel> MenuItemList = new List<SidebarMenuItemLightViewModel>();
                    if (userMenuItems?.Count() > 0)
                    {
                        //MenuItemList = userMenuItems.ToList().Select(item => item.MenuItem.ToSidebarLightModel()).ToList();
                        foreach (var item in userMenuItems)
                        {
                            var menuModel = item.MenuItem.ToSidebarLightModel();

                            if (item.MenuItem.ChildMenuItems.Count > 0)
                            {
                                var chileds = item.MenuItem.ChildMenuItems.OrderBy(x => x.ItemOrder).ToList();

                                foreach (var child in chileds)
                                {
                                    if (userMenuItems.FirstOrDefault(x => x.MenuItemId == child.Id) != null)
                                    {
                                        menuModel.ChildMenuItems.Add(child.ToSidebarLightModel());
                                    }
                                }
                            }

                            //if (menuModel?.ChildMenuItems?.Count > 0)
                            //{
                            //    menuModel.ChildMenuItems = item.MenuItem.ChildMenuItems
                            //        .OrderBy(x => x.ItemOrder)
                            //        .ToList().Select(y => y.ToSidebarLightModel()).ToList();
                            //}


                            //    //menuModel.Name = item.MenuItem.ChildTranslatedMenuItems.FirstOrDefault(x =>
                            //    //    x.Language == lang).Name;                       

                            MenuItemList.Add(menuModel);
                        }
                    }

                    //viewModel.PrivilegeList = this._UsersService.GetUserPermission(user.Id);
                    //viewModel.MenuItemList = this._UsersService.GetUserMenuItems(1432);


                    // IList<MersalMenuItemViewModel> MenuItemList = new List<MersalMenuItemViewModel>()
                    //{
                    //    new MersalMenuItemViewModel()
                    //    {
                    //        Id = 3089,
                    //        Name = "menu.home",
                    //        NameOther = "home",
                    //        URL = "home/home",
                    //        IsActive = true,
                    //        ApplicationId = 4,
                    //        ItemOrder = 1
                    //    },
                    //     new MersalMenuItemViewModel()
                    //    {
                    //        Id = 30891,
                    //        Name = "movements.receipts",
                    //        NameOther = "financial",
                    //        URL = "financial/financial-list",
                    //        IsActive = true,
                    //        ApplicationId = 4,
                    //        ItemOrder = 3
                    //    }
                    //};
                    viewModel.MenuItemList = MenuItemList;

                    return viewModel;
                }
                else
                {
                    return null;
                }
            }
            else // login false
            {
                // bad request 
                return null;
            }

        }

        //      public IList<PermissionViewModel> GetUserPermissions(long userId)
        //      {
        //	var collection = this._UserPermissionsRepository.Get(null).Where(x => x.UserId == userId).ToList();
        //	var modelCollection = collection.Select(entity => entity.ToModel()).Select(x => x.Permission).ToList();

        //	return modelCollection;

        //	//ConditionFilter<UserPermission, long> conditionFilter = new ConditionFilter<UserPermission, long>()
        //	//{
        //	//	Query = (x => x.UserId == userId)
        //	//};
        //	//return this._UserPermissionsService.Get(conditionFilter).Collection.Select(x => x.Permission).ToList();
        //}

        private static string HashPassword(string password)
        {
            //return password;

            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        private static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            //return hashedPassword == password;

            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        private static bool ByteArraysEqual(byte[] firstHash, byte[] secondHash)
        {
            int _minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < _minHashLength; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return 0 == xor;
        }

        public void ChangePassword(ChangePasswordViewModel model)
        {
            User user = this._UsersRepository.Get(model.UserId);
            string newPasswordHash = HashPassword(model.NewPassword);
            if (VerifyHashedPassword(user.Password, model.OldPassword))
            {
                user.Password = newPasswordHash;
                this._UsersRepository.Update(user);

                this._unitOfWork.Commit();
            }
            else
            {
                throw new GeneralException((int)ErrorCodeEnum.PasswordIncorrect);
            }
        }

        public void ResetPassword(long userId)
        {
            User user = this._UsersRepository.Get(userId);
            string passwordHash = HashPassword("123456");
            user.Password = passwordHash;
            this._UsersRepository.Update(user);
            this._unitOfWork.Commit();
        }
        #endregion
    }
}
