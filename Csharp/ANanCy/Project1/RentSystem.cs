using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class RentSystem
    {
        List<RentPair> rentList;
        public RentSystem() {
            rentList = new List<RentPair>();
        }
        public void Rent(Book book, Student student)
        {
            if (book == null)
            {
                return;
            }
            book.Rent();
            var newPair = new RentPair(book, student);
            rentList.Add(newPair);
        }
        public List<RentPair> RentList(Student student)
        {
            var list = new List<RentPair>();
            foreach (var rentPair in rentList)
            {
                Console.WriteLine(rentPair.ToString());
                if (rentPair.SameStudent(student))
                    list.Add(rentPair);
            }
            return list;
        }
        public void DeleteRent(RentPair pair) {
            rentList.Remove(pair);
        }
        
        public override string ToString()
        {
            var result = "";
            foreach (var pair in rentList) {
                result += $"<div>{pair}</div>";
            }
            return result;
        }
    }
    class RentPair
    {
        Book book;
        Student student;
        string date;
        public RentPair(Book book, Student student)
        {
            this.book = book;
            this.student = student;
            this.date = DateTime.Now.ToString();
        }
        public bool SameStudent(Student student)
        {
            return this.student.Equals(student);
        }
        public override string ToString()
        {
            return book+"</div><div>대출일 : "+date;
        }
        public override bool Equals(object obj)
        {
            RentPair pair = (RentPair)obj;
            return pair.student.Equals(student) && pair.book.Equals(book);
        }
    }
}
