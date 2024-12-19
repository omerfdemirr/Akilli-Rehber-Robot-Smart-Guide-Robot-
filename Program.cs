using System;
using System.Collections.Generic;
using System.Threading;

namespace AkilliRehberRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            AkilliRehber rehber = new AkilliRehber();
            rehber.Baslat();
        }
    }

    public class AkilliRehber
    {
        public string KullaniciAdi { get; private set; }
        public int Yas { get; private set; }
        public string IlgiAlani { get; private set; }

        private Dictionary<string, string> BilgiBankasi = new Dictionary<string, string>
        {
            { "hava durumu", "Bugün hava güneşli, sıcaklık 25°C. Açık havada vakit geçirmek için harika bir gün!" },
            { "motivasyon", "Başarısızlık, başarı yolundaki bir basamaktır. Denemeye devam et, harikasın!" },
            { "günün sözü", "Bilgi güçtür. Ama bilgiyi doğru kullanmak daha büyük bir güçtür." },
            { "teknoloji", "Yapay Zeka ve Blockchain, geleceğin iki anahtar teknolojisi. Takipte kal!" },
            { "film önerisi", "'Başlangıç (Inception)' - Zihinlerin sınırlarını zorlayan muhteşem bir film." },
            { "kitap önerisi", "'1984' - George Orwell. Distopik bir gelecekte özgürlük ve kontrolün savaşı." }
        };

        public void Baslat()
        {
            Console.Clear();
            Console.WriteLine("[Robot] Akıllı Rehber Robot'a Hoş Geldiniz!");
            Console.Write("Lütfen adınızı giriniz: ");
            KullaniciAdi = Console.ReadLine();
            Thread.Sleep(1000);

            Console.Clear();
            Console.WriteLine($"[Robot] Merhaba {KullaniciAdi}! Sana nasıl yardımcı olabilirim?");
            Thread.Sleep(1000);

            AnaMenu();
        }

        private void AnaMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[Robot] Ana Menü");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Bana bir şey sor");
                Console.WriteLine("2. Günlük öneri al");
                Console.WriteLine("3. Bilgi yarışmasına katıl");
                Console.WriteLine("4. Kişisel bilgileri güncelle");
                Console.WriteLine("5. Çıkış");
                Console.WriteLine("--------------------------------------");
                Console.Write("Bir seçenek seçin (1-5): ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        SorulariYanıtla();
                        break;
                    case "2":
                        GunlukOneri();
                        break;
                    case "3":
                        BilgiYarismasi();
                        break;
                    case "4":
                        KisiselBilgiGuncelle();
                        break;
                    case "5":
                        Console.WriteLine("[Robot] Görüşmek üzere! İyi günler dilerim!");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("[Robot] Hatalı bir seçim yaptınız. Lütfen tekrar deneyin.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        private void SorulariYanıtla()
        {
            Console.Clear();
            Console.WriteLine("[Robot] Sorularınızı sorabilirsiniz. (Çıkmak için 'çıkış' yazın)");
            while (true)
            {
                Console.Write("Soru: ");
                string soru = Console.ReadLine().ToLower();

                if (soru == "çıkış")
                {
                    Console.WriteLine("[Robot] Ana menüye dönülüyor...");
                    Thread.Sleep(1000);
                    break;
                }

                if (BilgiBankasi.ContainsKey(soru))
                {
                    Console.WriteLine($"[Robot] {BilgiBankasi[soru]}");
                }
                else
                {
                    Console.WriteLine("[Robot] Bu konuda bir bilgim yok, ama gelecekte öğrenebilirim!");
                }
            }
        }

        private void GunlukOneri()
        {
            Console.Clear();
            Console.WriteLine("[Robot] Günlük Öneri");
            Console.WriteLine("--------------------------------------");

            Random rnd = new Random();
            int rastgeleSecim = rnd.Next(BilgiBankasi.Count);

            var key = new List<string>(BilgiBankasi.Keys)[rastgeleSecim];
            Console.WriteLine($"Bugün için önerim: {key.ToUpper()}");
            Console.WriteLine($"[Robot] {BilgiBankasi[key]}");

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        private void BilgiYarismasi()
        {
            Console.Clear();
            Console.WriteLine("[Robot] Bilgi Yarışması Başlıyor!");
            Console.WriteLine("--------------------------------------");

            string[] sorular = {
                "1. Dünya hangi yılda 2. Dünya Savaşı'na katıldı? (a) 1937 (b) 1939 (c) 1941",
                "2. Ay, Dünya'nın etrafında kaç günde döner? (a) 29 (b) 30 (c) 31",
                "3. İnsan vücudundaki en büyük organ nedir? (a) Karaciğer (b) Cilt (c) Kalp"
            };

            string[] cevaplar = { "b", "a", "b" };
            int skor = 0;

            for (int i = 0; i < sorular.Length; i++)
            {
                Console.WriteLine(sorular[i]);
                Console.Write("Cevap: ");
                string cevap = Console.ReadLine().ToLower();

                if (cevap == cevaplar[i])
                {
                    Console.WriteLine("[Robot] Doğru cevap!");
                    skor++;
                }
                else
                {
                    Console.WriteLine("[Robot] Yanlış cevap.");
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine($"\n[Robot] Yarışma bitti! Skorunuz: {skor}/{sorular.Length}");
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        private void KisiselBilgiGuncelle()
        {
            Console.Clear();
            Console.WriteLine("[Robot] Kişisel Bilgilerinizi Güncelleyin:");

            Console.Write("Yaşınızı giriniz: ");
            Yas = int.Parse(Console.ReadLine());

            Console.Write("En çok ilgilendiğiniz alan nedir? (ör. Teknoloji, Sanat, Spor): ");
            IlgiAlani = Console.ReadLine();

            Console.WriteLine("\n[Robot] Bilgileriniz başarıyla güncellendi!");
            Thread.Sleep(2000);
        }
    }
}
