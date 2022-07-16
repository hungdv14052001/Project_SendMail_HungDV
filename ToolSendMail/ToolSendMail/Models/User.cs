using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSendMail.Models
{
    public class User : BaseEntity
    {
        private string userName;
        private string email;
        private bool status;
        private string password;
        private string fullName;

        public User() : base()
        {

        }

        public User(int id, string userName, string email, bool status, string password, string fullName) : base(id)
        {
            this.userName = userName;
            this.email = email;
            this.status = status;
            this.password = password;
            this.fullName = fullName;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public bool Status { get => status; set => status = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }
    }
}
