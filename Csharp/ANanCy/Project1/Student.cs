using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Student
    {
        string name;
        int grade;
        int room;
        Student(string name) {
            this.name = name;
        }
        Student(string name, int grade) : this(name) {
            this.grade = grade;
        }
        public Student(string name, int grade, int room) : this(name, grade)
        {
            this.room = room;
        }
        public bool Equals(Student obj)
        {
            var nameIsSame = obj.name.Equals(this.name);
            var roomIsSame = obj.room.Equals(this.room);
            return nameIsSame && roomIsSame;
        }
        public override string ToString()
        {
            return $"{name} : {grade}-{room}";
        }
    }
}
