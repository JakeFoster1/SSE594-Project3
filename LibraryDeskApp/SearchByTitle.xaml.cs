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
    /// Interaction logic for SearchByTitle.xaml
    /// </summary>
    public partial class SearchByTitle : Window
    {
        public SearchByTitle()
        {
            InitializeComponent();
        }

        private void btn_Search(object sender, RoutedEventArgs e)
        {
            string Title = tb_Title.Text;
            MyLibraryDb db = new MyLibraryDb();
            var query = from book in db.LibraryBook where book.Title.Contains(Title) select book;
            var array = query.ToArray();
            var nextWindow = new Results(array);
            nextWindow.Show();
        }
    }
}
