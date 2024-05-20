namespace RegisterService.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
