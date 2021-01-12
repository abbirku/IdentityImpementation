using Microsoft.AspNetCore.Authorization;

namespace Membership.BusinessObjects
{
    public class NameRequirement : IAuthorizationRequirement
    {
        public NameRequirement()
        {
        }
    }
}
