using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroservice.Core.Interface.Repository;
using UserMicroservice.Core.Interface.Service;
using UserMicroservice.Core.Model;

namespace UserMicroservice.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        //u controller samo dodaj guid.newguid() za id a sve ostalo dobijas sa postmena
        public Result Create(RegisteredUser registeredUser)
        {
            //findbyID dodaj u IUserRepository i napraviti metodu da proverava i username
            if ((_userRepository.FindById(registeredUser.Id).HasValue) || (_userRepository.FindByUsername(registeredUser.Username).HasValue)) return Result.Failure("Employee with that id or username already exist");
            _userRepository.Save(registeredUser);
            return Result.Success();
        }
    }
}