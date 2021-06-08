using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExamBusinessLogic.ViewModels
{
    [DataContract]
    public class ReportDishProductViewModel
    {
        [DataMember]
        public string DishName { get; set; }
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DataMember]
        public List<Tuple<string, int>> Product { get; set; }
    }
}
