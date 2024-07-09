using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.Models
{
    public  class House: INotifyPropertyChanged, IDataErrorInfo
    {
        int id = 0;
        string city = string.Empty;
        string street = string.Empty;
        int number = 0;
        int? flat = null;
        bool hasElevator = false;
        int? floor = null;
        int? tel = null;
        string? owner = null;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
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
        public int Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
        public int? Flat
        {
            get => flat;
            set
            {
                flat = value;
                OnPropertyChanged(nameof(Flat));
            }
        }
        public bool HasElevator
        {
            get => hasElevator;
            set
            {
                hasElevator = value;
                OnPropertyChanged(nameof(HasElevator));
            }
        }
        public int? Floor
        {
            get => floor;
            set
            {
                floor = value;
                OnPropertyChanged(nameof(Floor));
            }
        }
        public int? Tel
        {
            get => tel;
            set
            {
                tel = value;
                OnPropertyChanged(nameof(Tel));
            }
        }
        public string? Owner
        {
            get => owner;
            set
            {
                owner = value;
                OnPropertyChanged(nameof(Owner));
            }
        }

        public string Error => throw new NotImplementedException();
        
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case nameof(Id):
                        if (Id < 0)
                            error = "Неверный Id!";
                        break;
                    case nameof(City):
                        if (City.Length > 50 || City.Length == 0)
                            error = "Неверная длина!";
                        break;
                    case nameof(Street):
                        if (Street.Length > 50 || Street.Length == 0)
                            error = "Неверная длина!";
                        break;
                    case nameof(Number):
                        if (Number < 1)
                            error = "Неверно указан номер дома";
                        break;
                    case nameof(Flat):
                        if (Flat is int f && f < 1)
                            error = "Неверно указан номер квартиры";
                        break;
                    case nameof(Floor):
                        if (Floor is int fl && fl < 0)
                            error = "Неверно указан этаж";
                        break;
                    case nameof(Owner):
                        if (Owner is string && Owner.Length > 50)
                            error = "Слишком длинное поле!";
                        break;

                }
                return error;
            }
        }

        public House() { }

        public House(string city, string street, int number, 
            int? flat = null, bool hasElevator = false, int? floor = null, int? tel = null,
            string? owner = null) :this()
        {
            City = city;
            Street = street;
            Number = number;
            Flat = flat;
            HasElevator = hasElevator;
            Floor = floor;
            Tel = tel;
            Owner = owner;
        }

        public override string ToString()
        {
            string info = $"ID {Id}: {City}, ул. {Street}, дом {Number}, 4кв. {Flat?.ToString()}\n" +
                $"Владелец: {Owner?.ToString()}";
            return info;
        }
    }
}
