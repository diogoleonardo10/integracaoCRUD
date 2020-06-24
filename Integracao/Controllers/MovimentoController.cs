using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Integracao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Integracao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        [HttpGet]
        public List<Movimento> Get()
        {
            BaseDados bd = new BaseDados();

            bd.SQL = "SELECT * FROM movimento";
            DataTable dados = bd.Obter();

            List<Movimento> ListMovimento = new List<Movimento>();
            Movimento mov;

            foreach (DataRow linha in dados.Rows)
            {
                mov = new Movimento();

                mov.movi_id = Convert.ToInt32(linha["movi_id"]);
                mov.movi_proc_id = Convert.ToInt32(linha["movi_proc_id"]);
                mov.movi_descricao = linha["movi_descricao"].ToString();
                mov.movi_data = Convert.ToDateTime(linha["movi_data"]);

                ListMovimento.Add(mov);
            }

            return ListMovimento;
        }
        [HttpGet("{id}")]
        public List<Movimento> Get(int id)
        {
            BaseDados dados = new BaseDados();
            dados.SQL = "SELECT * FROM movimento WHERE movi_proc_id=" + id;
            //busca todos os movimentos do processo por id

            List<Movimento> ListMovimento = new List<Movimento>();
            Movimento movimento;

            foreach (DataRow linha in dados.Obter().Rows)
            {
                movimento = new Movimento();

                movimento.movi_id = Convert.ToInt32(linha["movi_id"]);
                movimento.movi_proc_id = Convert.ToInt32(linha["movi_proc_id"]);
                movimento.movi_data = Convert.ToDateTime(linha["movi_data"]);
                movimento.movi_descricao = linha["movi_descricao"].ToString();

                ListMovimento.Add(movimento);
            }
            return ListMovimento;
        }

        [HttpPost]
        public int Post([FromBody] Movimento movimento)
        {
            BaseDados dados = new BaseDados();
            dados.SQL = "INSERT INTO movimento(movi_descricao, movi_data, movi_proc_id) VALUES ('" + movimento.movi_descricao + "','" + movimento.movi_data + "', '"+ movimento.movi_proc_id +"');";
            dados.Executar();

            dados.SQL = "SELECT MAX(movi_id) FROM movimento";
            return Convert.ToInt32(dados.Obter().Rows[0][0]);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            BaseDados dados = new BaseDados();

            try
            {
                dados.SQL = "DELETE FROM movimento WHERE movi_id="+ id;
                dados.Executar();

                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public Movimento Put(int id, [FromBody] Movimento movimento)
        {
            movimento.movi_id = id;

            BaseDados dados = new BaseDados();
            dados.SQL = "UPDATE movimento SET movi_data='" + movimento.movi_data + "', movi_descricao='" + movimento.movi_descricao + "' WHERE movi_id=" + movimento.movi_id;
            dados.Executar();

            return movimento;
        }
    }
}