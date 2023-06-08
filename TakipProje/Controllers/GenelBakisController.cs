using ProjeTakip.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakipProje.Controllers
{
    public class GenelBakisController : Controller
    {
        private TakipProjeDBContext db = new TakipProjeDBContext(); //Veri tabanı bağlantısı

        // GET: GenelBakis
        public ActionResult Index()
        {
            int projeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi;

            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje= tamamlanmisProje;

            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var yuksekOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YüksekOncelikli = yuksekOncelikliProjeler;

            var dusukOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DüsükOncelikli = dusukOncelikliProjeler;

            var ortaOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaOncelikli = ortaOncelikliProjeler;

            var basariliVeYuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YüksekVeBasarili = basariliVeYuksek;

            var basariliVeOrta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaVeBasarili = basariliVeOrta;

            var basariliVeDusuk = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DüsükVeBasarili = basariliVeDusuk;

            var PersonelProjeListesi = db.PersonelProjeleris.ToList();
            var personelTamamlanmisProjeSayisi = new Dictionary<int, int>(); //personelId ve Tamamlanmisproje sayisi çiftlerini tutmak için
            foreach (var personel in db.PersonelBilgileris.ToList())
            {
                int tamamlanmisProjeSayisi = 0;
                foreach (var proje in personel.PersonelProjeleris)
                {
                    if (proje.TamamlanmaDurumu==true)
                    {
                        tamamlanmisProjeSayisi++;
                    }
                }
                personelTamamlanmisProjeSayisi[personel.PersonelBilgileriId] = tamamlanmisProjeSayisi;                
            }

            var siraliPersonelListesi = personelTamamlanmisProjeSayisi.OrderByDescending(x => x.Value);// tamamlanmış proje sayısına göre personelleri sırala
            var enCokTamamlananPersonelId = siraliPersonelListesi.First().Key;//En çok tamamlama sayısına sahip personeli al
            var enCokTamamlananPersonel = db.PersonelBilgileris.FirstOrDefault(p=>p.PersonelBilgileriId == enCokTamamlananPersonelId);
            ViewBag.EnCokTamamlayanPersonelBilgisi = enCokTamamlananPersonel.AdSoyad;

            int enCokProjeTamamlayanPersonelProjeSayisi = personelTamamlanmisProjeSayisi[enCokTamamlananPersonelId];
            ViewBag.EnCokProjeTamamlayanPersonelinProjeSayisi = enCokProjeTamamlayanPersonelProjeSayisi;
            return View();

        }

        public ActionResult Genelİstatistik()
        {
            var personeller = db.PersonelBilgileris.ToList();
            var personelProjeleri = db.PersonelProjeleris.ToList();
            var TamamlananProjeSayisi = new Dictionary<int, int>();
            var TamamlanmayanProjeSayisi= new Dictionary<int, int>();
            var ToplamProjeSayisi = new Dictionary<int, int>();

            foreach (var personel in personeller)
            {
                int TamamlananProje = 0;
                int TamamlanmayanProje = 0;
                int ToplamProje = 0;

                foreach (var proje in personelProjeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personel))
                    {
                        ToplamProje++;
                        if (proje.TamamlanmaDurumu)
                        {
                            TamamlananProje++;

                        }
                        else
                        {
                            TamamlanmayanProje++;
                        }
                    }

                }
                TamamlananProjeSayisi[personel.PersonelBilgileriId] = TamamlananProje;
                TamamlanmayanProjeSayisi[personel.PersonelBilgileriId] = TamamlanmayanProje;
                ToplamProjeSayisi[personel.PersonelBilgileriId] = ToplamProje;  


            }

            ViewBag.TamamlananProjeSayisi = TamamlananProjeSayisi;
            ViewBag.TamamlanmayanProjeSayisi = TamamlanmayanProjeSayisi;
            ViewBag.ToplamProjeSayisi = ToplamProjeSayisi;

            int projeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi;

            int personelSayisi = db.PersonelBilgileris.Count();
            ViewBag.PersonelSayisi = personelSayisi;


            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;


            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var basarisizVeYuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YüksekVeBasarisiz = basarisizVeYuksek;

            var basarisizVeOrta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaVeBasarisiz = basarisizVeOrta;

            return View(personeller);
        }
    }
}