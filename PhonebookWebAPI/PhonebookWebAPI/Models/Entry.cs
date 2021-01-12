using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookWebAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public Phonebook Phonebook { get; set; }

        public int? PhonebookId { get; set; }
    }
}