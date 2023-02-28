namespace DB_Darbas.DAL
{
    public interface IJwtRepository
    {
        void SaveAccount(Account account);
        Account GetAccount(string username);

        void SavePerson(Person personDetails);

        void SaveLocation(Location locationDetails);

    }
}
