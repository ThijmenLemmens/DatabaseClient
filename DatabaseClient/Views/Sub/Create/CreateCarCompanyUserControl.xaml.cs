using DatabaseClient.ViewModels.Sub.Create;
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

namespace DatabaseClient.Views.Sub.Create
{
    /// <summary>
    /// Interaction logic for CreateCarCompanyUserControl.xaml
    /// </summary>
    public partial class CreateCarCompanyUserControl : UserControl
    {
        public CreateCarCompanyUserControl()
        {
            InitializeComponent();

            CreateCarCompanyViewModel createCarCompanyViewModel = new();

            DataContext = createCarCompanyViewModel;
        }
    }
}
