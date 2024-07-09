using SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.Models;
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
using System.Windows.Shapes;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.OtherWindows
{
    /// <summary>
    /// Логика взаимодействия для EditHouseWindow.xaml
    /// </summary>
    public partial class EditHouseWindow : Window
    {
        public House House;

        public EditHouseWindow()
        {
            InitializeComponent();
        }

        public EditHouseWindow( House house)
        {
            InitializeComponent();
            Grid_EditHouse.DataContext = house;

        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
                    
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
