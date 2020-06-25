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
using System.Net;
using Newtonsoft.Json;
using ConsultaProcesso.Models;
using System.IO;
using System.Net.Mail;

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
            //buscar movimento de processos a cada minuto

            StringBuilder mensagemParaEmail = new StringBuilder(); //Construir uma mensagem que será o corpo do e-mail.

            while (true)
            {
                List<Movimento> listaMovimento = new List<Movimento>(); //declarar uma nova instancia de uma lista de movimentos

                var requisicao = HttpWebRequest.Create("http://localhost:56312/api/movimento"); //criar a requisição para o endpoint de consulta de movimento
                requisicao.ContentType = "application/json"; //tipo JSON
                requisicao.Method = "GET"; //método GET

                using (HttpWebResponse resposta = requisicao.GetResponse() as HttpWebResponse) //criar uma nova instancia para uma resposta de HttpwebResponse
                {
                    if (resposta.StatusCode == HttpStatusCode.OK) //verifica se o status da requisição é igual a 200 OK
                    {
                        using (StreamReader leitor = new StreamReader(resposta.GetResponseStream())) //criar uma instanica de um leitor para ler a resposta da requisição
                        {
                            var conteudo = leitor.ReadToEnd(); //ler a resposta completa
                            listaMovimento = JsonConvert.DeserializeObject<List<Movimento>>(conteudo); //serializar a resposta lida (json) e uma lista de objetos
                        }
                    }
                }

                foreach (Movimento movi in listaMovimento) //para cada movimento contido na lista de movimentos
                {
                    if (movi.movi_data == DateTime.Now) //ver se a atualização é de hoje
                        mensagemParaEmail.AppendLine("Atualização: " + movi.movi_descricao); //montar a mensagem para o e-mail
                }

                EnviarEmailMovimento(mensagemParaEmail.ToString()); //enviar o e-mail com as atualizações de movimento


                Thread.Sleep(60000); //esperar 1 minuto
            }

        }

        protected bool EnviarEmailMovimento(string CorpoMensagem)
        {
            SmtpClient cliente = new SmtpClient();
            MailAddress from = new MailAddress("naoresponda@avisourgente.com.br");
            MailAddress to = new MailAddress("diogoleonardo10@gmail.com");

            MailMessage Mensagem = new MailMessage(from, to);
            Mensagem.IsBodyHtml = true;
            Mensagem.Subject = "Atualização de Movimento de Processo";
            Mensagem.Body = CorpoMensagem;

            try
            {
                cliente.Host = "smtp.gmail.com"; ;
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential("naoresponda@avisourgente.com.br", "suasenha");

                cliente.Send(Mensagem);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
