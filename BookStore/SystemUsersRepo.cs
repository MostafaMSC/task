


using BookStore;
using BookStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class SystemUsersRepo : ISystemUsers
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SystemUsersRepo(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        async Task<bool> ISystemUsers.AddUSerToAdminRole(string UserID)
        {
            try

            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "admin");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
            }

        }

        public async Task<bool> AddUSerToRegularRole(string UserID)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "regulator");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception error)
            {
                return false;
            }
        }


        public async Task<bool> AddUSerToViewAllRole(string UserID)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "admin2");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public async Task<bool> AddUSerToAdmin2Role(string UserID)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "admin2");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception error)
            {
                return false;
            }
        }



        public async Task<bool> AddUSerToJazaeaViewRole(string UserID)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception error)
            {
                return false;
            }
        }




        public async Task<bool> AddUSerToSuperVisorRole(string UserID)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "SuperAdmin");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception error)
            {
                return false;
            }
        }
        public async Task<bool> AddUSerToDawaViewRole(string UserID)
        {
            try
            {
                var User = await _userManager.FindByIdAsync(UserID);
                var ListOfRoles = await _userManager.GetRolesAsync(User);
                if (ListOfRoles.Count == 0)
                {
                    await _userManager.AddToRoleAsync(User, "View");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception error)
            {
                return false;
            }
        }



        public async Task<List<IdentityUser>> GetAllUsers()
        {
            var ListOfAllUsers = await _db.Users.ToListAsync();
            return ListOfAllUsers;
        }

        public async Task<List<AllUSersViewModel>> GetListAllUSersWithRoles()
        {
            var ListOfviewModels = new List<AllUSersViewModel>();
            var ListOfAllUsers = await _db.Users.ToListAsync();
            foreach (var user in ListOfAllUsers)
            {
                var CheckIfHasRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == user.Id);
                if (CheckIfHasRole is null)
                {
                    var viewmodel = new AllUSersViewModel();
                    viewmodel.UserID = user.Id;
                    viewmodel.UserName = user.UserName;
                    viewmodel.Password = user.PasswordHash;
                    viewmodel.Role = "";
                    viewmodel.HasRole = false;
                    ListOfviewModels.Add(viewmodel);


                }
                else
                {
                    var RoleRecord = await _db.Roles.FirstOrDefaultAsync(a => a.Id == CheckIfHasRole.RoleId);
                    var RoleName = RoleRecord.Name;
                    var viewmodel = new AllUSersViewModel();
                    viewmodel.UserID = user.Id;
                    viewmodel.UserName = user.UserName;
                    viewmodel.Password = user.PasswordHash;
                    viewmodel.Role = RoleName;
                    viewmodel.HasRole = true;
                    ListOfviewModels.Add(viewmodel);


                }

            }
            return ListOfviewModels;
        }

        public async Task<bool> EditRoleFromAdminToRegulator(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);

            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            //if (UserRole.ToString == "admin") 
            //{

            //}
            await _userManager.RemoveFromRoleAsync(User, "admin");
            var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
            await _userManager.AddToRoleAsync(User, "regulator");
            UserRole.RoleId = RoleRecored.Id;
            _db.UserRoles.Update(UserRole);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAllRoleToAdmin(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            if (UserRole.RoleId == "SuperAdmin")
            {
                await _userManager.RemoveFromRoleAsync(User, "SuperAdmin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "SuperAdmin");
                await _userManager.AddToRoleAsync(User, "admin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "View")
            {
                await _userManager.RemoveFromRoleAsync(User, "View");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "View");
                await _userManager.AddToRoleAsync(User, "admin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "eatalaJazaea")
            {
                await _userManager.RemoveFromRoleAsync(User, "eatalaJazaea");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "eatalaJazaea");
                await _userManager.AddToRoleAsync(User, "admin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "owner")
            {
                await _userManager.RemoveFromRoleAsync(User, "owner");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "owner");
                await _userManager.AddToRoleAsync(User, "admin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "regulator")
            {
                await _userManager.RemoveFromRoleAsync(User, "regulator");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "regulator");
                await _userManager.AddToRoleAsync(User, "admin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin2")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin2");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin2");
                await _userManager.AddToRoleAsync(User, "admin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else
            {
                return true;

            }





        }
        public async Task<bool> EditAllRoleToDawaView(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            if (UserRole.RoleId == "SuperAdmin")
            {
                await _userManager.RemoveFromRoleAsync(User, "SuperAdmin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "SuperAdmin");
                await _userManager.AddToRoleAsync(User, "DawaView");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
                await _userManager.AddToRoleAsync(User, "View");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "eatalaJazaea")
            {
                await _userManager.RemoveFromRoleAsync(User, "eatalaJazaea");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "eatalaJazaea");
                await _userManager.AddToRoleAsync(User, "View");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "owner")
            {
                await _userManager.RemoveFromRoleAsync(User, "owner");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "owner");
                await _userManager.AddToRoleAsync(User, "DawaView");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "regulator")
            {
                await _userManager.RemoveFromRoleAsync(User, "regulator");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "regulator");
                await _userManager.AddToRoleAsync(User, "DawaView");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin2")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin2");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin2");
                await _userManager.AddToRoleAsync(User, "View");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }

            else
            {
                return true;

            }
        }
        public async Task<bool> EditAllRoleToJazeaView(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            if (UserRole.RoleId == "SuperAdmin")
            {
                await _userManager.RemoveFromRoleAsync(User, "SuperAdmin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "SuperAdmin");
                await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
                await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "View")
            {
                await _userManager.RemoveFromRoleAsync(User, "View");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "View");
                await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "owner")
            {
                await _userManager.RemoveFromRoleAsync(User, "owner");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "owner");
                await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "regulator")
            {
                await _userManager.RemoveFromRoleAsync(User, "regulator");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "regulator");
                await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin2")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin2");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin2");
                await _userManager.AddToRoleAsync(User, "eatalaJazaea");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }

            else
            {
                return true;

            }
        }

        public async Task<bool> EditAllRoleToRegulator(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            if (UserRole.RoleId == "SuperAdmin")
            {
                await _userManager.RemoveFromRoleAsync(User, "SuperAdmin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "SuperAdmin");
                await _userManager.AddToRoleAsync(User, "regulator");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
                await _userManager.AddToRoleAsync(User, "regulator");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "View")
            {
                await _userManager.RemoveFromRoleAsync(User, "View");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "View");
                await _userManager.AddToRoleAsync(User, "regulator");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "owner")
            {
                await _userManager.RemoveFromRoleAsync(User, "owner");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "owner");
                await _userManager.AddToRoleAsync(User, "regulator");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "eatalaJazaea")
            {
                await _userManager.RemoveFromRoleAsync(User, "eatalaJazaea");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "eatalaJazaea");
                await _userManager.AddToRoleAsync(User, "regulator");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin2")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin2");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin2");
                await _userManager.AddToRoleAsync(User, "regulator");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }

            else
            {
                return true;

            }
        }

        public async Task<bool> EditAllRoleToAdmin2(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            if (UserRole.RoleId == "SuperAdmin")
            {
                await _userManager.RemoveFromRoleAsync(User, "SuperAdmin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "SuperAdmin");
                await _userManager.AddToRoleAsync(User, "admin2");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
                await _userManager.AddToRoleAsync(User, "admin2");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "View")
            {
                await _userManager.RemoveFromRoleAsync(User, "View");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "View");
                await _userManager.AddToRoleAsync(User, "admin2");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "owner")
            {
                await _userManager.RemoveFromRoleAsync(User, "owner");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "owner");
                await _userManager.AddToRoleAsync(User, "admin2");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "regulator")
            {
                await _userManager.RemoveFromRoleAsync(User, "regulator");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "regulator");
                await _userManager.AddToRoleAsync(User, "admin2");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "eatalaJazaea")
            {
                await _userManager.RemoveFromRoleAsync(User, "eatalaJazaea");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "eatalaJazaea");
                await _userManager.AddToRoleAsync(User, "admin2");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }

            else
            {
                return true;

            }
        }

        public async Task<bool> EditAllRoleToSuperAdmin(string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            var UserRole = await _db.UserRoles.FirstOrDefaultAsync(a => a.UserId == UserId);
            if (UserRole.RoleId == "owner")
            {
                await _userManager.RemoveFromRoleAsync(User, "owner");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "owner");
                await _userManager.AddToRoleAsync(User, "SuperAdmin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin");
                await _userManager.AddToRoleAsync(User, "SuperAdmin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "View")
            {
                await _userManager.RemoveFromRoleAsync(User, "View");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "View");
                await _userManager.AddToRoleAsync(User, "SuperAdmin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "eatalaJazaea")
            {
                await _userManager.RemoveFromRoleAsync(User, "eatalaJazaea");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "eatalaJazaea");
                await _userManager.AddToRoleAsync(User, "SuperAdmin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "regulator")
            {
                await _userManager.RemoveFromRoleAsync(User, "regulator");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "regulator");
                await _userManager.AddToRoleAsync(User, "SuperAdmin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }
            else if (UserRole.RoleId == "admin2")
            {
                await _userManager.RemoveFromRoleAsync(User, "admin2");
                var RoleRecored = await _db.Roles.FirstOrDefaultAsync(a => a.Name == "admin2");
                await _userManager.AddToRoleAsync(User, "SuperAdmin");
                UserRole.RoleId = RoleRecored.Id;
                _db.UserRoles.Update(UserRole);
                await _db.SaveChangesAsync();
                return true;

            }

            else
            {
                return true;

            }
        }

        public async Task<string> DeleteUser(string UserName)
        {

            var User = await _db.Users.FirstOrDefaultAsync(a => a.UserName == UserName);
            if(User == null)
            {
                return "هذا المستخدم غير موجود";
            }else
            {
                _db.Users.Remove(User);
                _db.SaveChanges();
                return "تم حذف المستخدم";
            }
            
        }
    }
}
