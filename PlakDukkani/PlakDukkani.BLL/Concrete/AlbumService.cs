using PlakDukkani.BLL.Abstract;
using PlakDukkani.BLL.Concrete.ResultServiceBLL;
using PlakDukkani.DAL.Abstract;
using PlakDukkani.Model.Entities;
using PlakDukkani.ViewModel.AlbumViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlakDukkani.BLL.Concrete
{
    public class AlbumService : IAlbumBLL
    {
        IAlbumDAL albumDAL;
        public AlbumService(IAlbumDAL albumDAL)
        {
            this.albumDAL = albumDAL;
        }


        public ResultService<List<SingleAlbumVM>> GetSingleAlbums()
        {
            ResultService<List<SingleAlbumVM>> resultService = new ResultService<List<SingleAlbumVM>>();

            try
            {

                List<SingleAlbumVM> singleAlbums = albumDAL.GetAll(null, a => a.Artist)
                    .OrderByDescending(a => a.CreatedDate).Take(12)
                    .Select(album => new SingleAlbumVM
                    {
                        ID = album.ID,
                        FullName = album.Artist.FullName,
                        AlbumArtUrl = album.AlbumArtUrl,
                        Price = album.Price,
                        Title = album.Title,
                    }).ToList();
                resultService.Data = singleAlbums;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }
    }
}
