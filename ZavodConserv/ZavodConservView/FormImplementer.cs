﻿using System;
using System.Windows.Forms;
using Unity;
using ZavodConservbusinessLogic.BindingModels;
using ZavodConservbusinessLogic.Interfaces;

namespace ZavodConservView
{
    public partial class FormImplementer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IImplementerLogic logic;
        private int? id;

        public FormImplementer(IImplementerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ImplementerBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxFIO.Text = view.ImplementerFIO;
                        textBoxWorkingTime.Text = view.WorkingTime.ToString();
                        textBoxPauseTime.Text = view.PauseTime.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic?.CreateOrUpdate(new ImplementerBindingModel
                {
                    Id = id,
                    ImplementerFIO = textBoxFIO.Text,
                    WorkingTime = Int32.Parse(textBoxWorkingTime.Text),
                    PauseTime = Int32.Parse(textBoxPauseTime.Text),
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
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
