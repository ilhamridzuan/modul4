using System;
using System.Net.NetworkInformation;

public class KodeProduk
{
    private static string[,] kodeProduk =
    {
        {"Laptop", "E100"},
        {"Smartphone", "E101" },
        {"Tablet", "E102" },
        {"Headset", "E103" },
        {"Keyboard", "E104" },
        {"Mouse", "105" },
        {"Printer", "106" },
        {"Monitor", "E107" },
        {"Smartwatch", "E108" },
        {"Kamera", "E109" }
    };

    public static string GetKodeProduk(string produk)
    {
        for (int i = 0; i < kodeProduk.GetLength(0); i++)
        {
            if (kodeProduk[i, 0].Equals(produk, StringComparison.OrdinalIgnoreCase))
            {
                return kodeProduk[i, 1];
            }
        }
        return "Kode Produk Tidak ditemukan,";
    }

    public class FanLaptop
    {
        public enum State { Quiet, Balanced, Performance, Turbo}
        private State currentState;

        public FanLaptop()
        {
            currentState = State.Quiet;
            Console.WriteLine("Quite Mode");

        }

        public void ModeUp()
        {
            if (currentState == State.Quiet)
            {
                currentState = State.Balanced;
                Console.WriteLine("Fan Queit berubah menjadi balanced");
            }
            else if (currentState == State.Balanced)
            {
                currentState = State.Performance;
                Console.WriteLine("Fan Balanced berubah menjadi performance");
            }
            else if (currentState == State.Performance)
            {
                currentState = State.Turbo;
                Console.WriteLine("Fan Performance berubah menjadi Turbo");
            }
        }

        public void ModeDown()
        {
            if (currentState == State.Turbo)
            {
                currentState = State.Performance;
                Console.WriteLine("Fan Turbo berubah menjadi Performance");
            } 
            else if (currentState == State.Performance)
            {
                currentState = State.Balanced;
                Console.WriteLine("Fan Performance berubah menjadi balanced");
            }
            else if (currentState == State.Balanced)
            {
                currentState = State.Quiet;
                Console.WriteLine("Fan balanced berubah menjadi queit");
            }
        }

        public void TurboShortcut()
        {
            if (currentState == State.Quiet)
            {
                currentState = State.Turbo;
                Console.WriteLine("Fan Quiet berubah menjadi Turbo");
            }
            else if (currentState == State.Turbo)
            {
                currentState = State.Quiet;
                Console.WriteLine("Fan Turbo berubah menjadi Quiet");
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("-- TABLE DRIVEN --");
        string namaProduk = "";
        string kodeProduk;
        while (namaProduk != "selesai")
        {
            Console.Write("Masukkan nama produk(Masukkan selesai untuk mengakhiri): ");
            namaProduk = Console.ReadLine();
            kodeProduk = KodeProduk.GetKodeProduk(namaProduk);
            Console.WriteLine($"Kode produk untuk {namaProduk} adalah: {kodeProduk}");
        }

        Console.WriteLine("-- STATE BASED --");
        FanLaptop fan = new FanLaptop();
        bool running = true;

       while (running)
        {
            Console.WriteLine("");
            Console.WriteLine("-- Menu Fan Laptop --");
            Console.WriteLine("1. Mode Up");
            Console.WriteLine("2. Mode Down");
            Console.WriteLine("3. Turbo Shortcut");
            Console.WriteLine("4. Keluar");
            Console.WriteLine("---------------------");
            Console.WriteLine("");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    fan.ModeUp();
                    break;
                case "2":
                    fan.ModeDown();
                    break;
                case "3":
                    fan.TurboShortcut();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("keluar...");
                    break;
                default:
                    Console.WriteLine("pilihan tidak valid.");
                    break;
            }
        }
    }
}