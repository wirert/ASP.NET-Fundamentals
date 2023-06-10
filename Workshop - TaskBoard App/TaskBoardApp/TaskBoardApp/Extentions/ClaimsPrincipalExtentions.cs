using System.Security.Claims;

namespace TaskBoardApp.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
