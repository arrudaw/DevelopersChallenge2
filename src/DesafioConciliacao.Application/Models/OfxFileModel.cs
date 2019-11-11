using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DesafioConciliacao.MVC.Models
{
    public class OfxFileModel
    {
        [Required(ErrorMessage = "Selecione um ou mais arquivos OFX.")]
        [Display(Name = "Arquivos OFX")]
        public HttpPostedFileBase[] files { get; set; }
    }
}