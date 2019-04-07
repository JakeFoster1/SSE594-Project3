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
    /// Interaction logic for SearchByAuthor.xaml
    /// </summary>
    public partial class SearchByAuthor : Window
    {
        public SearchByAuthor()
        {
            InitializeComponent();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            MyLibraryDb db = new MyLibraryDb();
            string AuthorName = tb_Author.Text;
            var query = from book in db.LibraryBook where book.Author.Contains(AuthorName) select book;
            var array = query.ToArray();
            var nextWindow = new Results(array);
            nextWindow.Show();
            
        }
    }
}
