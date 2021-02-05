using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolostemplate
{
    [Serializable]
    public enum KategoriaMuzyki { rock,folk,metal,jazz,soul,pop}
    [Serializable]
    public class PlytaAudio
    {
        static long _licznik;
        string _id;
        string _wykonawca;
        string _tytul;
        DateTime _dataWydania;
        double _cena;
        KategoriaMuzyki _kategoria;
        static PlytaAudio()
        {
            _licznik = 1;
        }
        public PlytaAudio(string wykonawca, string tytul, string data, double cena, string kategoria)
        {
            _wykonawca = wykonawca;
            _tytul = tytul;
            
            DateTime.TryParse(data, out _dataWydania);
            
            _cena = cena;
            Enum.TryParse<KategoriaMuzyki>(kategoria, out _kategoria);
            _id = $"RN{_licznik}";
            _licznik++;

        }

        public string Wykonawca { get => _wykonawca; set => _wykonawca = value; }
        public string Tytul { get => _tytul; set => _tytul = value; }
        public DateTime DataWydania { get => _dataWydania; set => _dataWydania = value; }        
        public double Cena { get => _cena; set => _cena = value; }
        public KategoriaMuzyki Kategoria { get => _kategoria; set => _kategoria = value; }
        public string Id { get => _id; set => _id = value; }

        public override string ToString()
        {
            return $"{Wykonawca} \"{Tytul}\" ({Kategoria.ToString()} {DataWydania.ToString("MMMM yyyy")}), {Cena.ToString("C")}";
        }
    }
}
