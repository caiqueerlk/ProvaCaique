using CascaApi.Models;

namespace CascaApi.Repository
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly List<ExemploModel> _lista = new();

        public void Adicionar(ExemploModel item) => _lista.Add(item);
        public List<ExemploModel> ListarTodos() => _lista;
        public ExemploModel? BuscarPorCpf(string cpf) => _lista.FirstOrDefault(x => x.Cpf == cpf);
        public List<ExemploModel> ListarAprovados() => _lista.Where(x => x.Aprovado == true).ToList();
    }
}