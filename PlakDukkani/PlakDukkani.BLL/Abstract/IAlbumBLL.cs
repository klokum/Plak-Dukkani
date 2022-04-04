using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.AlbumViewModels;
using System.Collections.Generic;

namespace PlakDukkani.BLL.Abstract
{
    public interface IAlbumBLL : IBaseBLL<Album>
    {
        ResultService<List<SingleAlbumVM>> GetSingleAlbums();
    }
}
