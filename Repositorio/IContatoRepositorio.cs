using AgendaDeContatos.Models;

namespace AgendaDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        void Adicionar(ContatoModel contato);

        void Deletar(int pId);

        List<ContatoModel> Listar();

        ContatoModel Editar(ContatoModel contato);

        /// <summary>
        /// Retorna um contato específico de acordo com o indice informado.
        /// </summary>
        /// <param name="pId">Índice do contato desejado </param>
        ContatoModel Listar(int pId);
    }
}
