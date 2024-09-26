using System.Net.Mail;

namespace LibraryToDo.Helpers
{
	public static class EmailCheckExpression
	{
        public static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

