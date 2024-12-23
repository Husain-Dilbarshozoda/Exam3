using Npgsql;

namespace Infrastructure.DataContaxt;

public interface IConTaxt
{
    NpgsqlConnection Connection();
}

public class ConTaxt:IConTaxt
{
    private const string server = "Server=localhost;Port=5432;Database=husaintj_db;Username=postgres;Password=501040477.tj";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(server);
    }
    
}