using PhonebookWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhonebookWebAPI.Data
{
    public class PhonebookRepository : BaseRepository<Phonebook>
    {
        public PhonebookRepository(Context context)
            : base(context)
        {
        }

        public override Phonebook Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Phonebook> GetList()
        {
            return Context.Phonebooks
                .Include(p => p.Entries)
                .OrderBy(p => p.Id)
                .ToList();
        }
    }
}