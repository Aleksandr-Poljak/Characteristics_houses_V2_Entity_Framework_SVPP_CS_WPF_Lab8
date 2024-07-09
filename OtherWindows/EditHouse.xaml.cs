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
        // Оригинальный объект 
        public House House; 
        // Временный объект -копия оригинального. Для проверки вводимых данных
        private House tempHouse; 

        public EditHouseWindow(House house)
        {
            InitializeComponent();
            this.House = house; 
            this.tempHouse = createTempHouse(house);
            Grid_EditHouse.DataContext = tempHouse;
        }

        /// <summary>
        /// Создает копию объекта House. 
        /// </summary>
        private House createTempHouse(House origHouse)
        {
            return new House() 
            {   
                Id = origHouse.Id, 
                City = origHouse.City,
                Street=origHouse.Street, 
                Number=origHouse.Number,
                Flat=origHouse.Flat,
                Floor=origHouse.Floor, 
                HasElevator=origHouse.HasElevator,
                Tel=origHouse.Tel, 
                Owner=origHouse.Owner,
            };
        }

        /// <summary>
        /// Переносит данные из временного объекта привязки в переданный объект.
        /// </summary>
        private void dataMigration()
        {
            House.City = tempHouse.City;
            House.Street = tempHouse.Street;
            House.Number = tempHouse.Number;
            House.Flat = tempHouse.Flat;
            House.Floor = tempHouse.Floor;
            House.HasElevator = tempHouse.HasElevator;
            House.Tel = tempHouse.Tel;
            House.Owner = tempHouse.Owner;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки Cохранить.
        /// Проверяет правила валидации,
        /// переносит корректные данные из временного объекта в оригинальный или 
        /// сообщает о ошибке оставляя оригинальный объект без изменений.
        /// </summary>
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            // Флаг срабатывания правил валидации.
            bool HasError = false;
            // проверка корректности заполнения всех полей.
            foreach(var item in Grid_EditHouse.Children)
            {
                if(item is TextBox tb)
                {
                    BindingExpression bindingExpression = tb.GetBindingExpression(TextBox.TextProperty);
                    if(bindingExpression.HasValidationError)
                    {
                        HasError = true;
                    }                        
                }
            }
            // Если данные введны некорректно.
            if (HasError)
            {
                MessageBox.Show("Введенные данные некорректны", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Если все данные введены корректно.
                dataMigration();
                this.DialogResult = true;
                this.Close();
            }                 
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
