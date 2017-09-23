namespace Web.Models
{
    public class ChildModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }

        public string Combine { get; set; }

        public string KindergardenAddress { get; set; }
        public int? KindergratenNumber { get; set; }

        public Kindergarden Kindergarden { get; set; }

        public int GartenId { get; set; }
    }
}