using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.Models
{
    public  class House
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

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int Number { get => number; set => number = value; }
        public int? Flat { get => flat; set => flat = value; }
        public bool HasElevator { get => hasElevator; set => hasElevator = value; }
        public int? Floor { get => floor; set => floor = value; }
        public int? Tel { get => tel; set => tel = value; }
        public string? Owner { get => owner; set => owner = value; }

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
