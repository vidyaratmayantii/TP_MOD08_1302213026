using TP_MOD08_1302213026;

internal class Program
{
    private static void Main(string[] args)
    {
        CovidConfiguration config = new CovidConfiguration();
        UIConfig uiConfig = new UIConfig();
        Console.WriteLine("Berapa suhu badan anda saat ini ? Dalam nilai<CONFIG1>");
        double Suhu = double.Parse( Console.ReadLine());
        Console.WriteLine("berapa hari yang lalu(perkiraan) anda terakhir gejala demam?");
        int hari_demam =int.Parse( Console.ReadLine());
        deceide();

        void deceide()
        {

            if (uiConfig.UbahSatuan(Suhu, hari_demam))
            {
                Console.WriteLine(uiConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(uiConfig.config.pesan_ditolak);


            }
        }

       

    }

   
}