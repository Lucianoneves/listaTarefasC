using System;
using System.Windows.Forms;

namespace listaTarefasC
{
    public partial class Form1 : Form
    {
        private readonly string selectedTask;

        public Form1()
        {
            InitializeComponent();
        }

        public int SelectedIndex { get; private set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string task = txtTask.Text.Trim();

            if (!string.IsNullOrEmpty(task))
            {
                int taskNumber = listaTarefas.Items.Count + 1;
                listaTarefas.Items.Add(taskNumber + " ." +  task);
                txtTask.Clear();
            }

            else
            {
                MessageBox.Show("Por favor Insira uma nova Trefa válida", "Ero", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {

            int selectedIndex = listaTarefas.SelectedIndex;

            if (SelectedIndex != -1)
            {
                string newTask = txtTask.Text.Trim();

                string selectedtask = listaTarefas.SelectedIndex.ToString();
                MessageBox.Show("Tarefa selecionada: " + selectedTask, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);



                if (!string.IsNullOrEmpty(newTask))
                {
                    listaTarefas.Items[SelectedIndex] =(selectedIndex +1 ) + "." + newTask;

                    txtTask.Clear();
                }

                else

                {
                    MessageBox.Show("Selecione uma tarefa para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            { 
            MessageBox.Show("Selecione uma tarefa para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }






    private void btnRemove_Click(object sender, EventArgs e)
            {
                if (listaTarefas.SelectedIndex != -1)
                {
                    listaTarefas.Items.RemoveAt(listaTarefas.SelectedIndex);

                   RenumerarLista();
                }
                else
                {
                    MessageBox.Show("Selecione uma tarefa para remover.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void RenumerarLista()   //Metodo para renmera a lista /
        {
            for (int i = 0; i < listaTarefas.Items.Count; i++)
            {
                string task = listaTarefas.Items[i].ToString();
                int index = task.IndexOf(". ");
                if (index != -1)
                {
                    task = task.Substring(index + 2); 
                }
                listaTarefas.Items[i] = (i + 1) + ". " + task;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
            {
            listaTarefas.Refresh();
        }
        }
    }

