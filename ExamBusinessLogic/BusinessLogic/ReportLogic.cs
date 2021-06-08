using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ExamBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IDishStorage dishStorage;
        public ReportLogic(IDishStorage dishStorage)
        {
            this.dishStorage = dishStorage;
        }
        public List<ReportDishProductViewModel> GetOrders(ReportBindingModel model)
        {
            var dishs = dishStorage.GetFiltredList(new DishBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<ReportDishProductViewModel>();
            foreach(var dish in dishs)
            {
                var record = new ReportDishProductViewModel
                {
                    DishName = dish.TypeDish,
                    DateCreate = dish.DateImplement,
                    Product = new List<Tuple<string, int>>()
                };
                foreach(var product in dish.DishProduct)
                {
                    record.Product.Add(new Tuple<string, int>(product.Value.Item1, product.Value.Item2));
                }
                list.Add(record);
            }
            return list;
        }
        public void SaveJSONDataContract(ReportBindingModel model)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(List<ReportDishProductViewModel>));
            using(FileStream fs = new FileStream("otchet.json", FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, GetOrders(model));
            }
        }
    }
}
