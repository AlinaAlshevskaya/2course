using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MSSQL = DAL_Celebrity_MSSQL;
using REPO = DAL_Celebrity;
namespace ASPA_007_1.Pages
{
    public class CelebritiesModel : PageModel
    {

        public List<MSSQL.Celebrity> Celebrities { get; set; } = new List<MSSQL.Celebrity>();

        public string pathToZero = "api/Celebrities/photo/ALMAZ.jpg";
        public MSSQL.IRepository repo;

        public CelebritiesModel(MSSQL.IRepository repo)
        {
            this.repo = repo;
        }
        public ActionResult OnGet()
        {
            this.Celebrities = this.repo.GetAllCelebrities().ToList();
            return Page();
        }
    }
}