namespace Web.Models
{
    public class AddEmployeeDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required DateOnly HireDate { get; set; }
        public string? JobTitle { get; set; }
        public required int DepartmentID { get; set; }
        public decimal Salary { get; set; }
    }
}
