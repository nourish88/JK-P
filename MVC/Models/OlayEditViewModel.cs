using Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class OlayEditViewModel
    {
        public OlayModel Olay { get; set; }
        public MultiSelectList Ihbarlar { get; set; }
        public SelectList Saatler { get; set; }
        public SelectList Dakikalar { get; set; }
    }
}
