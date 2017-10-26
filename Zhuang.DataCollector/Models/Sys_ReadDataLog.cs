using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector.Models
{
    public class Sys_ReadDataLog
    {
        [Zhuang.Data.Annotations.Key]
        public string Id { get; set; }

        public string DataPath { get; set; }

        public long CursorPosition { get; set; }

        public string RuleText { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
