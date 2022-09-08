using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int UserId
        {
            get
            {
                return GetAuthorizedUserId();
            }
        }
        private int GetAuthorizedUserId()
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool parsed = int.TryParse(id, out int userId);
            if (!parsed)
            {
                throw new Exception("Name Identifier does not exist!");
            }
            return userId;
        }
    }
}
