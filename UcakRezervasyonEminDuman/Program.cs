using System;
using System.Collections.Generic;
using System.Linq;

class Ucak
{
    // Uçak özellikleri: model, seriNo, bakimTarihi, kisiKapasitesi
    public string Model { get; internal set; }
    public string SeriNo { get; internal set; }
    public DateTime BakimTarihi { get; internal set; }
    public int KisiKapasitesi { get; internal set; }
}

class Lokasyon
{
    public string Ulke { get; set; }
    public string Sehir { get; set; }
    public string Havaalani { get; set; }
    public bool KapaliAcikDurumu { get; set; }

    public static Lokasyon Bul(string sehirAdi)
    {
        // Lokasyonlar listesi
        var lokasyonlar = new List<Lokasyon> {
            new Lokasyon { Ulke = "Türkiye", Sehir = "İstanbul", Havaalani = "İstanbul Havalimanı", KapaliAcikDurumu = true },
            new Lokasyon { Ulke = "Türkiye", Sehir = "Ankara", Havaalani = "Esenboğa Havalimanı", KapaliAcikDurumu = true },
            new Lokasyon { Ulke = "Türkiye", Sehir = "İzmir", Havaalani = "Adnan Menderes Havalimanı", KapaliAcikDurumu = true },
            new Lokasyon { Ulke = "ABD", Sehir = "New York", Havaalani = "John F. Kennedy Havalimanı", KapaliAcikDurumu = false },
            new Lokasyon { Ulke = "Almanya", Sehir = "Berlin", Havaalani = "Berlin Brandenburg Havalimanı", KapaliAcikDurumu = true }
        };

        // Girilen şehir adına göre uygun lokasyon nesnesini bul
        Lokasyon lokasyon = lokasyonlar.FirstOrDefault(x => x.Sehir.Equals(sehirAdi, StringComparison.InvariantCultureIgnoreCase));

        if (lokasyon == null)
        {
            Console.WriteLine("Lokasyon bulunamadı.");
        }

        return lokasyon;
    }
}

class Rezervasyon
{
    // Rezervasyon özellikleri: ucak, lokasyon, musteri, tarihSaat, koltuk
    public Ucak Ucak { get; internal set; }
    public Lokasyon Lokasyon { get; internal set; }
    public Musteri Musteri { get; internal set; }
    public string? TarihSaat { get; internal set; }
    public int Koltuk { get; internal set; }
}

class Program
{
    static void Main()
    {
        Console.Write("Lokasyon girin(Baş harfi büyük olsun" +
            "): ");
        string lokasyonGirdisi = Console.ReadLine();

        Console.Write("Tarih girin: ");
        string tarihGirdisi = Console.ReadLine();

        Console.Write("Kaç kişilik bilet almak istiyorsunuz: ");
        int kisiSayisi = int.Parse(Console.ReadLine());

        Console.Write("Ad/Soyad: ");
        _ = Console.ReadLine();

        Lokasyon lokasyon = Lokasyon.Bul(lokasyonGirdisi);
        if (lokasyon == null)
        {
            Console.WriteLine("Lokasyon bulunamadı.");
            return;
        }

        Ucak ucak = new Ucak
        {
            Model = "Boeing 737",
            SeriNo = "1234-5678",
            BakimTarihi = DateTime.Parse("2022-01-01"),
            KisiKapasitesi = 180
        };

        Musteri musteri = new Musteri
        {
            AdSoyad = adSoyad
        };

        Rezervasyon rezervasyon = new Rezervasyon
        {
            Ucak = ucak,
            Lokasyon = lokasyon,
            Musteri = musteri,
            TarihSaat = tarihGirdisi,
            Koltuk = kisiSayisi
        };

        Console.WriteLine("Rezervasyon bilgileri:");
        Console.WriteLine($"Lokasyon: {rezervasyon.Lokasyon.Sehir}, {rezervasyon.Lokasyon.Ulke}");
        Console.WriteLine($"Tarih: {rezervasyon.TarihSaat}");
        Console.WriteLine($"Kişi sayısı: {rezervasyon.Koltuk}");
        Console.WriteLine($"Ad/Soyad: {rezervasyon.Musteri.AdSoyad}");
    }
}

internal class Musteri
{
    public object AdSoyad { get; internal set; }
}