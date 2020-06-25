using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultaProcesso
{
    public partial class ServicoConsultaProcesso : ServiceBase
    {
        public ServicoConsultaProcesso()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //crio uma nova thread com sobrecarga chamando o metodo que eu quero que microservico execute
            Thread thread = new Thread(new ThreadStart(ConsultaProcesso));
            thread.Start();

        }

        protected override void OnStop()
        {
        }

        protected void ConsultaProcesso()
        {
            // enquanto for verdadeiro para ficar sempre em execução
            while (true)
            {
                //consulta banco de dados ou API
                //Verificar movimento do processo por data
                //movimento enviar e-mail
            }

        }
    }
}
