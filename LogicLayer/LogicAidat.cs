﻿using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.CompilerServices;

namespace LogicLayer
{
    public class LogicAidat
    {
        //Aidat tablosuna ait tüm verileri çeker.
        public static List<EntityAidat> LLAyAidatDoldur()
        {
            return DALAidat.DALAyAidatDoldur();
        }

        //Verilen yıla göre Aidat tablosundaki verileri çeker.
        public static List<EntityAidat> LLAyAidatDoldur(string yil)
        {
            return DALAidat.DALAyAidatDoldur(yil);
        }

        //Aidat verilerini günceller
        public static string LLAidatBelirle(EntityAidat Aidatlar)
        {
            return DALAidat.AidatBelirle(Aidatlar);
        }

        //Verilen tarihe göre aidat miktarı döndürür
        public static Decimal LLAidatMiktariAl(string ay, string yil)
        {
            return DALAidat.AidatMiktariAl(ay, yil);
        }

        //Aidat miktarlarını veritabanına ekler
        public static void LLUyeAidatEkle(decimal aidatmiktari)
        {
            DALAidat.UyeAidatEkle(aidatmiktari);
        }

        //Aktif üyelere o ayki aidat ücretini ekleyerek UyeAidat tablosuna işler
        public static bool LLAidatKayit(string tarih,decimal aidatMiktari)
        {
            return DALAidat.AidatKayit(tarih,aidatMiktari);
        }
        
        //Aktif üyelere aidat mail'i atar.
        public static string LLMailGonder(string konu,string mail, short secim)
        {
            if (mail != "" && konu != "")
            {
                switch (secim)
                {
                    case 0:
                        return DALAidat.AidatMailGonder(konu, mail);

                    case 1:
                        return DALAidat.BorcMailGonder(konu, mail);

                    default:
                        return "";
                }
            }
            else
            {
                return "Lütfen mail içeriği ekleyin...";
            }
        }

        //UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir()
        {
            return DALAidat.UyeAidatGetir();
        }
       
        //Verilen Tc'ye göre UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir(string Tc)
        {
            return DALAidat.UyeAidatGetir(Tc);
        }

        //UyeAidat tablosundaki odenmiş/odenmemiş verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir(bool odendi)
        {
            return DALAidat.UyeAidatGetir(odendi);
        }

        ////Verilen Tc ve Odeme durumuna göre UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir(bool odendi,string Tc)
        {
            return DALAidat.UyeAidatGetir(odendi, Tc);
        }

        //Tüm Borc tablosunu çeker.
        public static List<EntityBorc> LLUyeBorcGetir()
        {
            return DALAidat.UyeBorcGetir();
        }

        //Verilen tc'ye göre veritabanından borçları çeker.
        public static List<EntityBorc> LLUyeBorcGetir(string tc)
        {
            if (tc != "")
            {
                return DALAidat.UyeBorcGetir(tc);
            }
            else
            {
                //Boş döndürür.
                return null;
            }
        }

        //Verilen bool ifadeye göre veritabanından borçları çeker.
        public static List<EntityBorc> LLUyeBorcGetir(bool odendi)
        {
            return DALAidat.UyeBorcGetir(odendi);
        }

        //Verilen tc ve bool ifadeye göre veritabanından borçları çeker.
        public static List<EntityBorc> LLUyeBorcGetir(bool odendi, string tc)
        {
            if (tc != "")
            {
                return DALAidat.UyeBorcGetir(odendi,tc);
            }
            else
            {
                return null;
            }
        }

        //Odenmemiş aidatları kontrol edip borç tablosuna transferi ve geride kalan bilgilerin silinmesini gerçekleştirir.
        public static void LLOdenmemisAidatKontrol(string ayinsongunu, string gunumuz)
        {
            if (ayinsongunu != gunumuz)
            {
                DALAidat.OdenmemisAidatKontrol(false);
            }
        }

        //Verilen verilere göre pdf oluşturur.
        public static void LLPdfOlustur(List<EntityBorc> borclistesi,string yol)
        {
            DALAidat.PdfOlustur(borclistesi, yol);
        }

        //Seçili tarihlere göre ödenmiş aidatları getirir.
        public static List<EntityUyeAidat> LLAidatGetir(DateTime baslangic, DateTime bitis, bool odeme)
        {
            if (odeme)
            {
                return DALAidat.AidatGetir(baslangic, bitis, true);
            }
            else
            {
                return DALAidat.AidatGetir(baslangic, bitis, false);
            }
        }

        //Seçili tarihlere göre ödenmemiş aidatları getirir.
        public static List<EntityBorc> LLBorcGetir(DateTime baslangic, DateTime bitis, bool odeme)
        {
            if (odeme)
            {
                return DALAidat.BorcGetir(baslangic, bitis, true);
            }
            else
            {

                return DALAidat.BorcGetir(baslangic, bitis, false);
            }
        }

        //Şehirler ve o şehre bağlı üyeleri veritabanından çekiyoruz.
        public static Dictionary<string, int> GetUyeSayilariBySehir()
        {

            return DALAidat.GetUyeSayilariBySehir();
        }

        //
        public static void LLBorcOde(string tc)
        {
            DALAidat.BorcOde(tc);
        }

        //
        public static void LLAidatOde(string tc)
        {
            DALAidat.AidatOde(tc);
        }
    }
}
