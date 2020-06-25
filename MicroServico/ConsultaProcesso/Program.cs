using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ConsultaProcesso
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {

#if DEBUG
            ServicoConsultaProcesso Servico = new ServicoConsultaProcesso();
            Servico.OnDebug();
            System.Threading.Thread.Sleep(10000);
#else
#endif
            /*ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServicoConsultaProcesso()
            };
            ServiceBase.Run(ServicesToRun);*/
        }
    }
}
