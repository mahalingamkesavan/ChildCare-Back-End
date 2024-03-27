 #nullable disable
using businessServicess.models.RequestModels.ChildCare;
using System.Net.Mail;
using System.Text;

namespace ChildCareUtility
{
    public static class MailSender
    {
        public static void SendMail(Parent parent, EnrollmentRequest entrollment)
        {
            string mailbody = $"Hi {parent.FirstName} {parent.LastName} ,\n\n" + "\t"
             + "Your Child Enrollment Registration Sucessfull... " +
             "Your Email Id " + parent.Email
             + ", Your Registration Id " + parent.Id +
             ", Child Access Id  " + entrollment.childID +
             ", Child Admission Id " + entrollment.Id +
             " ,Child Schoole Joining Date " + entrollment.EnrollmentStartingDate +
             " ,Schoole Enting  Date " + entrollment.EnrollmentEndinggDate + " \n\n\n" + "\t" +
               " Regards\n\n" + "RKM Child Care Management System";

            string tomail = parent.Email;
            string from = "mahalingamk545@gmail.com";
            MailMessage message = new MailMessage(from, tomail);
            message.Subject = "Child Care Joining Letter";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = false;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("mahalingamk545@gmail.com", "spcrnqurzwhanpke");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.Send(message);
        }

        public static void ParentRegistrationConfirmationEmail(Parent parent)
        {
            string mailbody = $"Hi {parent.FirstName} {parent.LastName} ,\n\n" + "\t"
             + "Parent Registration Sucessfull... " +
             "Your Email Id " + parent.Email
             + ", Your  Registration Id " + parent.Id + " \n\n\n" + "\t" +
               " Regards\n\n" + "RKM Child Care Management System";

            string tomail = parent.Email;

            string from = "mahalingamk545@gmail.com";

            MailMessage message = new MailMessage(from, tomail);

            message.Subject = " Parent Registration Successfull";

            message.Body = mailbody;

            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = false;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("mahalingamk545@gmail.com", "spcrnqurzwhanpke");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            client.Send(message);

        }



    }
}




