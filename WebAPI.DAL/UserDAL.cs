using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.DAL
{
   public class UserDAL:BaseDAL
    {
        public User GetUserByApiKey(string apiKey)
        {
            return db.Users.FirstOrDefault(x => x.UserKey.ToString() == apiKey);
        }
        public User GetUserByName(string name)
        {
            return db.Users.FirstOrDefault(x => x.Name == name);
        }
    }
}
