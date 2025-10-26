using DatabaseClient.Services.Data;
using DatabaseClient.ViewModels.Sub;
using Microsoft.Extensions.DependencyInjection;
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

namespace DatabaseClient.Views.Sub
{
    /// <summary>
    /// Interaction logic for ListCarCompanyUserControl.xaml
    /// </summary>
    public partial class ListCarCompanyUserControl : UserControl
    {

        public ListCarCompanyUserControl()
        {
            InitializeComponent();

            ListCarCompanyViewModel listCarCompanyViewModel = new();

            DataContext = listCarCompanyViewModel;
        }
    }
}
