using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TP_MOD08_1302213026
{
    internal class CovidConfiguration
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public CovidConfiguration() { }
        public CovidConfiguration(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }
    class UIConfig
    {
        public CovidConfiguration config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string filePath = "covid_config.json";
        public UIConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }

        private CovidConfiguration ReadConfig()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<CovidConfiguration>(configJsonData);
            return config;
        }
        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);

        }
        public void SetDefault() {
            config = new CovidConfiguration("celcius",14,"Anda tidak diperbolehkan masuk ke gedung ini","Anda diperbolehkan masuk ke gedung ini");
        }
        public bool UbahSatuan(double suhu, int hari_demam)
        {
            if (config.satuan_suhu == "celcius")
            {
                if (suhu < 36.5 || suhu > 37.5)
                {
                    return false;
                }
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                if (suhu < 97.7 || suhu > 99.5)
                {
                    return false;
                }
            }

            if (hari_demam >= config.batas_hari_demam)
            {
                return false;
            }

            return true;
        }
       
 
    }

}
