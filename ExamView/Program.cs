using ExamBusinessLogic.BusinessLogic;
using ExamBusinessLogic.Interfaces;
using ExamDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ExamView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDishStorage, DishStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<DishLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
