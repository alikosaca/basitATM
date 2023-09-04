// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;

Console.WriteLine("Senin bankan Senin özgürlüğün"); 
girisİslem:
Console.WriteLine("Kartsız İşlemler için 1'e kartlı işlemler için 2'ye tıklayınız");
string KullaniciAdi = "ali";
string kullaniciSifre = "123";
double kullaniciBakiye = 100000;
int kullaniciGirisHakki = 3;
int islem = 0;
try
{
    islem = int.Parse(Console.ReadLine());
    
}
catch(FormatException ex)
{
    Console.WriteLine("Yanlış tuşa bastınız Lütfen söylenen tuşlardan dışında başka tuşa basmadan tekrar deneyiniz: " + ex.Message);
    goto girisİslem;

}
catch(Exception ex)
{
    Console.WriteLine("Ups... İşleminiz gerçekleştirilemiyoruz. Lütfen daha sonra deneyiniz: " + ex.Message);
    return;
}
if (islem > 2)
{
    Console.WriteLine("Belirtilen dışında işlem gerçekleştirdiniz Lütfen tekrar belirtilen şekilde işlem gerçekleştirirniz...");
    goto girisİslem;
}
else if (islem == 2)
{
    Console.WriteLine("Lütfen Kartınızı yeşil alana yerleştirirniz.");
}
else
{

    Console.WriteLine("Kartsız İşlemlere Hoş geldiniz. \n Giriş \n Adınız: ");

    
    for (int i=1; i <= kullaniciGirisHakki; i++)
    {
         
        string kullaniciAdiGiris = Console.ReadLine();
        if (kullaniciAdiGiris == KullaniciAdi)
        {
            break;
        }
        else
        {
            Console.WriteLine("Girilen kullanıcı adı yanlış. Kalan deneme hakkı: " + (kullaniciGirisHakki - i /* burada neden -1 yaptı?*/ ));

            if (i == kullaniciGirisHakki )
            {
                Console.WriteLine("Üzgünüz, 3 deneme hakkınız doldu. İşlem sonlandırılıyor.");
                return;
            }
        }
        
    }
    Console.WriteLine("Kullanıcı adı mevcuttur.");

}
Console.WriteLine("Şifre: ");
    for(int i=1; i <= kullaniciGirisHakki; i++)
    {
        String kullaniciSifreGiris = Console.ReadLine();
        if (kullaniciSifreGiris == kullaniciSifre)
        {
                break;   
        }
        else
        {
            Console.WriteLine("Girilen şifre yanlış. Kalan Deneme Hakkı: " + (kullaniciGirisHakki - i));
                if(kullaniciGirisHakki == i)
                {
                    Console.WriteLine("Üzgünüz, 3 deneme hakkınız doldu. İşlem sonlandırılıyor.");
                    return;
                }
        }

        
    }

islem:
Console.WriteLine("Merhabalar Hoşgeldin "+KullaniciAdi+" Size nasıl yardımcı olabiliriz \n Güncel Bakiyeniz: " +kullaniciBakiye + "TL");
menu: // Menüden seçilen her hangi işlemden sonra tekrar buraya başka işlem gerçekleştirmek isterse atacaktır.
Console.WriteLine("Para yatırmak için 1'e \n Para çekmek için 2'ye \n çıkış yapmak için 3'de tıklayınız");
int kullaniciİstedigiİslem = 0;
try
{
     kullaniciİstedigiİslem = int.Parse(Console.ReadLine());

}
catch(FormatException ex)
{
    Console.WriteLine("Yanlış tuşa bastınız Lütfen söylenen tuşlardan dışında başka tuşa basmadan tekrar deneyiniz: " + ex.Message);
    goto islem;
}
catch(Exception ex)
{
    Console.WriteLine("Ups... İşleminiz gerçekleştirilemiyoruz. Lütfen daha sonra deneyiniz: " + ex.Message);
}
switch (kullaniciİstedigiİslem)
{
    case 1:
        paraYatir:
        Console.WriteLine("Güncel Bakiyeniz: " + kullaniciBakiye + "TL Yatırmak istediğiniz Tutarı giriniz");
        int paraYatir = 0;
        try
        {   
            paraYatir = int.Parse(Console.ReadLine());
        }
        catch(OverflowException ex)
        {
            Console.WriteLine("Limiti aştınız. 2.147.483.647 TL den fazla ATM üzerinden para yatıramazsınız. Lütfen paranızı geri alın ve limiti açmadan tekrar yatırınız..." + ex.Message);
            goto paraYatir;
        }
        catch(Exception ex)
        {
            Console.WriteLine("HATA İşleminiz Gerçekleştirilemedi... tekrar deneyiniz." + ex.Message);
            goto paraYatir;
        }

        kullaniciBakiye += paraYatir;
        Console.WriteLine("İşleminiz gerçekleştirmiştir. Güncel bakiyeniz: " + kullaniciBakiye);
        goto menu;
        break;
    case 2:
        paraCek:
        Console.WriteLine("Güncel Bakiyeniz: "+ kullaniciBakiye + "TL Çekmek istediğiniz Tutarı giriniz: ");
        int paraCek = 0;
        try
        {
            paraCek = int.Parse(Console.ReadLine());
        }
        catch(OverflowException ex)
        {
            Console.WriteLine("Limiti aştınız. 2.147.483.647 TL den fazla ATM üzerinden para çekemezsiniz. Lütfen limiti açmadayacak tutarı giriniz." + ex.Message);
            goto paraCek;
        }
        catch(Exception ex)
        {
            Console.WriteLine("HATA İşleminiz Gerçekleştirilemedi... tekrar deneyiniz" + ex.Message);
            goto paraCek;
        }
        kullaniciBakiye -= paraCek;
        Console.WriteLine("Para çekme işleminiz başarıyla gerçekleşmiştir. Güncel Bakiyeniz: " + kullaniciBakiye);
        goto menu;
        break;
    case 3:
        Console.WriteLine("Çıkış işleminiz Gerçekleşiyor... Sağlıcakla kalın:)");
        goto girisİslem; //atm 7/24 açık olduğundan dolayı menünyü başa sardık.
        break;
    
}

Console.WriteLine("Belirtilenin dışında işle gerçekleştirdiniz. Lütfen Menüyü tekrar gözden geçirerek işleminiz gerçekleştiriniz.");
goto menu;