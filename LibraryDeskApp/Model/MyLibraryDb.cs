using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookDeskApp.Model
{
    class MyLibraryDb : DbContext
    {
        public MyLibraryDb():base()
        { }

        public DbSet<LibraryBook> LibraryBook { get; set; }
        public DbSet<Library> Library  { get; set; }
    }
}
