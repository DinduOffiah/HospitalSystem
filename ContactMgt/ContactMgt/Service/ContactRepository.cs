using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactMgt.Models;

namespace ContactMgt.Service
{
    public class ContactRepository
    {
        public Contact[] GetAllContact()
        {
            var ctx = HttpContext.Current;

            if(ctx != null)
            {
                return (Contact[])ctx.Cache[CachKey];
            }

            return new Contact[]
            {
                new Contact {Name = "placeholder", Id = 0},

            };
        }

        private const string CachKey = "ContactStore";

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CachKey] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact{Name = "NerdStark", Id = 2},

                        new Contact{Name = "JohnSnow", Id = 4}
                    };

                    ctx.Cache[CachKey] = contacts;
                }

            }
        }

        public bool SaveInput(Contact contact)
        {
            var ctx = HttpContext.Current;

            if( ctx != null)
            {
                try
                {
                    var CurrentData = ((Contact[])ctx.Cache[CachKey]).ToList();
                    CurrentData.Add(contact);

                    ctx.Cache[CachKey] = CurrentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                
            }
            return false;
        }
    }
}