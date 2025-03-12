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
        

    }
}