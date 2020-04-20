using System;

namespace WithYou.Web.Data.Entities
{
    public class Leader : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Enrollment { get; set; }
        public DateTime BirthDay { get; set; }
        public string ImageUrl { get; set; }
        public string FullName => $"{LastName} {FirstName}";
    }
}
