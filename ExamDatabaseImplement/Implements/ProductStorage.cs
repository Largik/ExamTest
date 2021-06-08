using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using ExamDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamDatabaseImplement.Implements
{
    public class ProductStorage : IProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using (var context = new ExamDBContext())
            {
                return context.Products
                     .Select(rec => new ProductViewModel
                     {
                         Id = rec.Id,
                         ProductName = rec.ProductName,
                         DateAdd = rec.DateAdd,
                         PlaceCreate = rec.PlaceCreate
                     })
                     .ToList();
            }
        }

        public List<ProductViewModel> GetFiltredList(ProductBindingModel model)
        {
            if(model == null)
            {
                return null;
            }
            using(var context = new ExamDBContext())
            {
                return context.Products
                    .Where(rec => rec.ProductName.Contains(model.ProductName))
                    .Select(rec => new ProductViewModel
                    {
                        Id = rec.Id,
                        ProductName = rec.ProductName,
                        DateAdd = rec.DateAdd,
                        PlaceCreate = rec.PlaceCreate
                    })
                    .ToList();
            }
        }
        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ExamDBContext())
            {
                var product = context.Products
                    .FirstOrDefault(rec => rec.ProductName == model.ProductName || rec.Id == model.Id);
                return product != null ?
                    new ProductViewModel
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        DateAdd = product.DateAdd,
                        PlaceCreate = product.PlaceCreate
                    } :
                    null;
            }
        }

        public void Insert(ProductBindingModel model)
        {
            using (var context = new ExamDBContext())
            {
                context.Products.Add(CreateModel(model, new Product()));
                context.SaveChanges();
            } 
        }

        public void Update(ProductBindingModel model)
        {
            using(var context = new ExamDBContext())
            {
                var product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if(product == null)
                {
                    throw new Exception("not found");
                }
                CreateModel(model, product);
                context.SaveChanges();
            }
        }
        public void Delete(ProductBindingModel model)
        {
            using(var context = new ExamDBContext())
            {
                var product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (product == null)
                {
                    throw new Exception("not found");
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
        public Product CreateModel(ProductBindingModel model, Product product)
        {
            product.ProductName = model.ProductName;
            product.DateAdd = model.DateAdd;
            product.PlaceCreate = model.PlaceCreate;
            return product;
        }
    }
}
