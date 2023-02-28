namespace DB_Darbas.BL
{
    public interface IJwtService
    {
        string GetJwtToken(string username, int accountId);
    }
}
