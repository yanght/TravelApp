using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Web.Admin.Models.Project
{
    public class EditProjectInput
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string StartDate { get; set; }
        public int State { get; set; }
    }
}
