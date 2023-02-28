namespace DB_Darbas.BL
{
    public interface IAccountsService
    {
        Account SignupNewAccount(string username, string password

            , string name, string surname, string personalCode, string phoneNumber, string email,
            string city, string street, string houseNr, string appartmentNr
            );
        (bool, Account) Login(string username, string password);
        public List<Account> GetAll();

        public Account GetById(int id);
        public Account GetByUserName(string userName);
        public void DeleteByID(int id);
        public void UpdateByUserName(string userName, string Role);

    }
}
