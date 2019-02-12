using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using TravelApp.Travel;

namespace TravelApp.EntityMapper.Categorys
{
    public class CategoryMapper : ClassMapper<Category>
    {
        public CategoryMapper()
        {
            Table("Categorys");
            AutoMap();
        }
    }
}
