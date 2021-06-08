
namespace ExamView
{
    partial class FormProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDateAdd = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPlace = new System.Windows.Forms.Label();
            this.textBoxPlaceCreate = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateAdd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // labelDateAdd
            // 
            this.labelDateAdd.AutoSize = true;
            this.labelDateAdd.Location = new System.Drawing.Point(19, 54);
            this.labelDateAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateAdd.Name = "labelDateAdd";
            this.labelDateAdd.Size = new System.Drawing.Size(86, 13);
            this.labelDateAdd.TabIndex = 18;
            this.labelDateAdd.Text = "Дата поставки:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(300, 133);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(192, 133);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 28);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(172, 18);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(228, 20);
            this.textBoxName.TabIndex = 13;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(19, 18);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Название:";
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(19, 87);
            this.labelPlace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(116, 13);
            this.labelPlace.TabIndex = 21;
            this.labelPlace.Text = "Место производства:";
            // 
            // textBoxPlaceCreate
            // 
            this.textBoxPlaceCreate.Location = new System.Drawing.Point(172, 83);
            this.textBoxPlaceCreate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPlaceCreate.Name = "textBoxPlaceCreate";
            this.textBoxPlaceCreate.Size = new System.Drawing.Size(228, 20);
            this.textBoxPlaceCreate.TabIndex = 20;
            // 
            // dateTimePickerDateAdd
            // 
            this.dateTimePickerDateAdd.Location = new System.Drawing.Point(172, 54);
            this.dateTimePickerDateAdd.Name = "dateTimePickerDateAdd";
            this.dateTimePickerDateAdd.Size = new System.Drawing.Size(228, 20);
            this.dateTimePickerDateAdd.TabIndex = 22;
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 177);
            this.Controls.Add(this.dateTimePickerDateAdd);
            this.Controls.Add(this.labelPlace);
            this.Controls.Add(this.textBoxPlaceCreate);
            this.Controls.Add(this.labelDateAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "FormProduct";
            this.Text = "Продукт";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDateAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.TextBox textBoxPlaceCreate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateAdd;
    }
}