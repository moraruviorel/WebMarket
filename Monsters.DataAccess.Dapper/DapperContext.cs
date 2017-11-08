using System.Data.SqlClient;

namespace Monsters.DataAccess.Dapper
{
    public class DapperContext
    {
        public DapperContext()
        {
            SqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS; Database=Monsters_Dev; User ID=Monsters; Password=Monsters; Trusted_Connection=False;");
        }

        public SqlConnection SqlConnection { get; private set; }

        public void Open()
        {
            SqlConnection.Open();
        }

        public void Close()
        {
            SqlConnection.Close();
        }
    }
}
