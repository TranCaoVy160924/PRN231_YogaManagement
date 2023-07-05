using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using YogaCenterAPIV2.Utils;
using YogaCenterAPIV2.Repositories;
using YogaCenterLibrary.Models;
using YogaCenterLibrary.DTO;

namespace YogaCenterAPIV2.DAL
{
    public class AccountRepository : IRepository<Account>
    {
        YogaCenterContext db = new YogaCenterContext();

        public async Task Add(Account entity)
        {
            string hashPassword = Util.HashPassword(entity.Password);
            entity.Password = hashPassword;
            entity.Deleted = false;
            db.Accounts.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task<dynamic?> CheckLogin(LoginDTO acc)
        {
            var account = await (from a in db.Accounts
                                 where a.PhoneNumber == acc.PhoneNumber && a.Deleted == false
                                 select new
                                 {
                                     AccountID = a.Id,
                                     Email = a.Email,
                                     FirstName = a.Firstname,
                                     LastName = a.Lastname,
                                     PhoneNumber = a.PhoneNumber,
                                     Address = a.Address,
                                     RecoveryCode = a.ValidationCode,
                                     Img = a.Img,
                                     Gender = a.Gender,
                                     Role = new Role { Id= a.Role.Id, Name = a.Role.Name}
                                 }).SingleOrDefaultAsync();

            string? accountPassword = await getPassword(acc.PhoneNumber);
            if (accountPassword != null)
            {
                bool check = Util.VerifyPassword(acc.Password, accountPassword);
                if (check)
                {
                    return account;
                }
            }

            return null;
        }
        private async Task<string?> getPassword(string phonenum)
        {
            var accountPassword = await (from a in db.Accounts.Where(a => a.PhoneNumber == phonenum) select new { Password = a.Password }).SingleOrDefaultAsync();
            if (accountPassword != null)
            {
                return accountPassword.Password;
            }

            return null;
        }
        public async Task Delete(int id)
        {
            var account = await db.Accounts.SingleOrDefaultAsync(a => a.Id == id);
            account.Deleted = true;
            await db.SaveChangesAsync();

        }

        public async Task<List<dynamic>> GetAll()
        {
            var accountList = await (from a in db.Accounts
                                     select new
                                     {
                                         AccountID = a.Id,
                                         Email = a.Email,
                                         FirstName = a.Firstname,
                                         LastName = a.Lastname,
                                         PhoneNumber = a.PhoneNumber,
                                         Address = a.Address,
                                         RecoveryCode = a.ValidationCode,
                                         Img = a.Img,
                                         Gender = a.Gender,
                                         Deleted = a.Deleted,
                                         Role = new { Id = a.Role.Id, Name = a.Role.Name }
                                     }).ToListAsync();
            return accountList.Cast<dynamic>().ToList();
        }
      
        public async Task<List<dynamic>> getAllByRole(int role)
        {
            var accountList = await (from a in db.Accounts
                                     select new
                                     {
                                         AccountID = a.Id,
                                         Email = a.Email,
                                         FirstName = a.Firstname,
                                         LastName = a.Lastname,
                                         PhoneNumber = a.PhoneNumber,
                                         Address = a.Address,
                                         RecoveryCode = a.ValidationCode,
                                         Img = a.Img,
                                         Gender = a.Gender,
                                         Deleted = a.Deleted,
                                         Role = new { Id = a.Role.Id, Name = a.Role.Name }
                                     }).Where(a => a.Role.Id == role).ToListAsync();
            return accountList.Cast<dynamic>().ToList();
        }
        public async Task<dynamic> GetById(int id)
        {
            var account = await db.Accounts.Where(account => account.Id == id).FirstOrDefaultAsync();
            return account;
        }
        public async Task<dynamic> GetByEmail(string email)
        {
            var account = await (db.Accounts.SingleOrDefaultAsync(a => a.Email == email));

            return account;
        }
        public async Task<dynamic> CreateValidationCode(string email)
        {
            var account = await GetByEmail(email);
            var ValidationCode = Util.getInstance().GetContentRecoveryCode(email);
            account.ValidationCode = ValidationCode;
            await db.SaveChangesAsync();
            var codeObj = new { validationCode = ValidationCode, accountID = account.Id };
            return codeObj;
        }
        public async Task<dynamic> IsValidationCode(int id, string code)
        {
            var account = await db.Accounts.SingleOrDefaultAsync(a => a.Id == id);
            if (account.ValidationCode == code)
            {
                return true;
            }
            return false;
        }
        public async Task<dynamic> IsExist(string phonenumber, string email)
        {
            var accountExists = await db.Accounts.AnyAsync(a => a.PhoneNumber == phonenumber || a.Email == email);

            if (accountExists)
            {
                return accountExists;
            }
            return null;
        }

        public async Task Update(int id, Account entity)
        {
            var oldAccount = await db.Accounts.Where(a => a.Id == id).FirstOrDefaultAsync();
            oldAccount.PhoneNumber = entity.PhoneNumber;
            oldAccount.Address = entity.Address;
            oldAccount.Firstname = entity.Firstname;
            oldAccount.Lastname = entity.Lastname;
            oldAccount.Img = entity.Img;
            await db.SaveChangesAsync();
        }
        public async Task UpdatePassword(int id, Account entity)
        {
            var oldAccount = await db.Accounts.Where(a => a.Id == id).SingleOrDefaultAsync();
            string hashPassword = Util.HashPassword(entity.Password);

            oldAccount.Password = hashPassword;
            await db.SaveChangesAsync();
        }
        public async Task<dynamic> CheckCurrentPassword(int? id, string? password)
        {
            var account = await db.Accounts.Where(a => a.Id == id).SingleOrDefaultAsync();
            bool check = Util.VerifyPassword(password, account.Password);
            if (check)
            {
                return true;
            }
            return false;
        }

        public async Task<dynamic> GetRoleList()
        {
            var roleList = await db.Roles.Where(r => r.Id != Constant.Role.ADMIN_ROLEID || r.Id != Constant.Role.STAFF_ROLEID).ToListAsync();
            return roleList;
        }


    }
}
