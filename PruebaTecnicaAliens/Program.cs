internal class Program
{
    private static void Main(string[] args)
    {
        int[] initialState = { 1, 1, 1, 1, 2, 1, 1, 4, 1, 4, 3, 1, 1, 1, 1, 1, 1, 1, 1, 4, 1, 3, 1, 1, 1, 5, 1, 3, 1, 4, 1, 2, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 4, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 4, 1, 1, 1, 1, 3, 5, 1, 1, 2, 1, 1, 1, 1, 4, 4, 1, 1, 1, 4, 1, 1, 4, 2, 4, 4, 5, 1, 1, 1, 1, 2, 3, 1, 1, 4, 1, 5, 1, 1, 1, 3, 1, 1, 1, 1, 5, 5, 1, 2, 2, 2, 2, 1, 1, 2, 1, 1, 1, 1, 1, 3, 1, 1, 1, 2, 3, 1, 5, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 3, 2, 1, 1, 1, 4, 3, 1, 1, 4, 1, 5, 4, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 4, 5, 1, 1, 1, 1, 5, 4, 1, 3, 1, 1, 1, 1, 4, 3, 3, 3, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 5, 1, 3, 1, 4, 3, 1, 3, 1, 5, 1, 1, 1, 1, 3, 1, 5, 1, 2, 4, 1, 1, 4, 1, 4, 4, 2, 1, 2, 1, 3, 3, 1, 4, 4, 1, 1, 3, 4, 1, 1, 1, 2, 5, 2, 5, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 3, 1, 5, 1, 2, 1, 1, 1, 1, 1, 4, 4, 1, 1, 1, 5, 1, 1, 5, 1, 2, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 4, 1, 1, 2, 1, 1, 3, 2 };

        int days = 256;

        long totalAliens = CountAliensAfterDays(initialState, days);

        Console.WriteLine($"Después de {days} días, hay un total de {totalAliens} aliens.");
    }

    static long CountAliensAfterDays(int[] initialState, int days)
    {
        long[] counts = new long[9];

        foreach (int timer in initialState)
        {
            counts[timer]++;
        }

        // Simulación de la reproducción día a día
        for (int day = 0; day < days; day++)
        {
            long newBorns = counts[0];

            for (int i = 0; i < 8; i++)
            {
                counts[i] = counts[i + 1];
            }

            counts[6] += newBorns;

            counts[8] = newBorns;
        }

        return counts.Sum();
    }
}