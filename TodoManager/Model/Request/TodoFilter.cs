using System;

namespace TodoManager.Model.Request
{
    public class TodoFilter
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string FreeText { get; set; }
        public DateTime? DueDateFrom { get; set; }
        public DateTime? DueDateTo { get; set; }
    }
}
