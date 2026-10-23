//Вариант 26,высокий

class Program
{
    static void Main()
    {
        int N = 5, M = 6;
        int[,] mas = new int[N, M];

        Random rnd = new Random();

        
        Console.WriteLine("Исходная матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                mas[i, j] = rnd.Next(2);
                Console.Write($"{mas[i, j]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        
        int[] priority = new int[M];
        for (int j = 0; j < M; j++)
        {
            priority[j] = N; 
            for (int i = 0; i < N; i++)
            {
                if (mas[i, j] == 1)
                {
                    priority[j] = i;
                    break;
                }
            }
        }

        
        for (int i = 0; i < M - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < M; j++)
            {
                if (priority[j] < priority[minIdx])
                    minIdx = j;
            }

            if (minIdx != i)
            {
       
                for (int row = 0; row < N; row++)
                {
                    int temp = mas[row, i];
                    mas[row, i] = mas[row, minIdx];
                    mas[row, minIdx] = temp;
                }
                int tmpP = priority[i];
                priority[i] = priority[minIdx];
                priority[minIdx] = tmpP;
            }
        }

        Console.WriteLine("Преобразованная матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write($"{mas[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}