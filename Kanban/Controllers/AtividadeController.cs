using Kanban.Dto;
using Kanban.Services.Atividade;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly IAtividadeInterface _atividadeInterface;
        public AtividadeController(IAtividadeInterface atividadeInterface)
        {
            _atividadeInterface = atividadeInterface;
        }

        public async Task<IActionResult> Index()
        {
            var atividades = await _atividadeInterface.BuscarAtividade();

            return View(atividades);
        }

        public async Task<IActionResult> Cadastrar()
        {
            var status = await _atividadeInterface.BuscarStatus();
            ViewBag.Status = status;
           
            return View();
        }
        public async Task<IActionResult> Excluir(int id)
        {
            var atividade = await _atividadeInterface.ExcluirAtividade(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MudarCard(int id)
        {
            var atividade = await _atividadeInterface.MudarCard(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CardAnterior(int id)
        {
            var atividade = await _atividadeInterface.CardAnterior(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastroAtividadeDto cadastroAtividadeDto)
        {
            if (ModelState.IsValid)
            {
                var cadastro = await _atividadeInterface.CadastrarAtividade(cadastroAtividadeDto);
                return RedirectToAction("Index");
            }
            else
            {
                var status = await _atividadeInterface.BuscarStatus();
                ViewBag.Status = status;
                return View(cadastroAtividadeDto);
            }
          
        }

    }
}
