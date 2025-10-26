using DatabaseClient.ViewModels.Sub;
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
    /// Interaction logic for ListCarsUserControl.xaml
    /// </summary>
    public partial class ListCarsUserControl : UserControl
    {
        public ListCarsUserControl()
        {
            InitializeComponent();

            ListCarViewModel listCarViewModel = new();

            DataContext = listCarViewModel;
        }
    }
}
