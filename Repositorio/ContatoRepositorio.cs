using AgendaDeContatos.Data;
using AgendaDeContatos.Models;

namespace AgendaDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext contexto)
        {
            this._bancoContext = contexto;
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            try
            {
                // Update no banco de dados;
                ContatoModel cAux = this.Listar(contato.Id);
                if (cAux != null)
                {
                    cAux.Nome = contato.Nome;
                    cAux.Email = contato.Email;
                    cAux.Celular = contato.Celular;
                }
                else new Exception($"Houve um erro ao tentar atualizar o contato");
                _bancoContext.SaveChanges();
                return contato;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void Adicionar(ContatoModel contato)
        {
            // Insert no banco de dados;
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
        }

        public List<ContatoModel> Listar()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Listar(int pId) => _bancoContext.Contatos.FirstOrDefault(c => c.Id == pId);

        public void Deletar(int pId)
        {
            ContatoModel c = _bancoContext.Contatos.First(c => c.Id == pId);
            _bancoContext.Contatos.Remove(c);
            _bancoContext.SaveChanges();
        }
    }
}
