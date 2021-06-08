using System;
using System.Collections.Generic;

namespace ExamBusinessLogic.BindingModels
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public DateTime DateAdd { get; set; }
        public string PlaceCreate { get; set; }
    }
}
