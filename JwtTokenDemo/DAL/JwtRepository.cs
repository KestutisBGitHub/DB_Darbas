namespace DB_Darbas.DAL
{
    public class JwtRepository : IJwtRepository
    {
        private readonly JwtDemoDbContext _context;
        public JwtRepository(JwtDemoDbContext context)
        {
            _context = context;
        }

        public Account GetAccount(string username)
        {
            return _context.Accounts.FirstOrDefault(a => a.Username == username);
        }

        public void SaveAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public void SavePerson(Person personDetails)
        {
            _context.Person.Add(personDetails);
            _context.SaveChanges();
        }
        public void SaveLocation(Location locationDetails)
        {
            _context.Location.Add(locationDetails);
            _context.SaveChanges();
        }
    }
}
