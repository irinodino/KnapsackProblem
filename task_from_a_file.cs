using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Knapsack_problems
{
    public partial class task_from_a_file : Form
    {
        public main_form mainForm = null;
        public task_from_a_file(main_form f)
        {
            InitializeComponent();
            mainForm = f;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        //нажатие на кнопку "Выберите файл"
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button6.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);

            var regex = new Regex(@"(?s)(?<=выше:).+?(?=Введите)");
            var regex_backpack_weight = new Regex(@"(?s)(?<=числом).+?(?=Введите)");
            var regex_number_of_items = new Regex(@"(?s)(?<=запятую:).+?(?=Введите)");
            var regex_items_weight = new Regex(@"(?s)(?<=Вес\sдолжен\sбыть\sцелым\sположительным\sчислом).+?(?=Если)");
            var regex_items_cost = new Regex(@"(?s)(?<=Стоимость\sдолжна\sбыть\sцелым\sположительным\sчислом).+?(?=Если)");
            var regex_items_quantity = new Regex(@"(?s)(?<=предмета:).*");

            MatchCollection matches = regex.Matches(fileText);
            MatchCollection matches1 = regex_backpack_weight.Matches(fileText);
            MatchCollection matches2 = regex_number_of_items.Matches(fileText);
            MatchCollection matches3 = regex_items_weight.Matches(fileText);
            MatchCollection matches4 = regex_items_cost.Matches(fileText);
            MatchCollection matches5 = regex_items_quantity.Matches(fileText);

            string task_type = "";
            string backpack_weight = "";
            string number_of_items = "";
            string items_weight = "";
            string items_cost = "";
            string items_quantity = "";

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    task_type = match.Value;
                richTextBox1.Text += "Тип задачи: " + task_type;
            }
            if (matches1.Count > 0)
            {
                foreach (Match match in matches1)
                    backpack_weight = match.Value;
                richTextBox1.Text += "Вес рюкзака: " + backpack_weight;
            }

                if (matches2.Count > 0)
            {
                foreach (Match match in matches2)
                    number_of_items = match.Value;
                richTextBox1.Text += "Предметы: " + number_of_items;
            }
            if (matches3.Count > 0)
            {
                foreach (Match match in matches3)
                    items_weight = match.Value;
                richTextBox1.Text += "Вес предметов:" + items_weight;
            }
            if (matches4.Count > 0)
            {
                foreach (Match match in matches4)
                    items_cost = match.Value;
                
            }
            if (matches5.Count > 0)
            {
                foreach (Match match in matches5)
                    items_quantity = match.Value;
            }

            string numb = number_of_items.Trim();
            string[] arr_number_of_items = numb.Split(',');
            string[] arr_items_weight = items_weight.Split(',');
            Item.items = new Item[arr_items_weight.Length]; //хранит данные о каждом предмете
            //переменные, для определения того, отмечен или не отмечен компонент checkBox главной формы
            bool c2 = false;
            bool c3 = false;
            bool c4 = false;
            //проверка, что хотя бы один из предметов имеет меньший вес, чем вес рюкзака
            bool check = false;
            //проверка того, что количество предметов соответствует количеству других параметров
            bool check_validation = true;
            string task_type_without_space = task_type.Trim();
            string bw = backpack_weight.Trim();
            int sum = 0;
            string noi = number_of_items.Trim(); 
            for (int i = 0; i < arr_items_weight.Length; i++)
            {
                //проверяем, что вес каждого предмета является целым числом не равным 0
                if ((!uint.TryParse(Convert.ToString(arr_items_weight[i]), out var outParse2) || Convert.ToInt32(arr_items_weight[i]) == 0) && fileText != string.Empty)
                {
                    not_visible(sender, e); //скрытие элементов формы
                    MessageBox.Show("Веса предметов введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    check_validation = false;
                }
            }
            //если вес рюкзака - число, не равен 0,yt ghtdsiftn 5000, не пустой, количество предметов равно количеству весов
            if (uint.TryParse(backpack_weight, out var outParse1) && Convert.ToInt32(backpack_weight) != 0 && noi != "" && check_validation == true && arr_number_of_items.Length == arr_items_weight.Length && Convert.ToInt32(backpack_weight) <= 5000)   
            {
                if (task_type_without_space == "без стоимости, каждый предмет имеется в единственном экземпляре" || task_type_without_space == "без стоимости, каждый предмет имеется в неограниченном количестве")
                {
                    visible(sender, e); //отображение элементов формы
                    for (int i = 0; i < arr_number_of_items.Length; i++)
                    {
                        Item.items[i] = new Item(arr_number_of_items[i], Convert.ToInt32(arr_items_weight[i]), 0, 0);
                    }
                    if (task_type_without_space == "без стоимости, каждый предмет имеется в единственном экземпляре")
                    {
                        c2 = true;
                    }
                    else
                    {
                        c3 = true;
                    }
                    //считаем суммарный вес всех предметов и проверяем,
                    //что хотя бы один из предметов имеет меньший вес, чем вес рюкзака
                    for (int i = 0; i < Item.items.Length; i++)
                    {
                        sum += Item.items[i].weight;
                        if (Convert.ToInt32(backpack_weight) >= Item.items[i].weight)
                        {
                            check = true;
                        }
                    }
                    //если суммарный вес всех предметов больше веса рюкзака и что имеется хотя бы один предмет, вес которого меньше 
                    if (check == true && task_type_without_space == "без стоимости, каждый предмет имеется в единственном экземпляре" && sum > Convert.ToInt32(bw) && arr_number_of_items.Length == arr_items_weight.Length)
                    {
                            textBox2.Text = Convert.ToString(simple_algorithm.max_weight(Item.items, Convert.ToInt32(backpack_weight), c2, c3, c4));
                            textBox3.Text += Convert.ToString(simple_algorithm.arr_items[Item.items.Length, Convert.ToInt32(backpack_weight)]);
                       
                        if (checkBox1.Checked)
                            mainForm.recording_the_solution(task_type_without_space, Convert.ToInt32(backpack_weight), arr_number_of_items.Length, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                    }
                    else if (sum <= Convert.ToInt32(bw) && task_type_without_space == "без стоимости, каждый предмет имеется в единственном экземпляре")
                    {
                        not_visible(sender, e); //скрытие элементов формы
                        MessageBox.Show("Суммарный вес всех предметов должен превышать вес рюкзака!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (check == false)
                    {
                        label2.Visible = false;
                        label3.Visible = true;
                        textBox3.Text = "Такого набора нет";
                    }
                    else if (arr_number_of_items.Length != arr_items_weight.Length)
                    {
                        not_visible(sender, e); //скрытие элементов формы
                        MessageBox.Show("Количество предметов не равно количеству других параметров!!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (task_type_without_space == "без стоимости, каждый предмет имеется в неограниченном количестве" && arr_number_of_items.Length == arr_items_weight.Length && check == true)
                    {
                        textBox2.Text = Convert.ToString(simple_algorithm.max_weight(Item.items, Convert.ToInt32(backpack_weight), c2, c3, c4));
                        string items = Convert.ToString(simple_algorithm.arr_items[Item.items.Length, Convert.ToInt32(backpack_weight)]);
                        //преобразование набора предметов
                        string result = " ";
                        int l = 0;

                        for (int i = 1; i < 101; i++)
                        {
                            string item_number = Convert.ToString(i);
                            for (int j = 1; j < items.Length; j++)
                            {
                                if (Convert.ToString(items[j]) == item_number)
                                    l++;
                            }

                            if (l > 0)
                                result += "Предмет №" + i + "(" + l + " шт.) ";

                            l = 0;
                        }
                        textBox3.Text = result;

                        if (checkBox1.Checked)
                            mainForm.recording_the_solution(task_type_without_space, Convert.ToInt32(backpack_weight), arr_number_of_items.Length, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                    }
                    else if (arr_number_of_items.Length != arr_items_weight.Length)
                    {
                        not_visible(sender, e); //скрытие элементов формы
                        MessageBox.Show("Количество предметов не равно количеству других параметров!!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (check == false)
                    {
                        label2.Visible = false;
                        label3.Visible = true;
                        textBox3.Text = "Такого набора нет";
                    } 
                }

                else if (task_type_without_space == "без стоимости, каждый предмет имеется в ограниченном количестве")
                {
                    string[] arr_items_quantity = items_quantity.Split(','); //массив количеств каждого предмета
                    
                    for (int i = 0; i < arr_items_quantity.Length; i++)
                    {
                        if (!uint.TryParse(Convert.ToString(arr_items_quantity[i]), out var outParse2) || Convert.ToInt32(arr_items_quantity[i]) == 0)
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Количества предметов введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            check_validation = false;

                            break;
                        }
                    } 

                    if (arr_items_quantity.Length == arr_items_weight.Length && arr_number_of_items.Length == arr_items_quantity.Length && arr_number_of_items.Length == arr_items_weight.Length && check_validation == true)
                    {
                        richTextBox1.Text += "Количество каждого предмета:" + items_quantity;
                        visible(sender, e); //отображение элементов формы

                        for (int i = 0; i < arr_number_of_items.Length; i++)
                        {
                            Item.items[i] = new Item(arr_number_of_items[i], Convert.ToInt32(arr_items_weight[i]), 0, Convert.ToInt32(arr_items_quantity[i]));
                        }

                        c4 = true;

                        for (int i = 0; i < Item.items.Length; i++)
                        {
                            sum += Item.items[i].weight * Item.items[i].quantity;
                            if (Convert.ToInt32(backpack_weight) >= Item.items[i].weight)
                            {
                                check = true;
                            }
                        }
                        if (sum > Convert.ToInt32(bw) && check == true)
                        {
                            textBox2.Text = Convert.ToString(simple_algorithm.max_weight(Item.items, Convert.ToInt32(backpack_weight), c2, c3, c4));
                            //вывод набора предметов в компонент textBox3
                            textBox3.Text += Convert.ToString(simple_algorithm.arr_items[Item.items.Length, Convert.ToInt32(backpack_weight)]);

                            if (checkBox1.Checked)
                                mainForm.recording_the_solution(task_type_without_space, Convert.ToInt32(backpack_weight), arr_number_of_items.Length, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                        }
                        else if (sum <= Convert.ToInt32(bw))
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("суммарный вес всех предметов должен превышать вес рюкзака!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (check == false)
                        {
                            label2.Visible = false;
                            label3.Visible = true;
                            textBox3.Text = "Такого набора нет";
                        }
                    }
                    else if (arr_number_of_items.Length != arr_items_quantity.Length || arr_number_of_items.Length != arr_items_weight.Length)
                    {
                        not_visible(sender, e); //скрытие элементов формы
                        MessageBox.Show("Количества предметов введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (task_type_without_space == "со стоимостью, каждый предмет имеется в единственном экземпляре" || task_type_without_space == "со стоимостью, каждый предмет имеется в неограниченном количестве")
                {
                    string[] arr_items_cost = items_cost.Split(','); //массив стоимостей

                    for (int i = 0; i < arr_items_cost.Length; i++)
                    {
                        if (!uint.TryParse(Convert.ToString(arr_items_cost[i]), out var outParse2) || Convert.ToInt32(arr_items_cost[i]) == 0)
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Стоимости введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            check_validation = false;
                        }
                    }
                    if (check_validation == true && arr_number_of_items.Length == arr_items_weight.Length && arr_number_of_items.Length == arr_items_cost.Length)
                    {
                        visible(sender, e); //отображение элементов формы
                        richTextBox1.Text += "Стоимость предметов:" + items_cost;
                        for (int i = 0; i < arr_number_of_items.Length; i++)
                        {
                            Item.items[i] = new Item(arr_number_of_items[i], Convert.ToInt32(arr_items_weight[i]), Convert.ToInt32(arr_items_cost[i]), 0);
                        }

                        if (task_type_without_space == "со стоимостью, каждый предмет имеется в единственном экземпляре")
                            c2 = true;
                        else
                            c3 = true;

                        for (int i = 0; i < Item.items.Length; i++)
                        {
                            sum += Item.items[i].weight;
                            if (Convert.ToInt32(backpack_weight) >= Item.items[i].weight)
                                check = true;
                        }

                        if (sum > Convert.ToInt32(bw) && check == true && task_type_without_space == "со стоимостью, каждый предмет имеется в единственном экземпляре")
                        {
                            textBox2.Text = Convert.ToString(algorithm_with_cost.max_cost(Item.items, Convert.ToInt32(backpack_weight), c2, c3, c4));
                            //вывод набора предметов в компонент textBox3
                            textBox3.Text += Convert.ToString(algorithm_with_cost.arr_items[Item.items.Length, Convert.ToInt32(backpack_weight)]);
                        }
                        else if (sum <= Convert.ToInt32(bw) && task_type_without_space == "со стоимостью, каждый предмет имеется в единственном экземпляре")
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("суммарный вес всех предметов должен превышать вес рюкзака!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (check == false)
                        {
                            label2.Visible = false;
                            label3.Visible = true;
                            textBox3.Text = "Такого набора нет";
                        }

                        if (task_type_without_space == "со стоимостью, каждый предмет имеется в неограниченном количестве")
                        {
                            if (arr_number_of_items.Length == arr_items_weight.Length && arr_number_of_items.Length == arr_items_cost.Length && check == true)
                            {
                                textBox2.Text = Convert.ToString(algorithm_with_cost.max_cost(Item.items, Convert.ToInt32(backpack_weight), c2, c3, c4));
                                string items = Convert.ToString(algorithm_with_cost.arr_items[Item.items.Length, Convert.ToInt32(backpack_weight)]);

                                //преобразование набора предметов
                                string result = " ";//для хранения набора предметов
                                int l = 0; //счетчик кол-ва предметов

                                for (int i = 1; i < 101; i++)
                                {
                                    string item_number = Convert.ToString(i);
                                    for (int j = 1; j < items.Length; j++)
                                    {
                                        if (Convert.ToString(items[j]) == item_number)
                                            l++;
                                    }

                                    if (l > 0)
                                        result += "Предмет №" + i + "(" + l + " шт.) ";

                                    l = 0;
                                }
                                textBox3.Text = items;
                                if (checkBox1.Checked)
                                    mainForm.recording_the_solution(task_type_without_space, Convert.ToInt32(backpack_weight), arr_number_of_items.Length, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                            }
                        }
                    } 
                    else if (arr_number_of_items.Length != arr_items_weight.Length || arr_number_of_items.Length != arr_items_weight.Length || arr_items_cost.Length != arr_number_of_items.Length)
                    {
                        not_visible(sender, e); //скрытие элементов формы
                        MessageBox.Show("Количество предметов не соответствует количеству других параметров!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }
                else if (task_type_without_space == "со стоимостью, каждый предмет имеется в ограниченном количестве")
                {
                    string[] arr_items_cost = items_cost.Split(',');
                    string[] arr_items_quantity = items_quantity.Split(',');

                    for(int i =0; i<arr_items_cost.Length; i++)
                    {
                        if (!uint.TryParse(Convert.ToString(arr_items_cost[i]), out var outParse2) || Convert.ToInt32(arr_items_cost[i]) == 0 )
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Стоимости введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            check_validation = false;
                        }
                    }
                    for (int i = 0; i < arr_items_quantity.Length; i++)
                    {
                        if (!uint.TryParse(Convert.ToString(arr_items_quantity[i]), out var outParse2) || Convert.ToInt32(arr_items_quantity[i]) == 0)
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("Количества предметов введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            check_validation = false;
                        }  
                    }

                    if (arr_items_quantity.Length == arr_items_weight.Length && arr_number_of_items.Length == arr_items_quantity.Length && arr_items_quantity.Length == arr_items_cost.Length && arr_items_cost.Length == arr_number_of_items.Length && arr_items_cost.Length == arr_items_weight.Length && check_validation == true && arr_number_of_items.Length == arr_items_weight.Length)
                    {
                        visible(sender, e); //отображение элементов формы
                        richTextBox1.Text += "Стоимость предметов:" + items_cost;
                        richTextBox1.Text += "Количество каждого предмета:" + items_quantity;
                        for (int i = 0; i < arr_number_of_items.Length; i++)
                        {
                            Item.items[i] = new Item(arr_number_of_items[i], Convert.ToInt32(arr_items_weight[i]), Convert.ToInt32(arr_items_cost[i]), Convert.ToInt32(arr_items_quantity[i]));
                        }

                        c4 = true;

                        for (int i = 0; i < Item.items.Length; i++)
                        {
                            sum += Item.items[i].weight * Item.items[i].quantity;
                            if (Convert.ToInt32(backpack_weight) >= Item.items[i].weight)
                                check = true;
                        }
                        if (sum > Convert.ToInt32(bw) && check == true)
                        {
                            textBox2.Text = Convert.ToString(algorithm_with_cost.max_cost(Item.items, Convert.ToInt32(backpack_weight), c2, c3, c4));
                            //вывод набора предметов в компонент textBox3
                            textBox3.Text += Convert.ToString(algorithm_with_cost.arr_items[Item.items.Length, Convert.ToInt32(backpack_weight)]);

                            if (checkBox1.Checked)
                                mainForm.recording_the_solution(task_type_without_space, Convert.ToInt32(backpack_weight), arr_number_of_items.Length, Convert.ToInt32(textBox2.Text), Convert.ToString(textBox3.Text));
                        }
                        else if (sum <= Convert.ToInt32(bw))
                        {
                            not_visible(sender, e); //скрытие элементов формы
                            MessageBox.Show("суммарный вес всех предметов должен превышать вес рюкзака!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (check == false)
                        {
                            label2.Visible = false;
                            label3.Visible = true;
                            textBox3.Text = "Такого набора нет";
                        }
                    }
                    else if (arr_items_quantity.Length != arr_items_weight.Length || arr_number_of_items.Length != arr_items_quantity.Length || arr_items_quantity.Length != arr_items_cost.Length || arr_items_cost.Length != arr_number_of_items.Length || arr_items_cost.Length != arr_items_weight.Length)
                    {
                        not_visible(sender, e); //скрытие элементов формы
                        MessageBox.Show("Количество предметов не соответствует количеству других параметров", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (fileText != "")
                {
                    not_visible(sender, e); //скрытие элементов формы
                    MessageBox.Show("В файле отсутствует тип задачи или тип задачи введен некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //проверка того, что вес введен корректно
            else if ((!uint.TryParse(backpack_weight, out var outParse) || Convert.ToInt32(backpack_weight) == 0) || Convert.ToInt32(backpack_weight) > 0 && fileText != string.Empty )
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Вес введен некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //проверка того, что предметы введены корректно
            else if (noi == "" && fileText != string.Empty)
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Предметы введены некорректно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //проверка того, что количество предметов соответствует кол-ву других параметров
            else if (arr_number_of_items.Length != arr_items_weight.Length )
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Количество предметов не соответствует количеству других параметров", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //если файл пустой
            if (fileText == string.Empty)
            {
                not_visible(sender, e); //скрытие элементов формы
                MessageBox.Show("Файл пуст!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //нажатие на кнопку "Печать результатов"
        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        //нажатие на кнопку "Сохранить результаты в файл"
        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            string filenameText = "Дата: " + DateTime.Now + Environment.NewLine + Environment.NewLine +"Исходные данные: "+ Environment.NewLine + Convert.ToString(richTextBox1.Text)+ "Результаты:" + Environment.NewLine + "Ответ: " + textBox2.Text + Environment.NewLine + "Набор предметов: " + textBox3.Text;
            System.IO.File.WriteAllText(filename, filenameText);
            MessageBox.Show("Файл сохранен");
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            string date = "Дата: " + DateTime.Now;

            
            string Answer = "Ответ: " + textBox2.Text;
            string Items = "Набор предметов: " + textBox3.Text;
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            e.Graphics.DrawString(date, myFont, Brushes.Black, 40, 40);
            e.Graphics.DrawString("Исходные данные:", myFont, Brushes.Black, 40, 70);
            e.Graphics.DrawString(richTextBox1.Text, myFont, Brushes.Black, 40, 100);
            e.Graphics.DrawString("Результаты:", myFont, Brushes.Black, 40, 380);
            e.Graphics.DrawString(Answer, myFont, Brushes.Black, 40, 410);
            e.Graphics.DrawString(Items, myFont, Brushes.Black, new RectangleF(40, 440, 770, 800));
        }
        private void главнаяСтраницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_form mainForm = new main_form();
            mainForm.Show();
        }
        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_db newForm = new show_db();
            newForm.Show();
        }
        private void task_from_a_file_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button4;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void not_visible(object sender, EventArgs e) //скрытие элементов формы
        {
            richTextBox1.Text = "";
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button6.Visible = false;
        }
        private void visible(object sender, EventArgs e) //отображение элементов формы
        {
            label2.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            button6.Visible = true;
        }
    }
}
