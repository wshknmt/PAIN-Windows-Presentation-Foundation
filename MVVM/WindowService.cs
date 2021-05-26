using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PAIN_WPF.MVVM
{
    public class WindowService : IWindowService
    {
        public void Show(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            window.Title = "Books view";
            window.MinHeight = 350;
            window.MinWidth = 250;
            window.Show();
        }

        public void ShowDialog(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            window.Title = "Book view";
            window.MinHeight = 300;
            window.MinWidth = 350;
            window.ShowDialog();
        }
    }
}
