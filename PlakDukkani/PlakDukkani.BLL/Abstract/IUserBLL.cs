using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.UserViewModels;
using System;

namespace PlakDukkani.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        public ResultService<UserCreateVM> Insert(UserCreateVM user);
        bool ActivedUser(Guid guid);
    }
}
