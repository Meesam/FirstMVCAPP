using FirstMVCAPP.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCAPP.ViewModel
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();

        public string SearchKey { get; set; } = String.Empty;
    }
}
