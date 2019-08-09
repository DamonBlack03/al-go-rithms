public class SelectionSort
{

    public static void Main(string[] args)
    {
        int[] items = new int[] { 52, 62, 143, 73, 22, 26, 27, 14, 62, 84, 15 };
        Sort(items);

        System.Console.WriteLine("Sorted: ");

        for (int i = 0; i < items.Length; i++)
            System.Console.Write(items[i] + " ");
    }

    public static void Sort(int[] arr)
    {
        int index = 0;
        while (index < arr.Length)
        {
            int num2 = index;
            while (num2 < arr.Length)
            {
                if (arr[num2].CompareTo(arr[index]) < 0)
                {
                    (arr[num2], arr[index]) = (arr[index], arr[num2]);
                }
                if (num2 == arr.Length - 1)
                {
                    index++;
                    break;
                }
                num2++;
            }
        }
    }
}