using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISortable
{
    void Sort(int[] arr);
}

public class BubbleSort : ISortable
{
    private bool ascending;

    public BubbleSort(bool ascending = true)
    {
        this.ascending = ascending;
    }

    public void Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if ((ascending && arr[j] > arr[j + 1]) || (!ascending && arr[j] < arr[j + 1]))
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

public class MergeSort : ISortable
{
    private bool ascending;

    public MergeSort(bool ascending = true)
    {
        this.ascending = ascending;
    }

    public void Sort(int[] arr)
    {
        MergeSortAlgorithm(arr, 0, arr.Length - 1);
    }

    private void MergeSortAlgorithm(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSortAlgorithm(arr, left, mid);
            MergeSortAlgorithm(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    private void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(arr, left, leftArray, 0, n1);
        Array.Copy(arr, mid + 1, rightArray, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if ((ascending && leftArray[i] <= rightArray[j]) || (!ascending && leftArray[i] >= rightArray[j]))
            {
                arr[k] = leftArray[i];
                i++;
            }
            else
            {
                arr[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = rightArray[j];
            j++;
            k++;
        }
    }
}

public class SelectionSort : ISortable
{
    private bool ascending;

    public SelectionSort(bool ascending = true)
    {
        this.ascending = ascending;
    }

    public void Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int indexToSwap = i;

            for (int j = i + 1; j < n; j++)
            {
                if ((ascending && arr[j] < arr[indexToSwap]) || (!ascending && arr[j] > arr[indexToSwap]))
                {
                    indexToSwap = j;
                }
            }

            if (indexToSwap != i)
            {
                int temp = arr[i];
                arr[i] = arr[indexToSwap];
                arr[indexToSwap] = temp;
            }
        }
    }
}

public class InsertionSort : ISortable
{
    private bool ascending;

    public InsertionSort(bool ascending = true)
    {
        this.ascending = ascending;
    }

    public void Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && ((ascending && arr[j] > key) || (!ascending && arr[j] < key)))
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }

            arr[j + 1] = key;
        }
    }
}
