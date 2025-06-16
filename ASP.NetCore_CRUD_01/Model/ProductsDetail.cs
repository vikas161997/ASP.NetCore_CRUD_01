using System.ComponentModel.DataAnnotations;

namespace ASP.NetCore_CRUD_01.Model
{
    public class ProductsDetail
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public DateTime dateOfJoining { get; set; }
    }



}
