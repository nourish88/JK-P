using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class PersonelIhbarDal : PersonelIhbarDalBase
    {
        public PersonelIhbarDal(DbContext context) : base(context)
        {

        }
    }
}
