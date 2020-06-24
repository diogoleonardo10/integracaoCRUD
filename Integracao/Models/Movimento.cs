using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao.Models
{
    public class Movimento
    {
        public int? movi_id { get; set; }
        public int movi_proc_id { get; set; }

        public string movi_descricao { get; set; }

        public DateTime movi_data { get; set; }

    }
}
