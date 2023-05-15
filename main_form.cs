using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knapsack_problems
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();  
        }

        //метод, необходимый для добавления данных в БД
        public void recording_the_solution(string Task_type, int Backpack_weight, int Number_of_items, int Answer, string Items)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<MyDBNames.Scheme.ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (MyDBNames.Scheme.ApplicationContext db = new MyDBNames.Scheme.ApplicationContext(options))
          
            {
                MyDBNames.Scheme.Solving_the_backpack_problem Solving_the_backpack_problem = new MyDBNames.Scheme.Solving_the_backpack_problem { Task_type = Task_type, Backpack_weight = Backpack_weight, Number_of_items = Number_of_items, Answer = Answer, Items = Items, Date_time = DateTime.Now };
                db.Solving_the_backpack_problem.Add(Solving_the_backpack_problem);
                db.SaveChanges();
            }    
        }

        //нажатие на кнопку "получить решение"
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                option_with_cost newForm = new option_with_cost(this);
                newForm.Show();
            }

            else if (!checkBox1.Checked)
            {
                simple_option newForm = new simple_option(this);
                newForm.Show();
            }
        }
        //управление компонентами checkBox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }
        //ограничение на ввод предметов более 100 штук
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >300)
            {
                MessageBox.Show("Количество предметов не может превышать 300!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //переход к форме с БД из меню
        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_db newForm = new show_db();
            newForm.Show();
        }
        //нажатие на кнопку "Выбрать исходные данные из файла"
        private void button2_Click(object sender, EventArgs e)
        {
            task_from_a_file newForm = new task_from_a_file(this);
            newForm.Show();
        }
        private void main_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = numericUpDown1;
        }
    }
}
