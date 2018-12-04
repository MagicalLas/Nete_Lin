using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Book
    {
        string name = "";
        string auther = "";
        string number = "";
        bool is_rent = false;
        public Book(string name)
        {
            this.name = name;
        }
        public Book(string name, string number) : this(name)
        {
            this.number = number;
        }
        public Book(string name, string number, string auther) : this(name, number)
        {
            this.auther = auther;
        }
        public Book(string name, string number, string auther, bool is_rent) : this(name, number, auther)
        {
            this.is_rent = is_rent;
        }
        public string Name {
            get {
                return name;
            }
        }
        public string Auther {
            get {
                return auther;
            }
        }
        public override string ToString()
        {
            return $"{name}, {number}, {auther}, {is_rent}";
        }
        public bool IsBookNumber(string number) {
            return this.number.Equals(number);
        }
        public bool CompareByNameAndAuther(string name, string auther) {
            return name.Equals(this.Name) && auther.Equals(this.Auther);
        }
        public void Rent() {
            is_rent = false;
        }
        public void NotRent() {
            is_rent = true;
        }
        public override bool Equals(object obj)
        {
            Book b = (Book)obj;
            return b.number == this.number;
        }
    }
}
