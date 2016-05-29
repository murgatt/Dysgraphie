using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie
{
    public class Child
    {
        public String name;
        public String forename;
        public DateTime birth;
        public int age;
        public String grade;
        public String laterality;
        public String gender;

        public Child(String name, String forename, DateTime birth, String grade, String laterality, String gender)
        {
            this.name = name;
            this.forename = forename;
            this.birth = birth;
            this.grade = grade;
            this.laterality = laterality;
            this.gender = gender;
            DateTime today = DateTime.Today;
            age = today.Year - birth.Year;
            if (birth > today.AddYears(-age))
            {
                age--;
            }
        }
    }
}
