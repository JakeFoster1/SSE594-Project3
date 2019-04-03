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
    /// Interaction logic for performSearch.xaml
    /// </summary>
    public partial class performSearch : Window
    {
        public performSearch()
        {
            InitializeComponent();
           
        }

        private void Btn_Get_All_Books(object sender, RoutedEventArgs e)
        {
            MyLibraryDb db = new MyLibraryDb();

            var query = from books in db.LibraryBook select books;
            var array = query.ToArray();
            var nextWindow = new Results(array);
            nextWindow.Show();
        }

        private void Btn_search_by_author_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_search_by_title_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_search_by_location_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
