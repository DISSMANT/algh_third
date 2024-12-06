class OptimalResourceAllocation
{
    static void Main()
    {
        int totalMachines = 9;

        // Таблицы производительности для каждого вида работ
        int[] f1 = { 0, 5, 9, 12, 14, 15, 18, 20, 24, 27 }; // Виды работ 1
        int[] f2 = { 0, 7, 9, 11, 13, 16, 19, 21, 22, 25 }; // Виды работ 2
        int[] f3 = { 0, 6, 10, 13, 15, 16, 18, 21, 22, 25 }; // Виды работ 3

        int maxProduction = 0;
        int optimalX = 0, optimalY = 0, optimalZ = 0;

        // Перебор всех возможных распределений машин между тремя видами работ
        for (int x = 0; x <= totalMachines; x++)
        {
            for (int y = 0; y <= totalMachines - x; y++)
            {
                int z = totalMachines - x - y;
                // Убедимся, что z не выходит за пределы массива
                if (z < 0 || z >= f3.Length)
                    continue;

                int currentProduction = 0;

                // Проверка, что количество машин для каждого вида работ не превышает 9
                if (x < f1.Length && y < f2.Length && z < f3.Length)
                {
                    currentProduction = f1[x] + f2[y] + f3[z];
                }
                else
                {
                    continue;
                }

                if (currentProduction > maxProduction)
                {
                    maxProduction = currentProduction;
                    optimalX = x;
                    optimalY = y;
                    optimalZ = z;
                }
            }
        }

        Console.WriteLine("Оптимальное распределение машин:");
        Console.WriteLine($"Вид работ 1: {optimalX} машин(ы) => Производительность: {f1[optimalX]}");
        Console.WriteLine($"Вид работ 2: {optimalY} машин(ы) => Производительность: {f2[optimalY]}");
        Console.WriteLine($"Вид работ 3: {optimalZ} машин(ы) => Производительность: {f3[optimalZ]}");
        Console.WriteLine($"Максимальная общая производительность: {maxProduction}");
    }
}
