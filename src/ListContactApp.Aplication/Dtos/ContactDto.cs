namespace ListContactApp.Aplication.Dtos
{
    public class ContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Category Category { get; set; }
        public string SubCategory { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
