using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMocExample
{
    public class UserManager
    {
        private readonly IUserDatabase _database;

        public User CurrentUser { get; set; }

        public UserManager(IUserDatabase database)
        {
            _database = database;
        }

        public User GetUserById(int id)
        {
            CurrentUser = _database.GetUser(id);
            return CurrentUser;
        }

        public void SaveUser(User user)
        {
            _database.SaveUser(user);
        }
    }
}
