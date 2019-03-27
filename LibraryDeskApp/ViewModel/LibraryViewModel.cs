using LibraryBookDeskApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookDeskApp.ViewModel
{
    class LibraryViewModel
    {
        MyLibraryDb _db = new MyLibraryDb();

        public LibraryViewModel()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
               Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            LibraryBooks = _db.LibraryBook.ToList();
        }

        public IList<LibraryBook> LibraryBooks { get; set; }
    }
}
