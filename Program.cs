using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_22_СамРабота_ПараллПрограмм_и_библиотека_TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(1, 100);
            }

            Task<int> sumTask = Task.Run(() => SumArray(array));
            Task<int> maxTask = Task.Run(() => FindMax(array));

            sumTask.ContinueWith(antecedent => Console.WriteLine("Сумма массива равна:" + antecedent.Result));
            maxTask.ContinueWith(antecedent => Console.WriteLine("Максимальное значение в массиве равно: " + antecedent.Result));

            Console.ReadLine();
        }

        static int SumArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static int FindMax(int[] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}