using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_WPF.Models
{
    public class BooksModel
    {
        public ObservableCollection<Book> Books { get; private set; } = new ObservableCollection<Book>();
        public BooksModel()
        {
            Books.Add(new Book(" In Search of Lost Time", "Marcel Proust", new DateTime(1913, 4, 5), "Modernist"));
            Books.Add(new Book("Deacon King Kong", "James McBride", new DateTime(2020, 3, 3), "Historical Fiction"));
            Books.Add(new Book("Elevation", "Stephen King", new DateTime(2018, 10, 30), "Literary fiction"));
        }
    }
}
