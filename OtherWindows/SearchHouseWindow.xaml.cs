using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для SearchHouseWindow.xaml
    /// </summary>
    public partial class SearchHouseWindow : Window, INotifyPropertyChanged, IDataErrorInfo
    {
        string city = string.Empty;
        string street = string.Empty;
        int? number;

        public string City 
        {
            get => city; 
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string Street
        { 
            get => street;
            set
            {
                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }
        public int? Number 
        { 
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(City):
                        if (City.Length == 0 || string.IsNullOrWhiteSpace(City))
                            error = "Укажите город!";
                        break;
                    case nameof(Street):
                        if (Street.Length == 0 || string.IsNullOrWhiteSpace(Street))
                            error = "Укажите улицу!";
                        break;
                    case nameof(Number):
                        if (Number is not null && (int)Number < 1)
                            error = "Неверно указан номер дома!";
                        break;
                }
                return error;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public SearchHouseWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            TextBox_SearchCity.Focus();
        }

        /// <summary>
        /// Обработчик события нажатия конпоки Поиск.
        /// Проверяет введенные данные, если данные корректны- сохраняет их и закрывает окно.
        /// Если данные не прошли валидацию- отображет окно с уведомлением об ошибке и задает фокус
        /// на неверно заполненом элементе.
        /// </summary>
        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            bool hasError = false;
            foreach(var item in Grid_Search.Children)
            {
                if(item is TextBox tb)
                {
                   if( tb.GetBindingExpression(TextBox.TextProperty).HasValidationError)
                   {
                       hasError = true;
                        tb.Focus();
                   }
                }
            }
            if(hasError)
            {
                MessageBox.Show("Ошибочно заполнены или не заполнены полностью поля поиска", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                this.Focus();
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
         
        }

        /// <summary>
        /// Обработчик нажатия кнопки Отмена.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SearchCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
