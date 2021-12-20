using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WAD_EXAM.Models
{
    public class DataContext :  DbContext
    {
        public DataContext() : base("WAD_EXAM") { }

        public DbSet<ListContact> ListContacts { get; set; }
    }
}