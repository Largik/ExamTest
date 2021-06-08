using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.Interfaces;
using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ExamBusinessLogic.BusinessLogic
{
    public  class ProductLogic
    {
        private IProductStorage productStorage;

        public ProductLogic(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if(model == null)
            {
                return productStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { productStorage.GetElement(model) }; 
            }
            return productStorage.GetFiltredList(model);
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            var product = productStorage.GetElement(new ProductBindingModel
            {
                ProductName = model.ProductName
            });
            if(product != null && product.Id != model.Id)
            {
                throw new Exception("added");
            }
            if (model.Id.HasValue)
            {
                productStorage.Update(model);
            }
            else
            {
                productStorage.Insert(model);
            }
        }
        public void Delete(ProductBindingModel model)
        {
            var product = productStorage.GetElement(new ProductBindingModel
            {
                Id = model.Id
            });
            if(product == null)
            {
                throw new Exception("not found");
            }
        }
    }
}
