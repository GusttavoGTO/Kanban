using Kanban.Dto;
using Kanban.Models;

namespace Kanban.Services.Atividade
{
    public interface IAtividadeInterface
    {
        Task<List<AtividadeModel>> BuscarAtividade();
        Task<List<StatusModel>> BuscarStatus();
        Task<AtividadeModel> CadastrarAtividade(CadastroAtividadeDto cadastroAtividadeDto);

        Task<AtividadeModel> ExcluirAtividade(int atividadeId);
        Task<AtividadeModel> MudarCard(int atividadeId);
        Task<AtividadeModel> CardAnterior(int atividadeId);
    }
}
