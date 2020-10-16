using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Entity;
using Microsoft.AspNetCore.Http;

namespace Common.Session
{
    public class CurrentUserHelper: ICurrentUser
    {
      private  IHttpContextAccessor _contextAccessor;

        public CurrentUserHelper(IHttpContextAccessor contextAccessor)
        {
            this._contextAccessor = contextAccessor;
        }

        public async Task<CurrentUser> GetUser()
        {
            var user = new CurrentUser();
            var context = this._contextAccessor.HttpContext;

           user.Id=  context.User.Claims.Where(s => s.Type == ClaimTypes.NameIdentifier).Select(s => Convert.ToInt32(s.Value)).FirstOrDefault();
            user.FullName = context.User.Claims.Where(s => s.Type == ClaimTypes.Name).Select(s => s.Value).FirstOrDefault();
            user.UserName = context.User.Claims.Where(s => s.Type == "UserName").Select(s => s.Value).FirstOrDefault();
            user.Email = context.User.Claims.Where(s => s.Type == ClaimTypes.Email).Select(s =>s.Value).FirstOrDefault();

            return await Task.FromResult(user);
        }
    }
}
