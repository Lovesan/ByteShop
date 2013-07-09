using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ByteShop.Models.Security.Providers
{
    public class ByteShopRoleProvider : RoleProvider
    {

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            Role role = new Role() { Name = roleName };
            SecurityContext ctx = new SecurityContext();
            ctx.Roles.Add(role);
            ctx.SaveChanges();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string email)
        {
            string [] role = new string[] { };
            using (SecurityContext ctx = new SecurityContext())
            {
                try
                {
                    User user = (from u in ctx.Users
                                 where u.Email == email
                                 select u).FirstOrDefault();

                    if (user != null)
                    {
                        Role userRole = ctx.Roles.Find(user.RoleId);

                        if (userRole != null)
                        {
                            role = new string[] { userRole.Name };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            bool userInRole = false;
            using (SecurityContext ctx = new SecurityContext())
            {
                try
                {
                    User user = (from u in ctx.Users
                                 where u.Email == email
                                 select u).FirstOrDefault();

                    if (user != null)
                    {
                        Role userRole = ctx.Roles.Find(user.RoleId);

                        if (userRole != null && userRole.Name == roleName)
                        {
                            userInRole = true;
                        }
                    }
                }
                catch
                {
                    userInRole = false;
                }
            }
            return userInRole;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}