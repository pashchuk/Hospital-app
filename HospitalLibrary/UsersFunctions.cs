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

		public async Task<IEnumerable<User>> GetUsersByNameAsync(string userName)
		{
			return await Task.Run(() => from user in users
				where user.Name == userName
				select user);
		}

		public async Task<IEnumerable<User>> GetUsersByPhoneAsync(string phone)
		{
			return await Task.Run(() => from user in users
				where user.Phone == phone
				select user);
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
			var user = GetUserById(userId);
			if (user == null) throw new ArgumentException("Users with current id is not exist","userId");
			return password == user.Password;
		}
		
		public bool ChangeUserPassword(string password, int userId)
		{
			var user = GetUserById(userId);
			if (user == null) return false;
			user.Password = password;
			this.SaveChanges();
			return true;
		}

		public bool ChangeUserName(string userName, int UserId)
		{
			var user = GetUserById(UserId);
			if (user == null) return false;
			user.Name = userName;
			this.SaveChanges();
			return true;
		}

		public bool ChangeUserPhone(string phone, int userId)
		{
			var user = GetUserById(userId);
			if (user == null) return false;
			user.Phone = phone;
			this.SaveChanges();
			return true;
		}

		public User DeleteUser(int userId)
		{
			var user = GetUserById(userId);
			return user!=null ? this.users.Remove(user) : null;
		}

		public void CreateUser(User newUser)
		{
			this.users.Add(newUser);
			this.SaveChanges();
		}

		#endregion
	}
}
