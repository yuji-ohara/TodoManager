using System;

namespace Models
{
    public class Todo
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string ExtendedDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
    }
}
