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
        public MainWindow()
        {
            InitializeComponent();
            
            using(HouseContext db = new())
            {
                House house = new House("Минск", "Одинцова", 18);
                db.Houses.Add(house);
                db.SaveChanges();

            }

            using(HouseContext db = new())
            {
                var houses = db.Houses.ToList();
                foreach(House house in houses)
                {
                    MessageBox.Show(house.City);
                }
            }
        }
    }
}