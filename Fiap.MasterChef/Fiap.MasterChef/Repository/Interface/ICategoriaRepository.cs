using Fiap.MasterChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Repository.Interface
{
    public interface ICategoriaRepository
    {
        void Salvar(CategoriaModel categoria);
        void Deletar(Int32 id);
        void Editar(CategoriaModel categoria);
        List<CategoriaModel> BuscarTodos();
        CategoriaModel Buscar();
    }
}
