using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PAIN_WPF.MVVM;

namespace PAIN_WPF.ViewModels
{
    public class BookViewModel : MVVM.IViewModel
    {
        private BooksModel BooksModel { get; }
        private Book Book { get; }
        public Action Close { get; set; }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OkCommand.NotifyCanExecuteChanged(); }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; OkCommand.NotifyCanExecuteChanged(); }
        }

        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; OkCommand.NotifyCanExecuteChanged(); }
        }

        private string category;
        public string Category 
        {   
            get { return category; }
            set { category = value; OkCommand.NotifyCanExecuteChanged(); }
        }

        public RelayCommand<BookViewModel> OkCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.Ok(); },
                (bookViewModel) => { return bookViewModel.Title != "" && bookViewModel.Author != "" && bookViewModel.ReleaseDate <= DateTime.Now && bookViewModel.Category != ""; }
            );
        public RelayCommand<BookViewModel> CancelCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.Cancel(); }
            );

        public BookViewModel(BooksModel booksModel, Book book)
        {
            BooksModel = booksModel;
            Book = book;
            if (Book != null)
            {
                Title = Book.Title;
                Author = Book.Author;
                ReleaseDate = Book.ReleaseDate;
                Category = Book.Category;
            }
            else
            {
                Title = "";
                Author = "";
                ReleaseDate = DateTime.Now;
                Category = "";
            }
        }

        public void Ok()
        {
            if (Title == "" || Author == "" || ReleaseDate > DateTime.Now || Category == "")
                return;
            if (Book == null)
            {
                Book book = new Book(Title, Author, ReleaseDate, Category);
                BooksModel.Books.Add(book);
            }
            else
            {
                Book.Title = Title;
                Book.Author = Author;
                Book.ReleaseDate = ReleaseDate;
                Book.Category = Category;
            }
            Close?.Invoke();
        }
        public void Cancel() => Close?.Invoke();
    }
}
