using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhonebookWebAPI.Models;

namespace PhonebookWebAPI.Data
{
    public class EntriesRepository : BaseRepository<Entry>
    {
        public EntriesRepository(Context context)
            : base(context)
        {
        }

        public override Entry Get(int id)
        {
            var entries = Context.Entries
                .Where(e => e.Id == id)
                .SingleOrDefault();

            return entries;
        }

        public override IList<Entry> GetList()
        {
            return Context.Entries
                .OrderBy(e => e.Id)
                .ToList();
        }
    }
}