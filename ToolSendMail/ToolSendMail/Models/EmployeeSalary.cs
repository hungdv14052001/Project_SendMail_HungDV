using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSendMail.Models
{
    public class EmployeeSalary
    {
        private int id;
        private string name;
        private string position;
        private string email;
        private int basicSalary;
        private int numberDay;
        private int bonus;
        private int deduction;

        public EmployeeSalary()
        {

        }

        public EmployeeSalary(int id, string name, string position, string email, int basicSalary, int numberDay, int bonus, int deduction)
        {
            this.id = id;
            this.name = name;
            this.position = position;
            this.email = email;
            this.basicSalary = basicSalary;
            this.numberDay = numberDay;
            this.bonus = bonus;
            this.deduction = deduction;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Position { get => position; set => position = value; }
        public string Email { get => email; set => email = value; }
        public int BasicSalary { get => basicSalary; set => basicSalary = value; }
        public int NumberDay { get => numberDay; set => numberDay = value; }
        public int Bonus { get => bonus; set => bonus = value; }
        public int Deduction { get => deduction; set => deduction = value; }
    }
}
