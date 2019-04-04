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
            temp.Name = Location;
            var query = from book in db.LibraryBook where book.InStockLocations.Contains(temp) select book;
            var array = query.ToArray();
            var nextWindow = new Results(array);
            nextWindow.Show();
        }
    }
}
