using System;
using System.Net.Mail;
using System.Net;
using ClientUser;

namespace DataBase
{
    public class GeneralMessages
    {
        public static void SendEmailNewLoan(string sendEmail, string name, BClaim claim) //послать имейл от клиента пользователя
        {
            MailAddress from = new MailAddress("aurel1us.mar@yandex.ru", "MoneyMota");
            MailAddress to = new MailAddress(sendEmail);
            MailMessage m = new MailMessage(from, to);
            //m.Attachments.Add(new Attachment(@"C:\gg\PS\EWryYElXsAsIOSA.jpg"));
            m.Subject = "Информация о вашем займе";
            m.Body = $"<h2>Здравствуйте,{name}</h2><p><b>Ваша заявка №{claim.Id}</b></p>" +
                $"<p>Вы оформили займ на сумму {claim.SumLoan}.В ближайщее время оператор рассмотрит вашу заявку.О принятии или отклонении заявки, вы сможете узнать в соответствующием сообщении.</p>" +
                "<p>или в приложении,в разделе <<Заявка>> по номеру заявки.</p>" +
                "<p>Если вы желаете отменить заявку,то это нужно сделать до ее рассмотрения оператором.Для этого нужно позвонить по телефону <b>9(000)111-22-33<b></p>"+
                "<p><h6>Данное сообщение является учебным.Все названия, телефоны,люди и имейлы выдуманы, и являются совпадениями.</h6></p>";
            

            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential("aurel1us.mar@yandex.ru", "qwrnvtxewxwdckco");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        public static void SendEmailNewStatus(string sendEmail,string typeNot,string name,BClaim claim) //послать имейл от клиента оператора
        {
            MailAddress from = new MailAddress("aurel1us.mar@yandex.ru", "MoneyMota");
            MailAddress to = new MailAddress(sendEmail);
            MailMessage m = new MailMessage(from, to);
            //m.Attachments.Add(new Attachment(@"C:\gg\PS\EWryYElXsAsIOSA.jpg"));
            m.Subject = "Изменение статса вашего займа!";
            m.Body = "";
            if (typeNot == "принято" && claim.type == "карта")
            {
                m.Body = $"<h2>Здравствуйте,{name}</h2><p><b>Ваша заявка №{claim.Id}</b> была принята.</p>" +
              $"<p>В скором времени на вашу карту поступят средства на сумму {claim.SumLoan}.Дополнительную информацию по займу вы можете получить в приложении,</ p> <p>или по телефону 9(000)111-22-33</p> и email: MoneyMotaSupport@SSSS.ru</p>" +
              $"<p>Первый день оплаты займа {claim.FirstDate.ToString("d")}.Если вы будет пропускать оплату, то вам будет начислен штраф.</p>" +
              $"<p>К выплате: {claim.SumPaid}</p> <p>Оплата в день: {claim.SumPaid / claim.Days}</p>"+
              "<p><h6>Данное сообщение является учебным.Все названия, телефоны,люди и имейлы выдуманы, и являются совпадениями.</h6></p>";
            }
            else if (typeNot == "принято" && claim.type == "наличка")
            {
                m.Body = $"<h2>Здравствуйте,{name}</h2><p><b>Ваша заявка №{claim.Id}</b> была принята.</p>" +
              $"<p>Вы выбрали получение наличных средств, вы можете получить выплату {claim.SumLoan}, по адресу <b>г.Шуя ул.Уличная д.96. с 9:00 до 21:00, необходим паспорт!</b>.Дополнительную информацию по займу вы можете получить в приложении,</ p ><p>или по телефону 9(000)111-22-33</p> и email: MoneyMotaSupport@SSSS.ru</p>" +
              $"<p>Первый день оплаты займа {claim.FirstDate.ToString("d")}.Если вы будет пропускать оплату, то вам будет начислен штраф.</p>"+
              $"<p>К выплате: {claim.SumPaid}</p> <p>Оплата в день: {claim.SumPaid / claim.Days}</p>" +
              "<p><h6>Данное сообщение является учебным.Все названия, телефоны,люди и имейлы выдуманы, и являются совпадениями.</h6></p>";
            }
            else if (typeNot == "закрыто")
            {
                m.Body = $"<h2>Здравствуйте,{name}</h2><p><b>Ваша заявка №{claim.Id}</b> была закрыта.</p>" +
                    "<p>Это скорее всего означет, что вы выплатили свой займ.<p>" +
                    "<p><h6>Данное сообщение является учебным.Все названия, телефоны,люди и имейлы выдуманы, и являются совпадениями.</h6></p>";
            }
            else
            {
                m.Body = $"<h2>Здравствуйте,{name}</h2><p><b>Ваша заявка №{claim.Id}</b> была отклонена.</p>" + 
                    "<p>Дополнительную информацию о причинах вы можете получить по телефону 9(000)111-22-33</p> или email: MoneyMotaSupport@SSSS.ru" +
                    "<p><h6>Данное сообщение является учебным.Все названия, телефоны,люди и имейлы выдуманы, и являются совпадениями.</h6></p>";
            }
            m.IsBodyHtml = true;
            m.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential("aurel1us.mar@yandex.ru", "qwrnvtxewxwdckco");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
