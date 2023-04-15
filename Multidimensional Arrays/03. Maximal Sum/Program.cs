




int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int rows = sizes[0];
int cols = sizes[1];

int[,] matrix = new int[rows, cols];


for (int row = 0; row < rows; row++)
{
    int[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = data[col];
    }
}

int maxSum = int.MinValue;
int curentSum = 0;

int maxSumRow = 0;
int maxSumCol = 0;

int[,] matrix2 = new int[3, 3];

for (int row = 0; row < rows - 2; row++)
{
    for (int col = 0; col < cols - 2; col++)
    {
        curentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];


        if (curentSum > maxSum)
        {
            maxSum = curentSum;
            maxSumRow = row;
            maxSumCol = col;
        }
    }

}

Console.WriteLine($"Sum = {maxSum}");

for (int row = maxSumRow; row < maxSumRow + 3; row++)
{
    for (int col = maxSumCol; col < maxSumCol + 3; col++)
    {
        Console.Write($"{matrix[row, col]} ");
    }
    Console.WriteLine();
}