using Kanban.Data;
using Kanban.Dto;
using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Services.Atividade
{
    public class AtividadeService : IAtividadeInterface
    {


        private readonly AppDbContext _context;
        public AtividadeService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<AtividadeModel>> BuscarAtividade()
        {
            try
            {

                var atividades = await _context.Atividade.Include(x => x.Status).ToListAsync();
                return atividades;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StatusModel>> BuscarStatus()
        {
            var status = await _context.Status.ToListAsync();
            return status;
        }

       public async Task<AtividadeModel> CadastrarAtividade(CadastroAtividadeDto cadastroAtividadeDto)
        {
                Random rand = new Random();

                var atividade = new AtividadeModel()
                {
                    Titulo = cadastroAtividadeDto.Titulo,
                    Descricao = cadastroAtividadeDto.Descricao,
                    StatusId = cadastroAtividadeDto.StatusId,
                    Matricula = rand.Next(1000, 100000)
                };

                _context.Atividade.Add(atividade);
                await _context.SaveChangesAsync();
                return atividade;           
        }

        public async Task<AtividadeModel> ExcluirAtividade(int atividadeId)
        {
            try
            {
                var atividade = await _context.Atividade.FindAsync(atividadeId);
                _context.Remove(atividade);
                await _context.SaveChangesAsync();
                return atividade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> MudarCard(int atividadeId)
        {
            try
            {
                var atividade = await _context.Atividade.FindAsync(atividadeId);
                atividade.StatusId++;

                _context.Update(atividade); 
                await _context.SaveChangesAsync();

                return atividade;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtividadeModel> CardAnterior(int atividadeId)
        {
            try
            {
                var atividade = await _context.Atividade.FindAsync(atividadeId);
                atividade.StatusId--;
                _context.Update(atividade);
                await _context.SaveChangesAsync();
                return atividade;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
