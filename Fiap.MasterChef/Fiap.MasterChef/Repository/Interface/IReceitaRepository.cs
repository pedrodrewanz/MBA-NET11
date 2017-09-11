using Fiap.MasterChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Repository.Interface
{
    public interface IReceitaRepository
    {
        void Salvar(ReceitaModel receita);
        void Deletar(Int32 id);
        void Editar(ReceitaModel receita);
        List<ReceitaModel> BuscarTodos();
        ReceitaModel Buscar();
    }
}
