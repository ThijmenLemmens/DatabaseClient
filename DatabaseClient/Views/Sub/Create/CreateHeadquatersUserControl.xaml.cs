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
    /// Interaction logic for CreateHeadquatersUserControl.xaml
    /// </summary>
    public partial class CreateHeadquatersUserControl : UserControl
    {
        public CreateHeadquatersUserControl()
        {
            InitializeComponent();

            CreateHeadquatersViewModel createHeadquatersViewModel = new();

            DataContext = createHeadquatersViewModel;
        }
    }
}
