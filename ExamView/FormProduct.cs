using ExamBusinessLogic.BindingModels;
using ExamBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace ExamView
{
    public partial class FormProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ProductLogic productLogic;
        private int? id;
        public FormProduct(ProductLogic productLogic)
        {
            InitializeComponent();
            this.productLogic = productLogic;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = productLogic.Read(new ProductBindingModel
                    {
                        Id = (int)id
                    })?[0];
                    if(view != null)
                    {
                        textBoxName.Text = view.ProductName;
                        textBoxPlaceCreate.Text = view.PlaceCreate;
                        dateTimePickerDateAdd.Value = view.DateAdd;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerDateAdd.Value.Date == null)
            {
                MessageBox.Show("Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPlaceCreate.Text))
            {
                MessageBox.Show("Place", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                productLogic.CreateOrUpdate(new ProductBindingModel
                {
                    Id = id,
                    ProductName = textBoxName.Text,
                    PlaceCreate = textBoxPlaceCreate.Text,
                    DateAdd = dateTimePickerDateAdd.Value
                });
                MessageBox.Show("Success","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
