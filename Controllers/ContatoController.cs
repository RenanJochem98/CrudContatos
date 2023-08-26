using FrontEndAspNetMvc.Context;
using FrontEndAspNetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace FrontEndAspNetMvc.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if(ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoAntigo = _context.Contatos.Find(contato.Id);
            if (contatoAntigo != null && ModelState.IsValid)
            {
                contatoAntigo.Nome = contato.Nome;
                contatoAntigo.Telefone = contato.Telefone;
                contatoAntigo.Ativo = contato.Ativo;

                _context.Contatos.Update(contatoAntigo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);
            if(contatoBanco != null)
            {
                _context.Contatos.Remove(contatoBanco);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
