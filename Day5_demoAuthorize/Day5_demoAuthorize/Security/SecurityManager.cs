using Day5_demoAuthorize.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Day5_demoAuthorize.Security
{
    public class SecurityManager
    {
        private IEnumerable<Claim> getUserClaim(Account account)
        {
            //claims sẽ lưu các role của account
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Usename));

            //add role tương ứng với username đó
            account.AccountRoles.ToList().ForEach(ar =>
            {
                claims.Add(new Claim(ClaimTypes.Role, ar.Role.Name));
            });
            return claims;
        }

        public async Task SignIn(HttpContext context, Account account)
        {
            // cho phép dùng cookie để đăng nhập
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaim(account), CookieAuthenticationDefaults.AuthenticationScheme);

            //quản lý thông tin account thông qua định danh claimsIdentity, không lưu phiên password
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task SignOut(HttpContext context)
        {
            await context.SignOutAsync();
        }
    }
}
