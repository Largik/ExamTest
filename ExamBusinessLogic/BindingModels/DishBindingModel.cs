using System;
using System.Collections.Generic;

namespace ExamBusinessLogic.BindingModels
{
    public class DishBindingModel
    {
        public int? Id { get; set; }
        public string TypeDish { get; set; }
        public DateTime DateImplement { get; set; }
        public Dictionary<int, (string, int)> DishProduct { get; set; }
    }
}
