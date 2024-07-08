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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_
{
    /// <summary>
    /// Логика взаимодействия для HouseViewUserControl.xaml
    /// </summary>
    public partial class HouseViewUserControl : UserControl
    {
        private House house;
        public House House
        {
            get => house;
            set { ViewHouse(value); }
        }

        /// <summary>
        /// Конструктор для создания нового объекта
        /// </summary>
        public HouseViewUserControl()
        {
            InitializeComponent();
            House = new House();
        }

        /// <summary>
        /// Конструктор для редактирования существующего объекта.
        /// </summary>
        public HouseViewUserControl(House house)
        {
            InitializeComponent();
            House = house;
        }

        /// <summary>
        /// Устанавливает объект House для редактирования.
        /// </summary>
        public void ViewHouse(House house)
        {
            this.house = house;
            Grid_Main_HouseView.DataContext = this.house;
        }

        /// <summary>
        /// Применяет введеные значения к объекту.
        /// Обновляет привязку
        /// </summary>
        public void ApplyChanges()
        {
            foreach(var item in Grid_HouseValues.Children)
            {
                if (item is TextBox tb)
                {
                    tb.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if(item is CheckBox cb)
                {
                    cb.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
                }
            }
        }
    }
}
