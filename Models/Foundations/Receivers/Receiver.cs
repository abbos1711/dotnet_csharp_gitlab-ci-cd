using System;
using System.Text.Json.Serialization;

namespace dosLogistic.API.Models.Foundations.Receivers
{
    public class Receiver
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string PassportJshshir { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
