using CascaApi.Models;

namespace CascaApi.Repository
{
    public interface IExemploRepository
    {
        void Adicionar(ExemploModel item);
        List<ExemploModel> ListarTodos();
        ExemploModel? BuscarPorCpf(string cpf);
        List<ExemploModel> ListarAprovados();
    }
}