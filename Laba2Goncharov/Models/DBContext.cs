using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Laba2Goncharov.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
    }
}