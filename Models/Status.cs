using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveAssesment_API.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string statusType { get; set; }
        public StatementType StatementType { get; set; }

    }
}