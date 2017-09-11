using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Model
{
    public class ReceitaModel
    {
        public Int32 Id { get; set; }

        public String Titulo { get; set; }

        public Int32 IdCategoria { get; set; }

        public virtual CategoriaModel Categoria { get; set; }
    }
}
