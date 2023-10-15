using System;
using System.Threading.Tasks;
using TakeAway.Model.Models;

namespace TakeAway.Components.Logins.Services
{
	public interface ILoginService
	{
        Task<bool> GetLogin(Login login);
    }
}

