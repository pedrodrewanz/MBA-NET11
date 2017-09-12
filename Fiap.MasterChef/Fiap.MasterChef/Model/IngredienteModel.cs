using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChef.Model
{
    public class IngredienteModel
    {
        public int ID { get; set; }

        public decimal Quantidade { get; set; }

        public string TipoMedida { get; set; }

        public string Nome { get; set; }
    }
}
