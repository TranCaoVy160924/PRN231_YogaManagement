using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using YogaCenterLibrary.Models;
using YogaCenterAPIV2.Utils;

namespace YogaCenterAPIV2.DAL
{
    public class TestRepository
    {

        YogaCenterContext db = new YogaCenterContext();
        public TestRepository() { } 
        public async Task DeleteAccount(Account account)
        {
            db.Accounts.Remove(account);
            await db.SaveChangesAsync();
        }

        public async Task Register(Account account)
        {
            account.RoleId = Constant.Role.TRAINEE_ROLEID;
            string hashPassword = Util.HashPassword(account.Password);
            account.Password = hashPassword;
            db.Accounts.Add(account);
            await db.SaveChangesAsync();
            Util.getInstance().GetContentThankYou(account.Email, account.Firstname);
        }


        public async Task<dynamic?> CheckLogin(Account acc)
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
                                     Role = new Role { Id = a.Role.Id, Name = a.Role.Name}
                                 }).SingleOrDefaultAsync();
            string? accountPassword = await getPassword(acc.PhoneNumber);
            if (accountPassword != null) { 
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
    }
}
