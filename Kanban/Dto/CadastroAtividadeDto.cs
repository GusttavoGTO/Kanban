using System.ComponentModel.DataAnnotations;

namespace Kanban.Dto
{
    public class CadastroAtividadeDto
    {
        //public int Matricula { get; set; } sera criado na AtividadeService

        [Required(ErrorMessage = "Informe o titulo")]
        public  string? Titulo { get; set; }

        [Required(ErrorMessage = "Informe a Descrição")]
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int StatusId { get; set; }

    }
}
