using Microsoft.AspNet.Identity;
using MoneyManager.Core.Exceptions;
using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public enum RegistrationResult
        {
            Success,
            EmailAlreadyExist,
            PasswordDoNotMatch
        }

        public AuthenticationRepository(AccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public Account Login(string username, string password)
        {
            Account storedAccount = _accountRepository.GetByUsername(username);
            if (storedAccount == null)
            {
                throw new AccountNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.Password, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return storedAccount;
        }

        public RegistrationResult Register(string username, string password, string confirmPassword, double balance)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            Account  potentiallyExistedUser = _accountRepository.GetByUsername(username);

            if (potentiallyExistedUser != null)
            {
                result = RegistrationResult.EmailAlreadyExist;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                Guid guid = new Guid();
                Account user = new Account()
                {
                    Id = guid,
                    Username = username,
                    Password = hashedPassword,
                    Balance = balance,
                };
                _accountRepository.Create(user);
            }
            return result;
        }
    }
}
