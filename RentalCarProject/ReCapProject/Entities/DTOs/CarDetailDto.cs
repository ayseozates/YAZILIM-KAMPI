using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public DateTime ImageDate { get; set; }
        public string  ImagePath { get; set; }


    }
}
