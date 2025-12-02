using System.ComponentModel.Design;
using System.Security.Cryptography;
using Maxim_Drive.DriverModel;
using Maxim_Drive.OrderModel;

namespace Maxim_Drive.SortModel
{
    public static class SortAlgorithms
    {
        public static void BubbleSort(Driver[] dris, Order order)
        {
            for (int i = 1; i < dris.Length; i++)
            {
                for (int j = 0; j < dris.Length - i; j++)
                {
                    if (dris[j].GetDistanceTo(order) >= dris[j + 1].GetDistanceTo(order))
                    {
                        (dris[j], dris[j + 1]) = (dris[j + 1], dris[j]);
                    }
                }
            }
            Console.WriteLine("Top 5 drivers Bubble:");
            for (int i = 0; (i < dris.Length) && (i < 5); i++)
            {
                Console.WriteLine($"N{i+1} - {dris[i].Id}-id: ({dris[i].X}; {dris[i].Y})");
            }
        }

        public static void QuickSort(Driver[] dris, Order order)
        {
            QuickSortAlg(dris, 0, dris.Length - 1, order);
            Console.WriteLine("Top 5 drivers Quick:");
            for (int i = 0; (i < dris.Length) && (i < 5); i++)
            {
                Console.WriteLine($"N{i+1} - {dris[i].Id}-id: ({dris[i].X}; {dris[i].Y})");
            }
        }

        public static void QuickSortAlg(Driver[] dris, int left, int right, Order order)
        {
            if (left < right)
            {
                int pivot = Partition(dris, left, right, order);
                if (pivot > 1)
                {
                    QuickSortAlg(dris, left, pivot - 1, order);
                }
                if (pivot + 1 < right)
                {
                    QuickSortAlg(dris, pivot + 1, right, order);
                }
            }
        }

        public static int Partition(Driver[] dris, int left, int right, Order order)
        {
            double pivot = dris[right].GetDistanceTo(order);
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (dris[j].GetDistanceTo(order) <= pivot)
                {
                    i++;
                    Driver temp1 = dris[i];
                    dris[i] = dris[j];
                    dris[j] = temp1;
                }
            }

            Driver temp = dris[i + 1];
            dris[i + 1] = dris[right];
            dris[right] = temp;
            return i + 1;
        }

        public static void InsertionSort(Driver[] dris, Order order)
        {
            for (int i = 1; i < dris.Length; i++)
            {
                Driver currentDriver = dris[i];
                double currentDistance = currentDriver.GetDistanceTo(order);
                int j = i - 1;

                // Сдвигаем элементы, которые больше текущего, вправо
                while (j >= 0 && dris[j].GetDistanceTo(order) > currentDistance)
                {
                    dris[j + 1] = dris[j];
                    j--;
                }

                // Вставляем текущиid элемент на правильное место
                dris[j + 1] = currentDriver;
            }

            Console.WriteLine("Top 5 drivers Insertion:");
            for (int i = 0; (i < dris.Length) && (i < 5); i++)
            {
                Console.WriteLine($"N{i+1} - {dris[i].Id}-id: ({dris[i].X}; {dris[i].Y})");
            }
        }
    }
}