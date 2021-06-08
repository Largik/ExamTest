using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ExamBusinessLogic.BusinessLogic
{
    public class DishLogic
    {
        private IDishStorage dishStorage;

        public DishLogic(IDishStorage dishStorage)
        {
            this.dishStorage = dishStorage;
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            if(model == null)
            {
                return dishStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DishViewModel> { dishStorage.GetElement(model) };
            }
            return dishStorage.GetFiltredList(model);
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            var dish = dishStorage.GetElement(new DishBindingModel
            {
                TypeDish = model.TypeDish
            });
            if (dish != null && dish.Id != model.Id)
            {
                throw new Exception("Уже есть такое блюдо");
            }
            if (model.Id.HasValue)
            {
                dishStorage.Update(new DishBindingModel
                {
                    Id = model.Id,
                    TypeDish = model.TypeDish,
                    DishProduct = model.DishProduct
                });
            }
            else
            {
                dishStorage.Insert(new DishBindingModel
                {
                    TypeDish = model.TypeDish,
                    DishProduct = model.DishProduct,
                    DateImplement = DateTime.Now
                });
            }
        }
        public void Delete(DishBindingModel model)
        {
            var dish = dishStorage.GetElement(new DishBindingModel
            {
                Id = model.Id
            });
            if(dish == null)
            {
                throw new Exception("Dish not found");
            }
            dishStorage.Delete(model);
        }
    }
}
