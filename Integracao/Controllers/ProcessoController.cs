using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Integracao.Models;
using System.Data;
using System.Diagnostics;
using System.Security.Policy;

namespace Integracao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        [HttpGet]
        public List<Processo> Get()
        {
            BaseDados dados = new BaseDados();
            dados.SQL = "SELECT * FROM processos";
            DataTable tabela = dados.Obter();
            List<Processo> listaProcessos = new List<Processo>();
            Processo processo;

            foreach (DataRow linha in tabela.Rows)
            {
                processo = new Processo();

                processo.proc_id = Convert.ToInt32(linha["proc_id"]);
                processo.proc_grau = linha["proc_grau"].ToString();
                processo.proc_num = linha["proc_num"].ToString();

                listaProcessos.Add(processo);
            }

            return listaProcessos;
        }

        [HttpGet("{id}")]
        public Processo Get(int id)
        {
            BaseDados dados = new BaseDados();
            dados.SQL = "SELECT * FROM processos WHERE proc_id=" + id;

            Processo processo = new Processo();
            DataRow linha = dados.Obter().Rows[0];

            processo.proc_id = Convert.ToInt32(linha["proc_id"]);
            processo.proc_grau = linha["proc_grau"].ToString();
            processo.proc_num = linha["proc_num"].ToString();

            return processo;
        }

        [HttpPost]
        public int Post([FromBody] Processo processo)
        {
            BaseDados dados = new BaseDados();
            dados.SQL = "INSERT INTO processos(proc_grau, proc_num) VALUES ('" + processo.proc_grau + "', '" + processo.proc_num + "');";
            dados.Executar();

            dados.SQL = "SELECT MAX(proc_id) FROM processos";
            return Convert.ToInt32(dados.Obter().Rows[0][0]);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            BaseDados dados = new BaseDados();
            try
            {
                dados.SQL = "DELETE FROM processos WHERE proc_id=" + id;
                dados.Executar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut("{id}")]
        public Processo Put(int id, [FromBody] Processo processo)
        {
            processo.proc_id = id;

            BaseDados dados = new BaseDados();
            dados.SQL = "UPDATE processos SET proc_grau='" + processo.proc_grau + "', proc_num='" + processo.proc_num + "' WHERE proc_id=" + processo.proc_id;
            dados.Executar();

            return processo;
        }
    }
}