using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhonebookWebAPI.Models
{
    public class Phonebook
    {
        public Phonebook()
        {
            Entries = new List<Entry>();
        }

        public int Id { get; set; }

        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        public IList<Entry> Entries { get; set; }
    }
}