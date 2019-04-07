using LibraryBookDeskApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryDeskApp
{
    /// <summary>
    /// Interaction logic for SearchByLocation.xaml
    /// </summary>
    public partial class SearchByLocation : Window
    {
        public SearchByLocation()
        {
            InitializeComponent();
        }

        private void Btn_Search(object sender, RoutedEventArgs e)
        {
            string Location = tb_Location.Text;
            MyLibraryDb db = new MyLibraryDb();
            Library temp = new Library();
            
            var query = from book in db.LibraryBook select book;
            var array = query.ToArray();
            List<LibraryBook> resultList = new List<LibraryBook>();
            foreach(var x in array)
            {
                if(x.InStockLocations != null)
                {
                    foreach (var location in x.InStockLocations)
                    {
                        if (location.Name.Contains(Location))
                        {
                            resultList.Add(x);
                        }
                    }
                }
               
            }
            var nextWindow = new Results(resultList.ToArray());
            nextWindow.Show();
        }
    }
}
