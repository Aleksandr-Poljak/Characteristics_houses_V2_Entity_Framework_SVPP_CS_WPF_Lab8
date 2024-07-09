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

        public EditHouseWindow(ref House house)
        {
            InitializeComponent();
            this.House = house; 
            Grid_EditHouse.DataContext = this.House;
        }
        /// <summary>
        /// Обработчик события нажатия кнопки Cохранить.
        /// Сохраняет в свойствах объекта данные из полей ввода.
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
                    bindingExpression.UpdateSource(); // Обновление привязки.
                    if(bindingExpression.HasError) HasError = true;
                }
                if(item is CheckBox cb)
                {
                    cb.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                }
            }
            // Если все данные введены корректно.
            if (!HasError)
            {
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
