using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GunlukKosuMesafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 adım 105 cm
            // dakikada 250 adım

            double ortAdim, dakAdim;
            double hiz, mesafe1, mesafe2;
            int sureSaat, sureDakika, revDakika;
            DateTime baslangic = new DateTime();
            DateTime bitis = new DateTime();
            Aralik[] liste = new Aralik[4];
            Aralik a1 = new Aralik();
            Aralik a2 = new Aralik();
            Aralik a3 = new Aralik();
            Aralik a4 = new Aralik();

        bilgilerCheck:
            Console.Clear();
            try
            {
                Console.WriteLine(" ********** Koşu Mesafe Ölçer  ********** ");
                Console.Write(" Bir adımınızın cm cinsinden ölçüsünü girin : ");
                ortAdim = Convert.ToDouble(Console.ReadLine());
                Console.Write(" Bir dakikada kaç adım koştuğunuzu girin : ");
                dakAdim = Convert.ToDouble(Console.ReadLine());
                Console.Write(" Koşu sürenizi saat cinsinden tam sayı olarak giriniz : ");
                sureSaat = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Koşu sürenizi dakika cinsinden tam sayı olarak giriniz : ");
                sureDakika = Convert.ToInt32(Console.ReadLine());
                bitis = bitis.AddMinutes(sureDakika);
                bitis = bitis.AddHours(sureSaat);
                hiz = (ortAdim * dakAdim / 100);
                if (ortAdim < 0 || dakAdim < 0 || sureSaat < 0 || sureDakika < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Negatif değer girdiniz. Değerleri doğru giriniz.");
                    Thread.Sleep(1500);
                    goto bilgilerCheck;
                }

            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine(" Hatalı giriş yatpınız. Değerleri doğru giriniz.");
                Thread.Sleep(1500);
                goto bilgilerCheck;
            }
            TimeSpan toplamSure = bitis - baslangic;


            Console.WriteLine();
            Console.WriteLine(" Koşu mesafesi doğruluğunu belli dakika aralığında belli adım/dk değerleri girerek \r\nartırabilirsiniz... ");
            Console.WriteLine(" Maksimum 4 farklı aralık girebilirsiniz. ");
        secimCheck:
            Console.Write(" Doğruluğu artırmak için E, istemiyorsanız H tuşlayınız : ");
            string secim = Console.ReadLine();
            Console.WriteLine();
            if (secim == "h" || secim == "H") { goto hesapla; }
            if (secim == "e" || secim == "E")
            {
            aralikSayiCheck:
                Console.Write($" {toplamSure.TotalMinutes} dakikalık koşu süresi içine normalden farklı kaç aralık gireceksiniz? : ");
                int aralikSayisi = 0;
                try
                {
                    aralikSayisi = Convert.ToInt32(Console.ReadLine());
                    if (aralikSayisi < 0 || aralikSayisi > 4)
                    {
                        Console.WriteLine(" Hatalı giriş yaptınız.");
                        goto aralikSayiCheck;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(" Hatalı giriş yaptınız.");
                    goto aralikSayiCheck;
                }


            aralikCheck:
                revDakika = 0;
                for (int i = 1; i <= aralikSayisi; i++)
                {
                sureCheck:
                    Console.WriteLine(" *********************** ");
                    Console.WriteLine($" {i}. Aralık");
                    Console.WriteLine($" Geriye kalan toplam koşu süresi : {toplamSure.TotalMinutes - a1.aralikDk - a2.aralikDk - a3.aralikDk - a4.aralikDk}");
                    Console.Write(" Koşu süresi içinde kalacak şekilde, dakika cinsinden bir süre giriniz : ");
                    try
                    {
                        revDakika = Convert.ToInt32(Console.ReadLine());


                        if (revDakika > toplamSure.TotalMinutes || revDakika < 0)
                        {
                            Console.WriteLine(" Hatalı giriş yaptınız.");
                            goto aralikCheck;
                        }
                        else
                        {
                            switch (i)
                            {
                                case 1:

                                    a1.aralikDk = revDakika;
                                    Console.Write($" Girdiğiniz {revDakika} dakika süresi içindeki adım hızınızı adım/dak giriniz : ");
                                    a1.aralikHiz = Convert.ToDouble(Console.ReadLine());
                                    break;
                                case 2:

                                    a2.aralikDk = revDakika;
                                    if (toplamSure.TotalMinutes - a1.aralikDk - a2.aralikDk < 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(" *************** Fazla süre girdiniz.");
                                        Console.WriteLine();
                                        a2.aralikDk = 0;
                                        goto sureCheck;
                                    }
                                    Console.Write($" Girdiğiniz {revDakika} dakika süresi içindeki adım hızınızı adım/dak giriniz : ");
                                    a2.aralikHiz = Convert.ToDouble(Console.ReadLine());
                                    break;
                                case 3:

                                    a3.aralikDk = revDakika;
                                    if (toplamSure.TotalMinutes - a1.aralikDk - a2.aralikDk - a3.aralikDk < 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(" *************** Fazla süre girdiniz.");
                                        Console.WriteLine();
                                        a3.aralikDk = 0;
                                        goto sureCheck;
                                    }
                                    Console.Write($" Girdiğiniz {revDakika} dakika süresi içindeki adım hızınızı adım/dak giriniz : ");
                                    a3.aralikHiz = Convert.ToDouble(Console.ReadLine());
                                    break;
                                case 4:

                                    a4.aralikDk = revDakika;
                                    if (toplamSure.TotalMinutes - a1.aralikDk - a2.aralikDk - a3.aralikDk - a4.aralikDk < 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(" *************** Fazla süre girdiniz.");
                                        Console.WriteLine();
                                        a4.aralikDk = 0;
                                        goto sureCheck;
                                    }
                                    Console.Write($" Girdiğiniz {revDakika} dakika süresi içindeki adım hızınızı adım/dak giriniz : ");
                                    a4.aralikHiz = Convert.ToDouble(Console.ReadLine());
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(" Hatalı giriş yaptınız.");
                        goto aralikCheck;
                    }


                }



            }
            else
            {
                Console.WriteLine(" Hatalı giriş yaptınız.");
                goto secimCheck;
            }

            // araliklar ile toplam hesap

            double hizA = a1.aralikHiz * ortAdim / 100;
            double hizB = a2.aralikHiz * ortAdim / 100;
            double hizC = a3.aralikHiz * ortAdim / 100;
            double hizD = a4.aralikHiz * ortAdim / 100;

            double mesafeA = hizA * a1.aralikDk;
            double mesafeB = hizB * a2.aralikDk;
            double mesafeC = hizC * a3.aralikDk;
            double mesafeD = hizD * a4.aralikDk;

            double aralikMesafe = mesafeA + mesafeB + mesafeC + mesafeD;
            double aralikDakika = a1.aralikDk + a2.aralikDk + a3.aralikDk + a4.aralikDk;

            mesafe1 = (toplamSure.TotalMinutes - aralikDakika) * hiz + aralikMesafe;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Toplam koşu mesafeniz : " + mesafe1 + " metredir.");
            Console.ReadKey();
            Environment.Exit(0);



        hesapla:

            mesafe2 = toplamSure.TotalMinutes * hiz;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Toplam koşu mesafeniz : " + mesafe2 + " metredir.");
            Console.ReadKey();
            Environment.Exit(0);


        }
    }
}
