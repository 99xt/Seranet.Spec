﻿using Seranet.SpecM2.Data;
using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Seranet.SpecM2.Api.Scorecard
{
    public class UserRoleController : BaseApiController
    {
        // GET api/userrole
        public IEnumerable<UserRole> Get()
        {
            return context.UserRoles;
        }

        // GET api/values/5
        public int Get(String id)
        {
            List<UserRoleType> roles = (from b in context.UserRoles where b.UserName == id select b.UserRoleType).ToList();
            if (roles.Count == 0) { //user belongs to no role
                return -1;
            }
            if (roles.Count == 1)   //user belongs to one role
            {
                if (roles[0] == UserRoleType.ADMIN)
                    return 0;
                else if (roles[0] == UserRoleType.AUDITOR)
                    return 1;
            }
            else
            {
                //user is on Admin as well as Auditor role
            }
            {
                return 3;
            }
            return -1;
        }

    }
}
