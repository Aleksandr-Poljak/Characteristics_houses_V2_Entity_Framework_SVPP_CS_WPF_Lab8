using Microsoft.EntityFrameworkCore;
using SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.Models;
using SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.OtherWindows;
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
        /// <summary>
        /// Инициализация DataGrid записями из базы данных
        /// </summary>
        private void InitDataGridHouses()
        {
            houseContext.Houses.Load();
            DataGrid_Houses.DataContext = houseContext.Houses.ToList();
        }
        /// <summary>
        /// Обработчик события нажатия кнопки Удалить.
        /// Удаляет объект из базы данных.
        /// </summary>
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var houseObj = DataGrid_Houses.SelectedItem;
            if (houseObj == null) return;

            House house = (houseObj as House)!;
            var result = MessageBox.Show($"Удалить\n{house.City}, {house.Street}, {house.Number}?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                houseContext.Houses.Remove(house);
                houseContext.SaveChanges();
                Btn_Update_Click(sender, e);
            }            
        }

        /// <summary>
        /// Обработчик нажатия конпки Обновить.
        /// Обновляет записи в DataGrid.
        /// </summary>
        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            InitDataGridHouses();
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var houseObj = DataGrid_Houses.SelectedItem;
            if(houseObj == null) return;

            House house = (House)houseObj;
            EditHouseWindow editHouse = new EditHouseWindow(house);
            editHouse.Title = "Изменение";
            var result = editHouse.ShowDialog();
            if (result == true)
            {
                houseContext.Houses.Update(house);
                houseContext.SaveChanges();
                Btn_Update_Click(sender,e);
            }


        }
    }
}