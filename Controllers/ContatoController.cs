using AgendaDeContatos.Models;
using AgendaDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        public readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var lContatos = _contatoRepositorio.Listar();
            return View(lContatos);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(ContatoModel pContato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     _contatoRepositorio.Adicionar(pContato);
                    TempData["MsgSucesso"] = $"Contato {pContato.Nome} cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                else return View(pContato);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = $"Não foi possível cadastrado os dados do contato.\n#Det. Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int pId) => View(_contatoRepositorio.Listar(pId));

        [HttpPost]
        public IActionResult Editar(ContatoModel pContato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Editar(pContato);
                    TempData["MsgSucesso"] = $"Contato {pContato.Nome} editado com sucesso!";
                    return RedirectToAction("Index");
                }
                else return View("Editar", pContato);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = $"Não foi possível editar os dados do contato.\n#Det. Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeletarView(int pId) => View(_contatoRepositorio.Listar(pId));

        public IActionResult Deletar(int pId)
        {
            try
            {
                TempData["MsgSucesso"] = $"Contato {_contatoRepositorio.Listar(pId).Nome} deletado com sucesso!";
                _contatoRepositorio.Deletar(pId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = $"Não foi possível deletar os dados do contato.\n#Det. Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
