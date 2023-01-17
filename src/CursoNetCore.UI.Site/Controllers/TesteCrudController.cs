using CursoNetCore.UI.Site.Data;
using CursoNetCore.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoNetCore.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Leandro",
                DataNascimento = DateTime.Now,
                Email = "mail@leandroborges.com.br"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "mail@leandroborges.com.br");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Leandro");

            aluno.Nome = "Diego";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View();
        }
    }
}
