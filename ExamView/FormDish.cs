using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.BusinessLogic;
using ExamBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ExamView
{
    public partial class FormDish : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly DishLogic dishLogic;
        private int? id;
        private Dictionary<int, (string, int)> dishProducts;
        public FormDish(DishLogic dishLogic)
        {
            InitializeComponent();
            this.dishLogic = dishLogic; 
        }
        private void FormDish_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DishViewModel view = dishLogic.Read(new DishBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if(view != null)
                    {
                        textBoxName.Text = view.TypeDish;
                        dishProducts = view.DishProduct;
                        LoadData();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dishProducts = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if(dishProducts != null)
                {
                    dataGridView.Rows.Clear();
                    foreach(var dish in dishProducts)
                    {
                        dataGridView.Rows.Add(new object[] { dish.Key, dish.Value.Item1, dish.Value.Item2 });
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDishProduct>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (dishProducts.ContainsKey(form.Id))
                {
                    dishProducts[form.Id] = (form.ProductName, form.Count);
                }
                else
                {
                    dishProducts.Add(form.Id, (form.ProductName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDishProduct>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = dishProducts[id].Item2;
                if(form.ShowDialog() == DialogResult.OK)
                {
                    dishProducts[form.Id] = (form.ProductName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("Delete", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        dishProducts.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dishProducts == null || dishProducts.Count == 0)
            {
                MessageBox.Show("Not products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                dishLogic.CreateOrUpdate(new DishBindingModel
                {
                    Id = id,
                    TypeDish = textBoxName.Text,
                    DishProduct = dishProducts,
                });
                MessageBox.Show("Success","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
