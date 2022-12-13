using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return "Bir veya daha fazla validasyon hatası ile karşılaşıldı.";
            }
        }
        public static class Category
        {
            
            public static string NotFound(bool isPlural = false)
            {
                if (isPlural) return "Hic kategori bulunamadi";
                return "Boyle bir kategori bulunamadi";
            }

            public static string NotFound(int categoryId)
            {
                return $"{categoryId} makale koduna ait bir veri bulunamadi";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla eklenmistir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla guncellenmistir.";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla silinmistir.";
            }

            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adli kategori veritabanindan basariyla silinmistir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adli kategori arşivden başarıyla geri getirilmiştir.";
            }
        }

        public static class Users
        {

            public static string NotFound(bool isPlural = false)
            {
                if (isPlural) return "Hic kategori bulunamadi";
                return "Boyle bir kategori bulunamadi";
            }

            public static string NotFound(int userId)
            {
                return $"{userId} kullanıcı koduna ait bir veri bulunamadi";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla eklenmistir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla guncellenmistir.";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla silinmistir.";
            }

            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adli kategori veritabanindan basariyla silinmistir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adli kategori arşivden başarıyla geri getirilmiştir.";
            }
        }

        public static class Article
        {
            public static string NotFound(bool isPlural = false)
            {
                if (isPlural) return "Hic makale bulunamadi";
                return "Boyle bir makale bulunamadi";
            }

            public static string NotFound(int articleId)
            {
                return $"{articleId} makale koduna ait bir veri bulunamadi";
            }

            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale arşivden başarıyla geri getirilmiştir.";
            }

            internal static string IncreaseViewCount(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale'nin okunma sayısı başarıyla arttırılmıştır.";
            }
        }

        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }

            public static string Approve(int commentId)
            {
                return $"{commentId} nolu yorum basariyla onaylanmıştır.";
            }

            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum arşivden başarıyla geri getirilmiştir.";
            }
        }
    }
}
