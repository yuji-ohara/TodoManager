using System;
using System.Collections.Generic;

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
        public bool? Done { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            var dic = new Dictionary<string, string>();

            if (Id.HasValue)
                dic.Add("Id", Id.Value.ToString());

            if (ParentId.HasValue)
                dic.Add("ParentId", ParentId.Value.ToString());

            if (!string.IsNullOrEmpty(Title))
                dic.Add("Title", Title);

            if (!string.IsNullOrEmpty(FreeText))
                dic.Add("FreeText", FreeText);

            if (DueDateFrom.HasValue)
                dic.Add("DueDateFrom", DueDateFrom.Value.ToString("yyyy-MM-dd"));

            if (DueDateTo.HasValue)
                dic.Add("DueDateTo", DueDateTo.Value.ToString("yyyy-MM-dd"));

            if (Done.HasValue)
                dic.Add("Done", Done.Value.ToString());

            return dic;
        }
    }
}
