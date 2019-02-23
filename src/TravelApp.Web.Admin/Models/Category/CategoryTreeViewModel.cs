using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelApp.Web.Admin.Models.Category
{
    public class CategoryTreeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Open { get; set; }
        public bool Checked { get; set; }
        public List<CategoryTreeViewModel> Children { get; set; }
    }
}
