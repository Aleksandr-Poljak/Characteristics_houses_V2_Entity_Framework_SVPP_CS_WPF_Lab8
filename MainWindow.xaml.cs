using Microsoft.EntityFrameworkCore;
using SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HouseContext houseContext;
        public MainWindow()
        {
            InitializeComponent();
            houseContext = new HouseContext("DafaultConnection");
            InitDataGridHouses();
        }

        private void InitDataGridHouses()
        {
            houseContext.Houses.Load();
            DataGrid_Houses.DataContext = houseContext.Houses.ToList();
        }
    }
}