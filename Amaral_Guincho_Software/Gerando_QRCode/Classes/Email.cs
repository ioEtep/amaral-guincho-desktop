using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Configuration;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    public static void sendEmail(String Destinatario, String Nome, String Assunto, String Conteudo)
    {
        string remetenteEmail = "garagemAmaral@gmail.com"; //O e-mail do remetente

        MailMessage mail = new MailMessage();

        mail.To.Add(Destinatario);

        mail.From = new MailAddress(remetenteEmail, Nome, System.Text.Encoding.UTF8);

        mail.Subject = Assunto;

        mail.SubjectEncoding = System.Text.Encoding.UTF8;

        mail.Body = Conteudo;

        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;

        mail.Priority = MailPriority.High; //Prioridade do E-Mail

        mail.IsBodyHtml = true;


        SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:

        client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "josephaAmaralCaio");



        client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio

        client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail

        client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

        try
        { client.Send(mail); }
        catch
        { }
    }

    public static void sendNewCad(String Destinatario, String NomeCadastro, String Usuario, String Senha)
    {
        sendEmail(Destinatario, "Amaral Guincho", "Amaral Guincho - Conta Criada com Sucesso",
            
            "A Amaral Guincho agradece por seu cadastro.<br /><br /><br />" +
            "<b>" + NomeCadastro +
                                            "</b><hr /><br /><b>Seus dados para login são:</b> " +
                                            "<br /><b>Login:</b> " + Usuario +
                                            "<br /><b>Senha:</b> " + Senha +
                                            "<br /><hr /><br />Atenciosamente, Amaral Guincho.");
    }

    public static void sendForgotPass(String Destinatario, String nome, String login, String senha)
    {
        sendEmail(Destinatario, "Amaral Guincho", "Amaral Guincho - Esqueceu a Senha",
            "<img src='' /><hr />" +
            "Prezado usuario <i>" + nome +
            "</i><br /><br />Login: <b>" + login +
            "</b><br />Senha: <b>" + senha + "</b><br /><br /><br />Atenciosamente, Amaral Guincho.");
    }

    public static void sendNewCadFunc(String Destinatario, String NomeCadastro, String Usuario, String Senha)
    {
        sendEmail(Destinatario, "Amaral Guincho", "Amaral Guincho - Conta Criada com Sucesso",
            "<img src='' /><hr />" +
            "Seja Bem vindo a empresa.<br /><br />" +
            "<b>" + NomeCadastro +
                                            "</b><hr /><br /><b>Seus dados para login como funcionário são:</b> " +
                                            "<br /><b>Usuário:</b> " + Usuario +
                                            "<br /><b>Senha:</b> " + Senha +
                                            "<br /><hr /><br />Atenciosamente, Amaral Guincho.");
    }
}