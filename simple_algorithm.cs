using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problems
{
    internal class simple_algorithm
    {
        public static int[,] arr = new int[,] {};
        public static string[,] arr_items = new string[,] { };

        public static int max_weight(Item [] items, int maxCapacity, bool c2, bool c3, bool c4)
        { 
            arr = new int[Item.items.Length + 1, maxCapacity + 1]; //массив для хранения максимальной стоимости
            arr_items = new string[Item.items.Length + 1, maxCapacity + 1]; //массив для хранения набора предметов

            for (int i = 0; i <= Item.items.Length; i++) //для каждого предмета
            {
                for (int j = 0; j <= maxCapacity; j++) //от 0 кг до веса рюкзака
                {
                    if (i == 0 || j == 0) //заполнение ячеек "пустышек"
                    {
                        arr[i, j] = 0;
                        arr_items[i, j] = "";
                    }
                    else
                    {
                        if (Item.items[i - 1].weight > j) //если вес текущей вещи больше размера рюкзака
                        {
                            arr[i, j] = arr[i - 1, j];
                            arr_items[i, j] = arr_items[i - 1, j];
                        }
                        else
                        {
                            var prev = arr[i - 1, j]; //значение над ячейкой
                            //если каждый предмет имеется в единственном экземпляре
                            if (c2)
                            {
                                var Formula = Item.items[i - 1].weight + arr[i - 1, j - Item.items[i - 1].weight];
                                arr[i, j] = Math.Max(prev, Formula);
                                if (prev > Formula)
                                {
                                    arr_items[i, j] = arr_items[i - 1, j];
                                }
                                else
                                {
                                    arr_items[i, j] = arr_items[i - 1, j - Item.items[i - 1].weight] + " " + Item.items[i - 1].name;
                                }
                            }
                            if (c3) //если каждый предмет имеется в неограниченном количестве
                            {
                                var Formula = Item.items[i - 1].weight + arr[i, j - Item.items[i - 1].weight];
                                arr[i, j] = Math.Max(prev, Formula);
                                if (prev > Formula)
                                {
                                    arr_items[i, j] = arr_items[i - 1, j];
                                }
                                else
                                {
                                    arr_items[i, j] = arr_items[i, j - Item.items[i - 1].weight] + " " + Item.items[i - 1].name;
                                }
                            }
                            if (c4) //если каждый предмет имеется в ограниченном количестве
                            {
                                for (var k = 1; k <= Item.items[i - 1].quantity; k++)
                                {
                                    if (Item.items[i - 1].weight * k <= j)
                                    {
                                        //стоимость текущей вещи + стоимость свободного места
                                        var Formula = Item.items[i - 1].weight * k + arr[i - 1, j - Item.items[i - 1].weight * k];
                                        arr[i, j] = Math.Max(prev, Formula);
                                        if (prev > Formula)
                                        {
                                            arr_items[i, j] = arr_items[i - 1, j];
                                        }
                                        else
                                        {
                                            arr_items[i, j] = arr_items[i - 1, j - Item.items[i - 1].weight * k] + " " + Item.items[i - 1].name + "(" + k + " шт.)";
                                        }

                                    }
                                }
                            }  
                        }
                    }
                }
            }
            return arr[Item.items.Length, maxCapacity];// возвращаем правую нижнюю ячейку
        }  
    }
}
