using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManger:IContactService
    {
        IContactDal _contactDal;
        public ContactManger(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }
        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }
        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ID == id);
        }
        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
