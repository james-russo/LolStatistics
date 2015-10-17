using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolWorldFinalStats.Services;
using Microsoft.AspNet.Identity;

namespace LolWorldFinalStats.Models
{
    public class NHibernateUserStore<T> : IUserStore<T>, IUserPasswordStore<T>, IUserEmailStore<T>,
        IUserLockoutStore<T, string>,
        IUserTwoFactorStore<T, string>,
        IUserSecurityStampStore<T> where T : User, IUser, new()
    {
        private readonly UserService userService;
        public NHibernateUserStore(UserService userService)
        {
            this.userService = userService;
        }

        public Task CreateAsync(T user)
        {
            return Task.Run(() =>
            {
                userService.Save(user);
            });
        }

        public Task DeleteAsync(T user)
        {
            return Task.FromResult(0);
        }

        public void Dispose()
        {
        }

        public Task<T> FindByIdAsync(string userId)
        {
            return Task.Run<T>(() =>
            {
                int id = int.Parse(userId);

                var profile = userService.GetUsers(a => a.Id == id)
                    .FirstOrDefault();

                if (profile != null)
                    return AutoMapper.Mapper.Map(profile, new T());

                return null;

            });
        }

        public Task<T> FindByNameAsync(string userName)
        {
            return Task.Run<T>(() =>
            {
                var profile = userService.GetUsers(a => a.Email == userName)
                    .FirstOrDefault();

                if (profile != null)
                    return AutoMapper.Mapper.Map(profile, new T());

                return null;

            });
        }

        public Task UpdateAsync(T user)
        {
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(T user, string passwordHash)
        {
            return Task.Run(() => { user.PasswordHash = passwordHash; });
        }

        public Task<string> GetPasswordHashAsync(T user)
        {
            return Task.Run(() => user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(T user)
        {
            return Task.Run(() => !string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetEmailAsync(T user, string email)
        {
            return Task.Run(() => user.Email = email);
        }

        public Task<string> GetEmailAsync(T user)
        {
            return Task.Run(() => user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(T user)
        {
            return Task.Run(() =>
            {
                var profile = userService.GetUsers(a => a.Email == user.Email);

                return profile != null;
            });
        }

        public Task SetEmailConfirmedAsync(T user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        public Task<T> FindByEmailAsync(string email)
        {
            return FindByNameAsync(email);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(T user)
        {
            return Task.FromResult(DateTimeOffset.MaxValue);
        }

        public Task SetLockoutEndDateAsync(T user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(T user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(T user)
        {
            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(T user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(T user)
        {
            return Task.Run(() => false);
        }

        public Task SetLockoutEnabledAsync(T user, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(T user, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(T user)
        {
            return Task.FromResult(false);
        }

        public Task SetSecurityStampAsync(T user, string stamp)
        {
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(T user)
        {
            return Task.FromResult("YO SECURITY STAMP");
        }
    }
}
