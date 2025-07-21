namespace ResourceProject
{
    public class DBConnection : IDisposable
    {

        public DBConnection()
        {
            Console.WriteLine("Open connection");
            disposedValue = false;
        }
        
        public void Execute() => Console.WriteLine("Execute command");

        #region IDisposable Support

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                Console.WriteLine("Close connection");
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~DBConnection()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this); // отключение вызова деструктора при удалении объект
        }

        #endregion
    }
    internal class Program
    {
        static void Test() 
        {
            using DBConnection db = new DBConnection();
            db.Execute();
        } // при выходе из метода db.Dispose() 
        static void Main(string[] args)
        {
            /*DBConnection conn = new DBConnection();
            try
            {
                conn.Execute();
            }
            finally
            {
                conn.Dispose();
            }*/

            /*using (DBConnection db = new DBConnection())
            {
                db.Execute();
            } // db.Dispose()
            */


            Test();
        }
    }
}
