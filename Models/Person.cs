using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveAssesment_API.Models
{
 
    public class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string AccountId { get; set; }
        public string IdentityNumber { get; set; }
        public StatementType StatementType { get; set; }

    }
    public enum StatementType
    {
        Insert,
        Select,
        Update,
        Delete,
        SelectById
    }
}