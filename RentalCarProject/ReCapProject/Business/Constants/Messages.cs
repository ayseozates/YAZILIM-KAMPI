using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
  public static  class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarsNameInvalid = "Araç ismi geçersiz";
        public static string DailyPriceInvalid = "Kiralama fiyatı geçersiz";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarsDetailsListed = "Detaylı araç bilgileri listelendi";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string Added = "Başarı ile eklendi";
        public static string NameInValid = "Eksik veya hatalı bilgi";

        public static string Deleted = "Silme başarı ile gerçekleşti";

        public static string Updated = "Güncelleme işlemi başarılı";
        public static string CarCountOfColorError = "Aynı Renkten en fazla 10 araba olabilir";
        public static string CarNameAlreadyExists = "Bu isimde başka bir araba var";
        public static string ColorLimitExceded = "Color limiti aşıldığı için yeni araba eklenemiyor";
        public static string FailedCarImageAdd = "Resim eklenemedi";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string DeletedCarImage = "Araba resmi silindi";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Böyle bir kullanıcı mevcut";

        public static string AccessTokenCreated = "Giirş olustu";
        public static string UserRegistered = "User oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
    }
}
