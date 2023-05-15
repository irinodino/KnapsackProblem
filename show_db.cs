using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knapsack_problems
{
    public partial class show_db : Form
    {
       
        public show_db()
        {
            InitializeComponent();
        }

        private void show_db_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "knapsack_problems_dbDataSet.Solving_the_backpack_problem". При необходимости она может быть перемещена или удалена.
            this.solving_the_backpack_problemTableAdapter.Fill(this.knapsack_problems_dbDataSet.Solving_the_backpack_problem);
            //запрет на добавление строк пользователем
            dataGridView1.AllowUserToAddRows = false;
        }
        //нажатие на кнопку "Закрыть"
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
