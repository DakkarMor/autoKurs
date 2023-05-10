using kursovik.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace kursovik.DAO
{
    public class ContactsDAO
    {
        // создаем экземпляр класса сущностей
        private bd1Entities3 _entities = new bd1Entities3();
        public IEnumerable<Route> getAllContacts()
        {
            // простая выборка через класс сущностей
            return (from c in _entities.Route select c);
        }
        public Transport GetContactGroup(int? id)
        {
            if (id != null) //возращает запись по её Id
                return (from c in _entities.Transport
                        where c.Id == id
                        select c).FirstOrDefault();
            else // возращает первую запись в таблице
                return (from c in _entities.Transport
                        select c).FirstOrDefault();
        }
        public Route getContact(int id)
        {
            return (from c in _entities.Route.Include("Transport")
                    where c.Id == id
                    select c).FirstOrDefault();
        }
        public bool addContact(int TransportId, Route contact)
        {
            try
            {
                // Associate Contacts with Groups
                contact.Transport = GetContactGroup(TransportId);
                // добавление записи в таблицу Contacts
                _entities.Route.Add(contact);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool updateContact(int TransportId, Route contact)
        {

            Route originalContact = getContact(contact.Id);
            originalContact.Transport = GetContactGroup(TransportId);
            originalContact.Transport = GetContactGroup(TransportId);
            try
            {
                // редактирование записи в таблице

                _entities.Route.AddOrUpdate(contact);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteContact(Route contact)
        {
            Route originalContact = getContact(contact.Id);
            try
            {
                // удалаем запись из таблицы
                _entities.Route.Remove(originalContact);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}