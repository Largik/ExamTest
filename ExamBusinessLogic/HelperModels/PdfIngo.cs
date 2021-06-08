using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamBusinessLogic.HelperModels
{
    public class PdfIngo
    {
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportDishProductViewModel> DishProducts { get; set; }
    }
}
