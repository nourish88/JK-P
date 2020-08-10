using Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class KullaniciRegisterViewModel
    {
        public KullaniciModel Kullanici { get; set; }
        public SelectList Personeller { get; set; }
    }
}
