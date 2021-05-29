using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PAIN_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();
       // private BooksModel BooksModel { get; } = new BooksModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            /*base.OnStartup(e);
            PAIN_WPF.ViewModels.BooksViewModel booksViewModel = new PAIN_WPF.ViewModels.BooksViewModel(BooksModel);
            WindowService.Show(booksViewModel);*/
        }
    }
}
