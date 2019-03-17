using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.DAL
{
    public class BaseDAL
    {
        protected LangEntities db;
        public BaseDAL()
        {
            db = new LangEntities();
        }
    }
}
