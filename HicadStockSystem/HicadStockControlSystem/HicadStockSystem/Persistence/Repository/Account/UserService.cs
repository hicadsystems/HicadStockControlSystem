using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Models;
using HicadStockSystem.Core;
using HicadStockSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HicadStockSystem.Persistence.Repository.Account
{
    public class UserService : IUserRepo
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserRepo _userRepo;
        public UserService(UserManager<User> userManager, IUnitOfWork unitOfWork, StockControlDBContext dbcontext, UserRepo userRepo)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
            _userRepo = userRepo;
        }

        public async Task<ResponseModel<User>> CreateUser(User user, IEnumerable<int> roles, string password, int? device)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {

                try
                {
                    if (roles != null && roles.Count() > 0)
                    {
                        AddRoleAndDevice(user.Id, roles, device);
                        await unitOfWork.CompleteAsync();
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
                return user.ToResponse("successfully created user", true);
            }

            return user.ToResponse(result.Errors.ToString(), false);
            
        }

        private void AddRoleAndDevice(int userId, IEnumerable<int> roles, int? device)
        {
            var userRoles = new List<UserRole>();
            foreach (var role in roles)
            {
                userRoles.Add(new UserRole
                {
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    UserId = userId,
                    RoleId = role,
                });
            }
            _dbcontext.UserRoles.AddRange(userRoles);
          
        }

        public async Task<IdentityResult> UpdateUser(User user)
        {
            return await userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> UpdateUserInfo(User user, IEnumerable<int> roles, int? device)
        {
            var userRoles = _dbcontext.UserRoles.Where(x => x.UserId == user.Id);
            try
            {
                
                _dbcontext.UserRoles.RemoveRange(userRoles);
                AddRoleAndDevice(user.Id, roles, device);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {

                throw;
            }

           
            return await userManager.UpdateAsync(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User> GetUserWithRoles(int id)
        {
            return await _userRepo.UserWithRoles(x => x.Id == id);
        }

        public async Task<User> GetUserWithRolesAndMenus(int id)
        {
            return await _userRepo.UserWithRolesandMenus(x => x.Id == id);
        }
        public IEnumerable<User> GetUsers()
        {
            return _dbcontext.Users.ToList();
        }


        public async Task<User> GetUserRolesDevices(int id)
        {
            return await _userRepo.User(x => x.Id == id);
        }

        public async Task<User> GetUserByResetCode(string resetcode)
        {
            return await _userRepo.User(x => x.Password == resetcode);
        }

        public async Task<User> GetUserByUserName(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
    }
}
