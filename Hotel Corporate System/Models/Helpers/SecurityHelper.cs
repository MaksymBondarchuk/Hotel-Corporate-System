namespace Hotel_Corporate_System.Models.Helpers
{
	public static class SecurityHelper
	{
		public static string Encrypt(string text)
		{
			var data = System.Text.Encoding.UTF8.GetBytes(text);
			data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
			return System.Text.Encoding.UTF8.GetString(data);
		}
	}
}