using AjkerdealAdmin.Services.Attributes;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AjkerdealAdmin.Connection
{
    [TransientLifetime]
    public class Connection : IConnection
    {

        private static readonly SqlConnectionStringBuilder LocalConnectionString =
            new SqlConnectionStringBuilder
            {
                ApplicationName = "LocalConnection",
                DataSource = "AJKERDEAL-SERVE",
                InitialCatalog = "AjkerDeal",
                IntegratedSecurity = false,
                Password = "Rony@Deal",
                PersistSecurityInfo = false,
                Pooling = true,
                UserID = "rony"
            };

        private static readonly SqlConnectionStringBuilder LiveConnectionString =
            new SqlConnectionStringBuilder
            {
                //ApplicationName = "LiveConnection",
                //DataSource = "50.28.38.161",
                ////DataSource = "192.168.0.4",
                //InitialCatalog = "AjkerDeal",
                //IntegratedSecurity = false,
                //Password = "AD#RS@Dl+016",
                //PersistSecurityInfo = false,
                //Pooling = true,
                //UserID = "AjkerD"

                ApplicationName = "LiveConnection",
                DataSource = "69.16.228.137",
                //DataSource = "192.168.0.5",
                InitialCatalog = "AjkerDeal",
                IntegratedSecurity = false,
                Password = "b01shakH@23#R",
                PersistSecurityInfo = false,
                Pooling = true,
                UserID = "AjkerD"
            };

        private SqlConnection _databaseConnection;

        public IDbConnection GetConnection
        {

            get
            {
                _databaseConnection = new SqlConnection(LiveConnectionString.ConnectionString);

                try
                {
                    _databaseConnection?.Open();
                }
                catch (Exception)
                {
                    // ignored
                }
                return _databaseConnection;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Connection() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
