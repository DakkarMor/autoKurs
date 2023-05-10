using kursovik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kursovik.DAO
{
    public class GroupsDAO
    {
        private bd1Entities3 _entities = new bd1Entities3();
        public IEnumerable<Transport> getAllGroups()
        {
            return (from c in _entities.Transport
                    select c);
        }
    }
}