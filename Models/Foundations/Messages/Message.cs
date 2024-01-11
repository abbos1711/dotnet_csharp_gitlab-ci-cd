using System;

namespace dosLogistic.API.Models.Foundations.Messages
{
    public class Message
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
