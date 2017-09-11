using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Model
{
    public class CategoriaModel
    {
        public Int32 Id { get; set; }

        public String Nome { get; set; }

        public virtual ICollection<ReceitaModel> Receitas { get; set; }
    }
}
