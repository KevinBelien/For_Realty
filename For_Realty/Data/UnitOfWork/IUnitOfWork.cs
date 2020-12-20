using For_Realty.Data.Repository;
using For_Realty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Ad> AdRepository { get; }
        IGenericRepository<Agency> AgencyRepository { get; }
        IGenericRepository<EnergyClass> EnergyClassRepository { get; }
        IGenericRepository<Favorite> FavoriteRepository { get; }
        IGenericRepository<HeatingType> HeatingTypeRepository { get; }
        IGenericRepository<RealEstate> RealEstateRepository { get; }
        IGenericRepository<RealEstatePicture> RealEstatePictureRepository { get; }
        IGenericRepository<RealEstateStatus> RealEstateStatusRepository { get; }
        IGenericRepository<RealEstateSubtype> RealEstateSubtypeRepository { get; }
        IGenericRepository<RealEstateType> RealEstateTypeRepository { get; }
        IGenericRepository<Town> TownRepository{ get; }
        IGenericRepository<UserAccount> UserAccountRepository { get; }

        Task Save();
    }
}
