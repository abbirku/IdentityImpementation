using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.Contexts
{
    internal class SeedData
    {
        internal ApplicationRole[] Roles
        {
            get
            {
                return new ApplicationRole[]
                {
                    new ApplicationRole{ Id = Guid.NewGuid(), Name = "Admin" },
                    new ApplicationRole{ Id = Guid.NewGuid(), Name = "SuperAdmin" },
                    new ApplicationRole{ Id = Guid.NewGuid(), Name = "Customer" }
                };
            }
        }
    }
}
