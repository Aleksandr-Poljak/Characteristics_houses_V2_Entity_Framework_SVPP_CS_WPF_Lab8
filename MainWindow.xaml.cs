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
            Loaded += MainWindow_Loaded;
        }

        /// <summary>
        /// Обрбаботчик события загрузки окна
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           InitDataGridHouses();
        }

        /// <summary>
        /// Инициализация DataGrid записями из базы данных
        /// </summary>
        private void InitDataGridHouses()
        {
            houseContext.Houses.Load();
            DataGrid_Houses.ItemsSource = houseContext.Houses.Local.ToBindingList();
        }

        /// <summary>
        /// Перезагружает DataGrid/
        /// </summary>
        private void ReloadDataGrid()
        {
            houseContext.Houses.Load();
            DataGrid_Houses.ItemsSource = null;
            DataGrid_Houses.ItemsSource = houseContext.Houses.Local.ToBindingList();
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
            ReloadDataGrid();
        }

        /// <summary>
        /// Орбаботчик нажатия кнопки Изменить.
        /// Открывает окно для редактирования объекта.Сохраняет объект в базе данных
        /// после изменения.
        /// </summary>
        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var houseObj = DataGrid_Houses.SelectedItem;
            if (houseObj == null) return;

            House house = (houseObj as House)!;
            EditHouseWindow edithouseWindow = new EditHouseWindow(house) {Owner=this};
            edithouseWindow.Title = "Изменение";
            var result = edithouseWindow.ShowDialog();
            if (result == true)
            {        
                houseContext.Houses.Update(house);               
                houseContext.SaveChanges(true);                         
            }
            Btn_Update_Click(sender, e);
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить.
        /// Открывает окно создания записи.
        /// </summary>
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            House house = new();
            EditHouseWindow editHouseWindow = new EditHouseWindow(house) { Owner=this};
            editHouseWindow.Title = "Добавить запись";
            var result = editHouseWindow.ShowDialog();
            if(result == true)
            {
                houseContext.Houses.Add(house);
                houseContext.SaveChanges(true);
                MessageBox.Show("Запись добавлена","Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            Btn_Update_Click(sender , e);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки Найти.
        /// Находит записи  в базе данных совпадающие с критериями поиска.
        /// </summary>
        private void Btn_Find_Click(object sender, RoutedEventArgs e)
        {
            // Запрос данных для поиска в новом окне.
            SearchHouseWindow searchHouseWindow = new SearchHouseWindow();
            var result = searchHouseWindow.ShowDialog();
            if (result == true)
            {
                // Извлечение данных для поиска
                // (Корректность данных проверятеся в логике окна поиска)
                string city = searchHouseWindow.City;
                string street = searchHouseWindow.Street;
                int? number = searchHouseWindow.Number;

                // Поиск по данным (Поиск включением данных)
                var housesQuery = houseContext.Houses.AsQueryable();

                housesQuery = housesQuery.Where(h=>h.City.Contains(city));
                housesQuery = housesQuery.Where(h => h.Street.Contains(street));
                if(number is not null)
                {
                    int num = (int)number;
                    housesQuery = housesQuery.Where(h => h.Number==num);
                }
                // Отображение результатов
                var filteredHouses = housesQuery.ToList();
                DataGrid_Houses.ItemsSource = filteredHouses;
            }
        }

        /// <summary>
        /// Обрабочик события загрузки строк DataGrid
        /// </summary>
        private void dGridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Нумерация строк
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}