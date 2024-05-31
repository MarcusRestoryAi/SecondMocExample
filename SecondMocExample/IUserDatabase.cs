using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondMocExample
{
    public interface IUserDatabase
    {
        public User GetUser(int id);

        public void SaveUser(User user);
    }
}
