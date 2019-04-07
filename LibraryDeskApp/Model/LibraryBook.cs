using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBookDeskApp.Model
{
    class LibraryBook
    {
        public long Id                         { get; set; }
        public string Title                    { get; set; }
        public string Author                   { get; set; }
        public string Publisher                { get; set; }
        public DateTime DatePublished          { get; set; }
        //[ForeignKey("Library")]
        public IList<Library> InStockLocations { get; set; }
    }
}
