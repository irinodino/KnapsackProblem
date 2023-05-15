using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack_problems
{
    internal class algorithm_with_cost
    {
        public static int[,] arr = new int[,] { };
        public static string[,] arr_items = new string[,] { };

        public static int max_cost(Item[] items, int maxCapacity, bool c2, bool c3, bool c4)
        {
            //массив для хранения максимальной стоимости 
            arr = new int[Item.items.Length + 1, maxCapacity + 1];
            //массив для хранения набора предметов
            arr_items = new string[Item.items.Length + 1, maxCapacity + 1];

            //для каждого предмета
            for (int i = 0; i <= Item.items.Length; i++)
            {
                //от 0 кг до веса рюкзака
                for (int j = 0; j <= maxCapacity; j++)
                {
                    //заполнение ячеек "пустышек"
                    if (i == 0 || j == 0)
                    {
                        arr[i, j] = 0;
                        arr_items[i, j] = "";
                    }
                    else
                    {
                        //если вес текущей вещи больше размера рюкзака
                        if (Item.items[i - 1].weight > j)
                        {
                            arr[i, j] = arr[i - 1, j];
                            arr_items[i, j] = arr_items[i - 1, j];
                        }
                        else
                        {
                            //значение над ячейкой
                            var prev = arr[i - 1, j];
                            //если каждый предмет имеется в единственном экземпляре
                            if (c2)
                            {
                                var byFormula = Item.items[i - 1].price + arr[i - 1, j - Item.items[i - 1].weight];
                                arr[i, j] = Math.Max(prev, byFormula);
                                if (prev > byFormula)
                                {
                                    arr_items[i, j] = arr_items[i - 1, j];
                                }
                                else
                                {
                                    arr_items[i, j] = arr_items[i - 1, j - Item.items[i - 1].weight] + " " + Item.items[i - 1].name;
                                }
                            }
                            //если каждый предмет имеется в неограниченном количестве
                            if (c3)
                            {
                                var byFormula = Item.items[i - 1].price + arr[i, j - Item.items[i - 1].weight];
                                arr[i, j] = Math.Max(prev, byFormula);
                                if (prev > byFormula)
                                {
                                    arr_items[i, j] = arr_items[i - 1, j];
                                }
                                else
                                {
                                    arr_items[i, j] = arr_items[i, j - Item.items[i - 1].weight] + " " + Item.items[i - 1].name;
                                }
                            }
                            //если каждый предмет имеется в ограниченном количестве
                            else if (c4)
                            {
                                for (var k = 1; k <= Item.items[i - 1].quantity; k++)
                                {
                                    if (Item.items[i - 1].weight * k <= j)
                                    {
                                        //стоимость текущей вещи + стоимость свободного места
                                        var byFormula = Item.items[i - 1].price * k + arr[i - 1, j - Item.items[i - 1].weight * k];
                                        arr[i, j] = Math.Max(prev, byFormula);
                                        if (prev > byFormula)
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
            // возвращаем правую нижнюю ячейку
            return arr[Item.items.Length, maxCapacity];
        }
    }
}
