using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Requirements_and_Design_environment.Infrastructure;

namespace Requirements_and_Design_environment.Models.Repositories
{
    public class BaseRepository : IDisposable
    {
        #region " Declarations "

            private bool disposed = false;

            protected RdeDbContext dbContext = new RdeDbContext();

        #endregion

        #region " Dispose "

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        dbContext.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

        #endregion
        
    }
}