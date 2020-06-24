using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Integracao
{
    public class BaseDados
    {
        public string StringConexao { get; set; } = "Server=localhost;Port=5433;User Id=postgres;Password=diogo300689;Database=integracao;CommandTimeout=3000";
        public string SQL { get; set; }

        public BaseDados()
        { }

        public BaseDados(string stringConexao, string sql)
        {
            StringConexao = stringConexao;
            SQL = sql;
        }

        public DataTable Obter()
        {
            DataTable Tabela = new DataTable();

            using (NpgsqlConnection Con = new NpgsqlConnection(StringConexao))
            {
                Con.Open();
                using (NpgsqlDataAdapter Da = new NpgsqlDataAdapter(SQL, Con))
                {
                    Da.Fill(Tabela);
                }
            }

            return Tabela;
        }

        public void Executar()
        {
            using (NpgsqlConnection Con = new NpgsqlConnection(StringConexao))
            {
                Con.Open();
                using (NpgsqlCommand Cmd = new NpgsqlCommand(SQL, Con))
                {
                    Cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
