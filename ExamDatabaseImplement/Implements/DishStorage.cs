using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using ExamDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamDatabaseImplement.Implements
{
    public class DishStorage : IDishStorage
    {
        public List<DishViewModel> GetFullList()
        {
            using (var context = new ExamDBContext())
            {
                return context.Dishes
                    .Include(rec => rec.DishProducts)
                    .ThenInclude(rec => rec.Product)
                    .ToList()
                    .Select(rec => new DishViewModel
                    {
                        Id = rec.Id,
                        TypeDish = rec.TypeDish,
                        DateImplement = rec.DateImplement,
                        DishProduct = rec.DishProducts
                            .ToDictionary(recDishProducts => recDishProducts.ProductId,
                            recDishProducts => (recDishProducts.Product?.ProductName, 
                            recDishProducts.Count))
                    })
                    .ToList();
            }
        }

        public List<DishViewModel> GetFiltredList(DishBindingModel model)
        {
           if(model == null)
           {
                return null;
           }
           using (var context = new ExamDBContext())
            {
                return context.Dishes
                    .Include(rec => rec.DishProducts)
                    .ThenInclude(rec => rec.Product)
                    .Where(rec => 
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateImplement.Date >= model.DateFrom.Value.Date && rec.DateImplement.Date <= model.DateTo.Value.Date))
                    .ToList()
                    .Select(rec => new DishViewModel
                    {
                        Id = rec.Id,
                        TypeDish = rec.TypeDish,
                        DateImplement = rec.DateImplement,
                        DishProduct = rec.DishProducts
                            .ToDictionary(recDishProducts => recDishProducts.ProductId,
                            recDishProducts => (recDishProducts.Product?.ProductName,
                            recDishProducts.Count))
                    })
                    .ToList();
            }
        }

        public DishViewModel GetElement(DishBindingModel model)
        {
            if(model == null)
            {
                return null;
            }
            using(var context = new ExamDBContext())
            {
                var dish = context.Dishes
                    .Include(rec => rec.DishProducts)
                    .ThenInclude(rec => rec.Product)
                    .FirstOrDefault(rec => rec.TypeDish == model.TypeDish || rec.Id == model.Id);
                return dish != null ?
                    new DishViewModel
                    {
                        Id = dish.Id,
                        TypeDish = dish.TypeDish,
                        DateImplement = dish.DateImplement,
                        DishProduct = dish.DishProducts
                            .ToDictionary(recDishProducts => recDishProducts.ProductId,
                            recDishProducts => (recDishProducts.Product?.ProductName,
                            recDishProducts.Count))
                    } : 
                    null;
            }
        }
        public void Insert(DishBindingModel model)
        {
            using (var context = new ExamDBContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Dish(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(DishBindingModel model)
        {
            using(var context = new ExamDBContext())
            {
                using(var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dish = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);

                        if (dish == null)
                        {
                            throw new Exception("not found");
                        }
                        CreateModel(model, dish, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                
            }
        }
        public void Delete(DishBindingModel model)
        {
           using(var context = new ExamDBContext())
            {
                var dish = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
                
                if(dish == null)
                {
                    throw new Exception("not found");
                }
                context.Dishes.Remove(dish);
                context.SaveChanges();
            }
        }
        public Dish CreateModel(DishBindingModel model, Dish dish, ExamDBContext context)
        {
            dish.TypeDish = model.TypeDish;
            if(dish.Id == 0)
            {
                dish.DateImplement = model.DateImplement;
                context.Dishes.Add(dish);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                var dishProducts = context.DishProducts
                    .Where(rec => rec.DishId == model.Id.Value)
                    .ToList();
                context.DishProducts.RemoveRange(dishProducts
                    .Where(rec => !model.DishProduct.ContainsKey(rec.ProductId))
                    .ToList());
                context.SaveChanges();
                foreach(var upd in dishProducts)
                {
                    upd.Count = model.DishProduct[upd.ProductId].Item2;
                    model.DishProduct.Remove(upd.ProductId);
                }
                context.SaveChanges();
                
            }
            foreach (var dProduct in model.DishProduct)
            {
                context.DishProducts.Add(new DishProduct
                {
                    DishId = dish.Id,
                    ProductId = dProduct.Key,
                    Count = dProduct.Value.Item2
                });
                context.SaveChanges();
            }
            return dish;
        }
    }
}
