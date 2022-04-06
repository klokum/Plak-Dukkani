using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.BLL.Concrete.SendMailServiceBLL;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.Model.Entities;
using PlakDukkani.Model.Enums;
using PlakDukkani.ViewModel.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.BLL.Concrete
{
    class UserService : IUserBLL
    {
        IUserDAL userRepository;
        public UserService(IUserDAL userRepository)
        {
            this.userRepository = userRepository;
        }

        private void CheckPassword(string password)
        {
            if(password.Length <= 3)
            {
                throw new Exception("Password min 3 character");
            }
        }

        public ResultService<UserCreateVM> Insert(UserCreateVM user)
        {
            ResultService<UserCreateVM> userResult = new ResultService<UserCreateVM>();
            try
            {  
                //AutoMapper
                CheckPassword(user.Password);
                User addedUser = userRepository.Add(
                    new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName, 
                        Email = user.Email,
                        Password = user.Password,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        Role = UserRole.Standard,
                        ActivationCode = Guid.NewGuid()
                    }
                    );
                if (addedUser == null)
                {
                    //throw new Exception("Ekleme başarılı değil");
                    userResult.AddError("eklemeHatasi", "ekleme başarılı değil");
                    return userResult;
                }

                bool isSend = SendMailService.SendMail($"{addedUser.FirstName}{addedUser.LastName}", addedUser.Email, addedUser.ActivationCode);
                if (!isSend)
                {
                    userResult.AddError("mailHatasi", "mail gönderilemedi");
                    return userResult;
                }

                userResult.Data = user;
            }
            catch (Exception ex)
            {
                userResult.AddError("Exception", ex.Message);
            }
            return userResult;
        }

        public ResultService<bool> ActivateUser(Guid guid)
        {
            ResultService<bool> result = new ResultService<bool>();
            try
            {
                User user = userRepository.Get(a => a.ActivationCode == guid && !a.IsActive);
                if (user == null)
                {
                    result.AddError("null hatası", "Bu guide sahip user yok");
                    return result;
                }
                user.IsActive = true;
                User updatedUser = userRepository.Update(user);
                if (updatedUser == null)
                {
                    result.AddError("update hatası", "Update başarılı değil");
                    return result;
                }
                result.Data = true;
                return result;
            }
            catch (Exception ex)
            {
                result.AddError("Exception", ex.Message);
                return result;
            }
        }

    }
}
