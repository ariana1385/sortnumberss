using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
        {
            arr[i] = i + 1;
        }

        ISortable sortable = new SelectionSort(ascending: true);    //or bubblesort , InsertionSort , MergeSort
        sortable.Sort(arr);

        Console.WriteLine("Array after sorting (Ascending):");
        Console.WriteLine(string.Join(", ", arr));

        Console.WriteLine("Sorting in descending order:");
        sortable = new SelectionSort(ascending: false);             //or bubblesort , InsertionSort , MergeSort
        sortable.Sort(arr);
        Console.WriteLine(string.Join(", ", arr));
    }
}
