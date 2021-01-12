using System.Collections.Generic;
using Demo.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Demo.Membership.Services
{
    public class RoleManager
        : RoleManager<ApplicationRole>
    {
        public RoleManager(IRoleStore<ApplicationRole> store, 
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors,
            ILogger<RoleManager<ApplicationRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
