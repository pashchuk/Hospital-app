using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalLibrary
{
	partial class HospitalEntities
	{
		#region Async methods

		public async Task<User> GetUserByIdAsync(int id)
		{
			return await Task.Run(() => { return users.Find(id); });
		}
		public async Task<IEnumerable<User>> GetUsersByNameAsync(string userName)
		{
			return await Task.Run(() =>
			{
				return from user in users
					   where user.Name == userName
					   select user;
			});
		}

		#endregion

		#region Non-async methods

		public User GetUserById(int id)
		{
			return users.Find(id);
		}
		public IEnumerable<User> GetUsersByName(string userName)
		{
			return from user in users
				   where user.Name == userName
				   select user;
		}
		public IEnumerable<User> GetUsersByPhone(string phone)
		{
			return from user in users
				   where user.Phone == phone
				   select user;
		}

		public bool CheckUserPassword(string password, int userId)
		{
			return password == GetUserById(userId).Password;
		}

		#endregion
	}
}
