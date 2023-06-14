using TakipProje.Models.ProjeTakip;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace TakipProje.Models.Personel
{
    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {
            this.PersonelProjeleris = new HashSet<PersonelProjeleri>();
        }
        [Key]
        public int PersonelBilgileriId { get; set; }

        [DisplayName("EMAIL")]
        public string Eposta { get; set; }
        [DisplayName("PASSWORD")]
        [StringLength(25,ErrorMessage ="Maximum uzunluk 25 karakterden fazla olamaz")]
        public string Sifre { get; set; }

        [DisplayName("AUTHORITY")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string Yetki { get; set; }

        [DisplayName("NAME SURNAME")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string AdSoyad { get; set; }
        [DisplayName("EMPLOYEE PHOTO")]
        public string PersonelGörseli { get; set; }

        [DisplayName("TC NUMBER")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string TCNO { get; set; }
        [DisplayName("DEPARTMANT")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string  Departman { get; set; }
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        [DisplayName("POSITION")]
        public string Gorev { get; set; }
        [DisplayName("DESCRIPTION")]
        public string PozisyonAciklama { get; set; }
        [DisplayName("PHONE NUMBER")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string TelNo { get; set; }
        [DisplayName("ADRESS")]
        public string Adres { get; set; }
        [DisplayName("MARITAL STATUS")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string MedeniHal { get; set; }
        [DisplayName("FAMILY MEMBER INFORMATION")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinBilgisi { get; set; }
        [DisplayName("FAMILY MEMBER TC NUMBER")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinTC { get; set; }
        [DisplayName("FAMILY MEMBER NAME SURNAME")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinAdSoyad { get; set; }
        [DisplayName("FAMILY MEMBER PHONE NUMBER")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz")]
        public string YakinTel { get; set; }
        [DisplayName("DATE OF BIRTH")]
        public DateTime DogumTarihi { get; set; }
        [DisplayName("START DATE OF WORK")]
        public DateTime? IseGirisTarihi { get; set; }

        public virtual ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }
    }
}
