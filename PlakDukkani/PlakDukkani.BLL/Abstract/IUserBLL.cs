using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.UserViewModels;
using System;

namespace PlakDukkani.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        public ResultService<UserCreateVM> Insert(UserCreateVM user);
        ResultService<bool> ActivateUser(Guid id);
        ResultService<bool> CheckUserForLogin(string email, string password);
    }
}
