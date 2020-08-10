using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Bases
{
    public abstract class PersonelIhbarDalBase : RepositoryBase<PersonelIhbar>
    {
        protected PersonelIhbarDalBase(DbContext context) : base(context)
        {

        }
    }
}
