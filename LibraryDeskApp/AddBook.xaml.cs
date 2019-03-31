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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryDeskApp
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void Add_Book(object sender, RoutedEventArgs e)
        {
            if(NotNull(ISBN.Text) && NotNull(Title.Text) && NotNull(Author.Text)
                && NotNull(Publisher.Text) && NotNull(Date_Published.Text)
                && NotNull(Stock1.Text))
            {
                if (DateCorrect(Date_Published.Text))
                {
                    if (LocationCorrect(Stock1.Text))
                    {
                        List<string> Stock1List = Stock1.Text.Split(',').ToList<string>();
                        LibraryBook newBook = new LibraryBook()
                        {
                            Id = Convert.ToInt64(ISBN.Text),
                            Title = Title.Text,
                            Author = Author.Text,
                            Publisher = Publisher.Text,
                            DatePublished = DateTime.Parse(Date_Published.Text),
                            InStockLocations = new List<Library>()
                            {
                                new Library()
                                {
                                    Id = 1,
                                    Name = Stock1List[0],
                                    Address = Stock1List[1]
                                }
                            }
                        };
                        if(NotNull(Stock2.Text) && LocationCorrect(Stock2.Text))
                        {
                            List<string> list = Stock2.Text.Split(',').ToList<string>();
                            newBook.InStockLocations.Add(
                                new Library()
                                {
                                    Id = 1,
                                    Name = list[0],
                                    Address = list[1]
                                });
                        }
                        if (NotNull(Stock3.Text) && LocationCorrect(Stock3.Text))
                        {
                            List<string> list = Stock3.Text.Split(',').ToList<string>();
                            newBook.InStockLocations.Add(
                                new Library()
                                {
                                    Id = 1,
                                    Name = list[0],
                                    Address = list[1]
                                });
                        }
                        if (NotNull(Stock4.Text) && LocationCorrect(Stock4.Text))
                        {
                            List<string> list = Stock4.Text.Split(',').ToList<string>();
                            newBook.InStockLocations.Add(
                                new Library()
                                {
                                    Id = 1,
                                    Name = list[0],
                                    Address = list[1]
                                });
                        }

                        MyLibraryDb db = new MyLibraryDb();
                        var LibraryBooks = db.Set<LibraryBook>();
                        LibraryBooks.Add(newBook);
                        db.SaveChanges();

                        LoopVisualTree(this);

                        MessageBoxResult successResult = MessageBox.Show("Your Book Was Successfully Added",
                                          "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Exclamation);
                    }

                    MessageBoxResult locationResult = MessageBox.Show("Please Use (Name, Address) Format For In Stock Locations",
                                          "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                    return;
                }

                MessageBoxResult dateResult = MessageBox.Show("Please Use (mm/dd/yyyy) Format For Date Published",
                                          "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                return;
            }

            MessageBoxResult emptyFieldResult = MessageBox.Show("Please Fill In All Fields And At Least One In Stock Location",
                                          "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
        }

        private bool NotNull(string a)
        {
            return !string.IsNullOrEmpty(a);
        }

        private bool DateCorrect(string a)
        {
            if (DateTime.TryParse(a, out DateTime b))
            {
                return true;
            }

            return false;
        }

        private bool LocationCorrect(string a)
        {
            if(!a.Contains(","))
            {
                return false;
            }

            List<string> list = a.Split(',').ToList<string>();

            if(string.IsNullOrEmpty(list[0]) || string.IsNullOrEmpty(list[1]))
            {
                return false;
            }
            
            return true;
        }

        private void LoopVisualTree(DependencyObject obj)
        {

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)

            {

                if (obj is TextBox)

                    ((TextBox)obj).Text = null;

                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));

            }

        }
    }
}
