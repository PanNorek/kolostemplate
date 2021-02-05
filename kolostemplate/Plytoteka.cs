using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace kolostemplate
{
    [Serializable]
    public class Plytoteka
    {
        string _nazwa, _telefon;
        Dictionary<string, PlytaAudio> _plyty;
      
        public Plytoteka(string nazwa, string telefon)
        {
            _plyty = new Dictionary<string, PlytaAudio>();
            _nazwa = nazwa;
            _telefon = telefon;
        }

        public string Telefon
        { 
            get {
                string pattern;
                // ^- poczatek stringa /d liczba {x}-ilosc  $ koniec stringa
                pattern = @"^\d{9}?$";
                Regex rgx = new Regex(pattern);
                if (rgx.IsMatch(_telefon))
                {
                    return _telefon;
                }
                throw new PhoneFormatException();
            } 

            set => _telefon = value; }
        public string Nazwa { get => _nazwa; set => _nazwa = value; }
        public Dictionary<string, PlytaAudio> Plyty { get => _plyty; set => _plyty = value; }

        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Nazwa} {Telefon}");
            foreach (var item in _plyty)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void DodajPlyte(PlytaAudio p)
        {
            _plyty.Add(p.Id, p);
        }
        public bool UsunPlyte(string id)
        {
            return _plyty.Remove(id);
        }
        public List<PlytaAudio> Szukaj(KategoriaMuzyki kategoria)
        {
            var tmp = new List<PlytaAudio>();
            foreach (var item in _plyty)
            {
                if (item.Value.Kategoria == kategoria)
                {
                    tmp.Add(item.Value);
                }
            }
            return tmp;
        }
        public double Podsumowanie()
        {
            return _plyty.Count();
        }
        public void Zapisz(string nazwa)
        {
            //konstrukcja gwarantujaca zeby nie martwic sie o zamkniecie pliku
            using (FileStream fs = new FileStream(nazwa, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, this);
            }
        }
        public static Plytoteka Odczytaj(string nazwa)
        {

            if (!File.Exists(nazwa))
            {
                return null;
            }
            using (FileStream fs = new FileStream(nazwa, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Plytoteka)formatter.Deserialize(fs);
            }

        }
    }
    

}
