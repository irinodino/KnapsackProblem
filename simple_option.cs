using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace Knapsack_problems
{
    public partial class simple_option : Form
    {
        public main_form mainForm = null;
        public simple_option(main_form f)
        {
            InitializeComponent();
            mainForm = f;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void simple_option_Load(object sender, EventArgs e)
        {
            //устанавливаем фокус на компонент textBox1
            this.ActiveControl = textBox1;

            //из главной формы получаем значение компонента numericUpDown1
            decimal number_of_items_decimal = mainForm.numericUpDown1.Value;
            int number_of_items = Convert.ToInt32(number_of_items_decimal);

            //Создание таблицы для ввода данных пользователем
            dataGridView1.ColumnCount = number_of_items + 1; //кол-во столбцов

            //если каждый предмет имеется в единственном или неограниченном экземпляре
            if (mainForm.checkBox2.Checked || mainForm.checkBox3.Checked)
            {
                dataGridView1.RowCount = 2; //кол-во строк 

                for (int i = 0; i < 2; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                }
            }

            //если каждый предмет имеется в ограниченном экземпляре
            else if (mainForm.checkBox4.Checked)
            {
                dataGridView1.RowCount = 3; //кол-во строк 
                dataGridView1.Rows[2].Cells[0].Value = "Количество предметов";

                for (int i = 0; i < 3; i++)
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                }
            }

            dataGridView1.Rows[0].Cells[0].Value = "№ предмета";
            dataGridView1.Rows[1].Cells[0].Value = "Вес предмета";

            for (int i = 1; i < number_of_items + 1; ++i)
                dataGridView1.Rows[0].Cells[i].Value = "Предмет № " + i;

        }
        //переход из меню на главную страницу
        private void главнаяСтраницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_form mainForm = new main_form();
            mainForm.Show();
        }
        //нажатие на кнопку "Получить решение"
        private void button1_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox3.Text = "";
            not_visible(sender, e); //скрытие элементов формы
            //переменная, необходимая для того, чтобы определить, возникли ошибки или нет 
            bool ex = true;
            //переменные, для определения того, отмечен или не отмечен компонент checkBox главной формы
            bool c2 = mainForm.checkBox2.Checked;
            bool c3 = mainForm.checkBox3.Checked;
            bool c4 = mainForm.checkBox4.Checked;
            //если компонент textBox, предназначенный для ввода веса рюкзака, не пустой
            if (textBox1.Text != string.Empty)
            {
                for (int i = 1; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        //если хотя бы одна из ячеек таблицы пуста
                        if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[j].Value as String))
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Заполните все ячейки таблицы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.ActiveControl = dataGridView1;
                            ex = false;

                            break;
                        }
                        //проверяем, что пользователь ввел целые числа
                        if (!int.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), out var outParse1))
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Введите в ячейки целые числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.ActiveControl = dataGridView1;
                            ex = false;

                            break;
                        }
                        //проверяем, что пользователь ввел положительные числа
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) <= 0)
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Вы ввели не положительные числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.ActiveControl = dataGridView1;
                            ex = false;

                            break;
                        }
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) > 2000000000)
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("В ячейки можно вводить числа не более 2000000000!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.ActiveControl = dataGridView1;
                            ex = false;

                            break;
                        }
                    }
                    if (ex == false)
                    {
                        break;
                    }
                }
            }
            //если пользователь ввел корректные данные
            if (int.TryParse(textBox1.Text, out var outParse) && ex == true && Convert.ToInt32(textBox1.Text) > 0 && Convert.ToInt32(textBox1.Text) <= 5000 && textBox1.Text != string.Empty)
                {
                int number_of_things = dataGridView1.ColumnCount - 1; //количество предметов
                int maxCapacity = Convert.ToInt32(textBox1.Text); //объем рюкзака

                Item.items = new Item[number_of_things];//хранит данные о каждом предмете
                //если каждый предмет имеется в единственном или неограниченном количестве
                if (mainForm.checkBox2.Checked || mainForm.checkBox3.Checked)
                {
                    for (int i = 0; i < number_of_things; i++)
                    {
                        Item.items[i] = new Item(dataGridView1.Rows[0].Cells[i + 1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[1].Cells[i + 1].Value), 0, 0);
                    }
                }
                //если каждый предмет имеется в ограниченном количестве
                else if (mainForm.checkBox4.Checked )
                {
                    for (int i = 0; i < number_of_things; i++)
                    {
                        Item.items[i] = new Item(dataGridView1.Rows[0].Cells[i + 1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[1].Cells[i + 1].Value), 0, Convert.ToInt32(dataGridView1.Rows[2].Cells[i + 1].Value));
                    }
                }
                
                int sum = 0; //суммарный вес всех предметов
                bool check = false;//проверка, что хотя бы один из предметов имеет меньший вес, чем вес рюкзака
                for (int i = 0; i < Item.items.Length; i++)
                {
                    //если каждый предмет имеется в единственном или неограниченном количестве
                    if (mainForm.checkBox2.Checked || mainForm.checkBox3.Checked)
                    {
                        sum += Item.items[i].weight;
                    }
                    //если каждый предмет имеется в ограниченном количестве
                    else if (mainForm.checkBox4.Checked)
                    {
                        sum += Item.items[i].weight * Item.items[i].quantity;
                    }
                    //если хотя бы один из предметов имеет меньший вес, чем вес рюкзака,
                    //присвоить переменной check значение true
                    if (maxCapacity >= Item.items[i].weight)
                    {
                        check = true;
                    }
                }

                //если вес рюкзака меньше суммарного веса всех предметов и
                //имеется хотя бы один предмет, вес которого меньше, чем вес рюкзака
                if (maxCapacity < sum && check == true) 
                {
                    if (mainForm.checkBox2.Checked)
                    {
                        visible(sender, e); //отображение компонентов формы
                        //вывод в компонент textBox2 максимального веса предметов
                        textBox2.Text = Convert.ToString(simple_algorithm.max_weight(Item.items, maxCapacity, c2, c3, c4));
                        //вывод набора предметов в компонент textBox3
                        textBox3.Text = Convert.ToString(simple_algorithm.arr_items[Item.items.Length, maxCapacity]);

                        decimal number_of_items_decimal = mainForm.numericUpDown1.Value;
                        int number_of_items = Convert.ToInt32(number_of_items_decimal);
                        //запись результатов в БД
                        if (checkBox1.Checked)
                            mainForm.recording_the_solution("Задача без стоимости и предметами в единственном экземпляре", maxCapacity, number_of_items,  Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                    }
                    //если каждый предмет имеется в ограниченном количестве
                    else if (mainForm.checkBox4.Checked)
                    {
                        visible(sender, e); //отображение компонентов формы
                        //вывод в компонент textBox2 максимального веса предметов
                        textBox2.Text = Convert.ToString(simple_algorithm.max_weight(Item.items, maxCapacity, c2, c3, c4));
                        //вывод набора предметов в компонент textBox3
                        textBox3.Text = Convert.ToString(simple_algorithm.arr_items[Item.items.Length, maxCapacity]);

                        decimal number_of_items_decimal = mainForm.numericUpDown1.Value;
                        int number_of_items = Convert.ToInt32(number_of_items_decimal);

                        //запись результатов в БД
                        if (checkBox1.Checked)
                            mainForm.recording_the_solution("Задача без стоимости и предметами в ограниченном количестве", maxCapacity, number_of_items, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                    }
                }
                //если суммарный вес предметов больше или равен весу рюкзака
                //и каждый предмет имеется в единственном или неограниченном экземпляре
                else if (mainForm.checkBox2.Checked && maxCapacity >= sum || mainForm.checkBox4.Checked && maxCapacity >= sum)
                {
                    not_visible(sender, e); //скрытие элементов формы
                    MessageBox.Show("Cуммарный вес всех вещей должен превышать вместимость рюкзака!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //если нет ни одного предмета, вес которого меньше, чем вес рюкзака
                else if (mainForm.checkBox2.Checked && check == false || mainForm.checkBox4.Checked && check == false)
                {
                    label3.Visible = true;
                    textBox3.Visible = true;
                    textBox3.Text = "Такого набора нет";
                }
                //если каждый предмет имеется в неограниченном экзепляре
                //и имеется хотя бы один предмет, вес которого меньше, чес вес рюкзака
                if (mainForm.checkBox3.Checked && check == true)
                {
                    //вывод в компонент textBox2 максимального веса предметов
                    textBox2.Text = Convert.ToString(simple_algorithm.max_weight(Item.items, maxCapacity, c2, c3, c4));
                    string items = Convert.ToString(simple_algorithm.arr_items[Item.items.Length, maxCapacity]);
                    
                    //преобразование набора предметов
                    string result = " ";
                    int k = 0;

                    for (int i = 1; i < 101; i++)
                    {
                        string item_number = Convert.ToString(i);
                        for (int j = 1; j < items.Length; j++)
                        {
                            if (Convert.ToString(items[j]) == item_number)
                            {
                                k++;
                            } 
                        }

                        if (k>0)
                        {
                            result += "Предмет №" + i + "(" + k + " шт.) ";
                        }

                        k = 0;
                    }
                    //вывод набора предметов в компонент textBox3
                    textBox3.Text = result;
                    visible(sender, e); //отображение компонентов формы

                    decimal number_of_items_decimal = mainForm.numericUpDown1.Value;
                    int number_of_items = Convert.ToInt32(number_of_items_decimal);
                    //запись результатов в БД
                    if (checkBox1.Checked)
                        mainForm.recording_the_solution("Задача без стоимости и предметами в неограниченном количестве", maxCapacity, number_of_items, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                }

                else if (mainForm.checkBox3.Checked && check == false)
                {
                    label3.Visible = true;
                    textBox3.Visible = true;
                    textBox3.Text = "Такого набора нет";
                }
            }
            else if (int.TryParse(textBox1.Text, out var outParse2) && textBox1.Text != string.Empty && Convert.ToInt32(textBox1.Text) > 0)
            {
                if (Convert.ToInt32(textBox1.Text) > 5000)
                {
                    not_visible(sender, e); //скрытие элементов формы
                    MessageBox.Show("Вес рюкзака не может превышать 5000!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ActiveControl = textBox1;
                }
            }
            //проверки корректного ввода веса рюкзака
            else if (textBox1.Text == string.Empty)
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Введите вес рюкзака!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = textBox1;
            }
            else if (!int.TryParse(textBox1.Text, out var outParsee))
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Вес рюкзака должен быть целым числом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = textBox1;
            }
            else if (Convert.ToInt32(textBox1.Text) <= 0)
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Вес рюкзака должен быть положительным числом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = textBox1;
            }
        }

        //нажатие на кнопку "Закрыть"
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // переход из главного меню к форме с БД
        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_db newForm = new show_db();
            newForm.Show();
        }
        
        //нажатие на кнопку "Печать результатов"
        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font myFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            string date = "Дата: " + DateTime.Now;
            string task_type = "";
            if (mainForm.checkBox2.Checked)
                task_type = "Тип задачи: без стоимости, каждый предмет имеется в единственном экземпляре";
            else if (mainForm.checkBox3.Checked)
                task_type = "Тип задачи: без стоимости, каждый предмет имеется в неограниченном количестве";
            else if (mainForm.checkBox4.Checked)
                task_type = "Тип задачи: без стоимости, каждый предмет имеется в ограниченном количестве";

            string Backpack_weight = "Вес рюкзака: " + textBox1.Text;
            string Number_of_items = "Количество предметов: " + Convert.ToString(mainForm.numericUpDown1.Value);
            string Answer = "Ответ: " + textBox2.Text;
            string Items = "Набор предметов: " + textBox3.Text;

            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            e.Graphics.DrawString(date, myFont, Brushes.Black, 40, 40);
            e.Graphics.DrawString("Исходные данные:", myFont, Brushes.Black, 40, 100);
            e.Graphics.DrawString(task_type, myFont, Brushes.Black, 40, 130);
            e.Graphics.DrawString(Backpack_weight, myFont, Brushes.Black, 40, 160);
            e.Graphics.DrawString(Number_of_items, myFont, Brushes.Black, 40, 190);
            e.Graphics.DrawString("Результаты:", myFont, Brushes.Black, 40, 250);
            e.Graphics.DrawString(Answer, myFont, Brushes.Black, 40, 280);
            e.Graphics.DrawString (Items, myFont, Brushes.Black, new RectangleF(40, 310, 770, 800));

        }
        //нажатие на кнопку "Сохранить результаты в файл"
        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            string task_type = "";
            if (mainForm.checkBox2.Checked)
                task_type = "Тип задачи: без стоимости, каждый предмет имеется в единственном экземпляре";
            else if (mainForm.checkBox3.Checked)
                task_type = "Тип задачи: без стоимости, каждый предмет имеется в неограниченном количестве";
            else if (mainForm.checkBox4.Checked)
                task_type = "Тип задачи: без стоимости, каждый предмет имеется в ограниченном количестве";

            string filenameText = "Дата: " + DateTime.Now + Environment.NewLine+ Environment.NewLine + "Исходные данные:" + Environment.NewLine + "Тип задачи: " + task_type + Environment.NewLine + "Вес рюкзака: " + textBox1.Text + Environment.NewLine + "Количество предметов: " + Convert.ToString(mainForm.numericUpDown1.Value) + Environment.NewLine+ Environment.NewLine + "Результаты:" + Environment.NewLine + "Ответ: " + textBox2.Text + Environment.NewLine + "Набор предметов: " + textBox3.Text;
            System.IO.File.WriteAllText(filename, filenameText);
            MessageBox.Show("Файл сохранен");
        }

        private void not_visible(object sender, EventArgs e) //скрытие элементов формы
        {
            button4.Visible = false;
            button6.Visible = false;
            label3.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
        }
        private void visible(object sender, EventArgs e) //отображение элементов формы
        {
            label2.Visible = true;
            button6.Visible = true;
            button4.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }

    }
}
