using DB_Darbas.DAL;
using System.Security.Cryptography;
using System.Text;

namespace DB_Darbas.BL
{
    public class AccountsService : IAccountsService
    {
        private readonly IJwtRepository _jwtRepository;
        private readonly JwtDemoDbContext _context;

        public AccountsService(IJwtRepository jwtRepository, JwtDemoDbContext context)
        {
            _jwtRepository = jwtRepository;
            _context = context;
        }

        public (bool, Account) Login(string username, string password)
        {
            var account = _jwtRepository.GetAccount(username);
            if (account == null)
            {
                return (false, null);
            }

            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return (true, account);
            }
            else
            {
                return (false, null);
            }
        }

        public Account SignupNewAccount(string username, string password
            , string name, string surname, string personalCode, string phoneNumber, string email,
            string city, string street, string houseNr, string appartmentNr
            )
        {
            var account = CreateAccount(username, password);
            var personDetails = new Person
            {
                Name = name,
                Surname = surname,
                PersonalCode = personalCode,
                PhoneNumber = phoneNumber,
                Email = email,
            };
            var locationDetails = new Location
            {
                City = city,
                Street = street,
                HouseNr = houseNr,
                AppartmentNr = appartmentNr

            };

            _jwtRepository.SaveAccount(account);
            _jwtRepository.SavePerson(personDetails);
            _jwtRepository.SaveLocation(locationDetails);
            return account;
        }

        private Account CreateAccount(string username, string password
            )
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var account = new Account
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "user",


            };

            return account;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account GetById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }
        public Account GetByUserName(string username)
        {
            return _context.Accounts.FirstOrDefault(x => x.Username == username);
        }
        public void DeleteByID(int id)
        {
            var userToDlete = _context.Accounts.FirstOrDefault(x => x.Id == id);
            _context.Accounts.Remove(userToDlete);
            _context.SaveChanges();
        }
        public void UpdateByUserName(string username, string role)
        {
            var itemFromDb = _context.Accounts.FirstOrDefault(x => x.Username == username);
            itemFromDb.Role = role;
            _context.SaveChanges();
        }






    }
}
