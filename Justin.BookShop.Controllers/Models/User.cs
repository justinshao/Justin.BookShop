using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justin.BookShop.Controllers.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public String LoginName { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public Int32 Age { get; set; }
        public Int32 Gender { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Boolean Married { get; set; }
        public String Phone { get; set; }
        public String Position { get; set; }
        public Decimal Salary { get; set; }
        public String Education { get; set; }
        public String School { get; set; }
        public Boolean InUse { get; set; }
        public DateTime AddedTime { get; set; }
        public Boolean IsAdmin { get; set; }
        public Int32 DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public String _state { get; set; }
    }
}
