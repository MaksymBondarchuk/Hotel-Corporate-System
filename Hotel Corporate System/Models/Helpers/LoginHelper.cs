using System;
using System.Linq;
using Hotel_Corporate_System.Models.Database;

namespace Hotel_Corporate_System.Models.Helpers
{
	public static class LoginHelper
	{
		public static Database.Employee GetEmployee(string login, string password)
		{
			using (var context = new HotelContext())
			{
				return context.Employees.SingleOrDefault(e => e.Name.Equals(login, StringComparison.InvariantCultureIgnoreCase)
															  && e.Password.Equals(SecurityHelper.Encrypt(password)));
			}
		}
	}
}