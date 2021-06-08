using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ExamBusinessLogic.Interfaces
{
    public interface IDishStorage
    {
        List<DishViewModel> GetFullList();
        List<DishViewModel> GetFiltredList(DishBindingModel model);
        DishViewModel GetElement(DishBindingModel model);
        void Insert(DishBindingModel model);
        void Update(DishBindingModel model);
        void Delete(DishBindingModel model);

    }
}
