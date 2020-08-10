using Business.Services.Bases;
using Entity.Entities;
using System;
using DataAccess.EntityFramework.Bases;

namespace Business.Services
{
    public class PersonelIhbarService : IPersonelIhbarService
    {
        private readonly PersonelIhbarDalBase _personelIhbarDal;

        public PersonelIhbarService(PersonelIhbarDalBase personelIhbarDal)
        {
            _personelIhbarDal = personelIhbarDal;
        }

        public void AddPersonelIhbar(PersonelIhbar personelIhbar)
        {
            try
            {
                _personelIhbarDal.AddEntity(personelIhbar);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
