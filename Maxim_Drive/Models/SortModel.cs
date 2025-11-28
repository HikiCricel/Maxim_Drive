using System.ComponentModel.Design;
using System.Security.Cryptography;
using Maxim_Drive.DriverModel;
using Maxim_Drive.OrderModel;

namespace Maxim_Drive.SortModel
{
    public static class SortAlgotithms
    {
        public static void BubbleSort(Driver[] drivers, Order order)
        {
            Driver[] copyDrivers = (Driver[])drivers.Clone();
            for (int i = 1; i < copyDrivers.Length; i++)
            {
                for (int j = 0; j < copyDrivers.Length - i; j++)
                {
                    if (copyDrivers[j].GetDistanceTo(order) >= copyDrivers[j + 1].GetDistanceTo(order))
                    {
                        (copyDrivers[j], copyDrivers[j + 1]) = (copyDrivers[j + 1], copyDrivers[j]);
                    }
                }
            }
            Console.WriteLine(@$"Ближайшие водители пузырьком: 
{copyDrivers[0].Id}-й: ({copyDrivers[0].X}; {copyDrivers[0].Y})
{copyDrivers[1].Id}-й: ({copyDrivers[1].X}; {copyDrivers[1].Y})
{copyDrivers[2].Id}-й: ({copyDrivers[2].X}; {copyDrivers[2].Y})
{copyDrivers[3].Id}-й: ({copyDrivers[3].X}; {copyDrivers[3].Y})
{copyDrivers[4].Id}-й: ({copyDrivers[4].X}; {copyDrivers[4].Y})");
        }

        public static void QuickSort(Driver[] dris, Order order)
        {
            QuickSortAlg(dris, 0, dris.Length - 1, order);
            Console.WriteLine(@$"Ближайшие водители быстрой: 
{dris[0].Id}-й: ({dris[0].X}; {dris[0].Y})
{dris[1].Id}-й: ({dris[1].X}; {dris[1].Y})
{dris[2].Id}-й: ({dris[2].X}; {dris[2].Y})
{dris[3].Id}-й: ({dris[3].X}; {dris[3].Y})
{dris[4].Id}-й: ({dris[4].X}; {dris[4].Y})");
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

        public static void InsertionSort(Driver[] drivers, Order order)
        {
            Driver[] copyDrivers = (Driver[])drivers.Clone();
            for (int i = 1; i < drivers.Length; i++)
            {
                Driver currentDriver = copyDrivers[i];
                double currentDistance = currentDriver.GetDistanceTo(order);
                int j = i - 1;

                // Сдвигаем элементы, которые больше текущего, вправо
                while (j >= 0 && copyDrivers[j].GetDistanceTo(order) > currentDistance)
                {
                    copyDrivers[j + 1] = copyDrivers[j];
                    j--;
                }

                // Вставляем текущий элемент на правильное место
                copyDrivers[j + 1] = currentDriver;
            }

            Console.WriteLine(@$"Ближайшие водители вставкой: 
{copyDrivers[0].Id}-й: ({copyDrivers[0].X}; {copyDrivers[0].Y})
{copyDrivers[1].Id}-й: ({copyDrivers[1].X}; {copyDrivers[1].Y})
{copyDrivers[2].Id}-й: ({copyDrivers[2].X}; {copyDrivers[2].Y})
{copyDrivers[3].Id}-й: ({copyDrivers[3].X}; {copyDrivers[3].Y})
{copyDrivers[4].Id}-й: ({copyDrivers[4].X}; {copyDrivers[4].Y})");
        }
    }
}