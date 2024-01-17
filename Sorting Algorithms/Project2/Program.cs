using System.Collections.Generic;

class Data
{
    private string cusID;
    private string month;
    private int age;
    private string occupation;
    private double annualIncome;
    private int bankAccounts;
    private int creditAccounts;

    public string CusID { get; set; }
    public string Month { get; set; }
    public int Age { get; set; }
    public string Occupation { get; set; }
    public double AnnualIncome { get; set; }
    public int BankAccounts { get; set; }
    public int CreditAccounts { get; set; }
}

class QuickSortClass
{
    public void QuickSort(List<Data> dataList, int low, int high, ref int swaps)
    {
        if (low < high)
        {
            int partitionIndex = Partition(dataList, low, high, ref swaps);

            QuickSort(dataList, low, partitionIndex - 1, ref swaps);
            QuickSort(dataList, partitionIndex + 1, high, ref swaps);
        }
    }

    public int Partition(List<Data> dataList, int low, int high, ref int swaps)
    {
        double pivot = dataList[high].AnnualIncome;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (dataList[j].AnnualIncome < pivot)
            {
                i++;
                Swap(dataList, i, j, ref swaps);
            }
        }

        Swap(dataList, i + 1, high, ref swaps);
        return i + 1;
    }

    public void Swap(List<Data> dataList, int i, int j, ref int swaps)
    {
        Data temp = dataList[i];
        dataList[i] = dataList[j];
        dataList[j] = temp;
        swaps++;
    }
}

class InsertionSortClass
{
    public int InsertionSort(List<Data> dataList)
    {
        int swaps = 0;

        for (int i = 1; i < dataList.Count; i++)
        {
            Data key = dataList[i];
            int j = i - 1;

            while (j >= 0 && dataList[j].AnnualIncome > key.AnnualIncome)
            {
                dataList[j + 1] = dataList[j];
                j = j - 1;
                swaps++;
            }

            dataList[j + 1] = key;
        }

        return swaps;
    }
}

class MergeSortClass
{
    public int MergeSort(List<Data> dataList)
    {
        int comparisons = 0;
        MergeSort(dataList, 0, dataList.Count - 1, ref comparisons);
        return comparisons;
    }

    public void MergeSort(List<Data> dataList, int low, int high, ref int comparisons)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;

            MergeSort(dataList, low, mid, ref comparisons);
            MergeSort(dataList, mid + 1, high, ref comparisons);

            Merge(dataList, low, mid, high, ref comparisons);
        }
    }

    public void Merge(List<Data> dataList, int low, int mid, int high, ref int comparisons)
    {
        int n1 = mid - low + 1;
        int n2 = high - mid;

        List<Data> leftArray = new List<Data>();
        List<Data> rightArray = new List<Data>();

        for (int i = 0; i < n1; i++)
            leftArray.Add(dataList[low + i]);

        for (int j = 0; j < n2; j++)
            rightArray.Add(dataList[mid + 1 + j]);

        int iLeft = 0, iRight = 0, k = low;

        while (iLeft < n1 && iRight < n2)
        {
            comparisons++;
            if (leftArray[iLeft].AnnualIncome <= rightArray[iRight].AnnualIncome)
            {
                dataList[k] = leftArray[iLeft];
                iLeft++;
            }
            else
            {
                dataList[k] = rightArray[iRight];
                iRight++;
            }
            k++;
        }

        while (iLeft < n1)
        {
            dataList[k] = leftArray[iLeft];
            iLeft++;
            k++;
        }

        while (iRight < n2)
        {
            dataList[k] = rightArray[iRight];
            iRight++;
            k++;
        }
    }
}

class SelectionSortClass
{
    public int SelectionSort(List<Data> dataList)
    {
        int comparisons = 0;
        int n = dataList.Count;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                comparisons++;
                if (dataList[j].AnnualIncome < dataList[minIndex].AnnualIncome)
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                Swap(dataList, i, minIndex);
            }
        }

        return comparisons;
    }

    public void Swap(List<Data> dataList, int i, int j)
    {
        Data temp = dataList[i];
        dataList[i] = dataList[j];
        dataList[j] = temp;
    }
}

class Program
{
    static void Main()
    {

        Console.WriteLine($"\nReading and Sorting data...............");

        List<Data> dataListQuickSort = ReadCSV("data1.csv");
        List<Data> dataListInsertionSort = ReadCSV("data2.csv");
        List<Data> dataListMergeSort = ReadCSV("data3.csv");
        List<Data> dataListSelectionSort = ReadCSV("data4.csv");

        QuickSortClass qs = new QuickSortClass();
        InsertionSortClass ins = new InsertionSortClass();
        MergeSortClass ms = new MergeSortClass();
        SelectionSortClass ss = new SelectionSortClass();

        int Quickcomparisons = 0;
        qs.QuickSort(dataListQuickSort, 0, dataListQuickSort.Count - 1, ref Quickcomparisons);

        Console.WriteLine($"\nTotal swaps using quick sort: {Quickcomparisons}");

        int Insertioncomparisons = 0;
        Insertioncomparisons = ins.InsertionSort(dataListInsertionSort);

        Console.WriteLine($"\nTotal swaps using insertion sort: {Insertioncomparisons}");

        int Mergecomparisons = ms.MergeSort(dataListMergeSort);

        Console.WriteLine($"\nTotal Comparisons using merge sort: {Mergecomparisons}");

        int Selectioncomparisons = ss.SelectionSort(dataListSelectionSort);

        Console.WriteLine($"\nTotal Comparisons using selection sort: {Selectioncomparisons}");
    }

    static List<Data> ReadCSV(string filePath)
    {
        List<Data> dataList = new List<Data>();

        
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] fields = line.Split(',');

                    Data data = new Data
                    {
                        CusID = fields[0],
                        Month = fields[1],
                        Age = int.Parse(fields[2]),
                        Occupation = fields[3],
                        AnnualIncome = double.Parse(fields[4]),
                        BankAccounts = int.Parse(fields[5]),
                        CreditAccounts = int.Parse(fields[6])
                    };
                    dataList.Add(data);
                }
            }

        return dataList;
    }
}