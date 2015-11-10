using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Requirements_and_Design_environment.Models;
using WebMatrix.WebData;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Requirements_and_Design_environment.Infrastructure
{
    public class MembershipInitializer
    {
        public static void InitializeLoginSystem()
        {
            Database.SetInitializer<RdeDbContext>(null);

            try
            {
                using (var context = new RdeDbContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }
                WebSecurity.InitializeDatabaseConnection("RdeConnectionString", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }

        }
    }
}