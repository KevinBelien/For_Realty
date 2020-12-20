using For_Realty.Data.Repository;
using For_Realty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly For_RealtyDbContext _context;

        private IGenericRepository<Ad> adRepository;
        private IGenericRepository<Agency> agencyRepository;
        private IGenericRepository<EnergyClass> energyClassRepository;
        private IGenericRepository<Favorite> favoriteRepository;
        private IGenericRepository<HeatingType> heatingTypeRepository;
        private IGenericRepository<RealEstate> realEstateRepository;
        private IGenericRepository<RealEstatePicture> realEstatePictureRepository;
        private IGenericRepository<RealEstateStatus> realEstateStatusRepository;
        private IGenericRepository<RealEstateSubtype> realEstateSubtypeRepository;
        private IGenericRepository<RealEstateType> realEstateTypeRepository;
        private IGenericRepository<Town> townRepository;
        private IGenericRepository<UserAccount> userAccountRepository;

        public UnitOfWork(For_RealtyDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Ad> AdRepository
        {
            get
            {
                if (this.adRepository == null)
                {
                    this.adRepository = new GenericRepository<Ad>(_context);
                }
                return this.adRepository;
            }
        }

        public IGenericRepository<Agency> AgencyRepository
        {
            get
            {
                if (this.agencyRepository == null)
                {
                    this.agencyRepository = new GenericRepository<Agency>(_context);
                }
                return this.agencyRepository;
            }
        }

        public IGenericRepository<EnergyClass> EnergyClassRepository
        {
            get
            {
                if (this.energyClassRepository == null)
                {
                    this.energyClassRepository = new GenericRepository<EnergyClass>(_context);
                }
                return this.energyClassRepository;
            }
        }

        public IGenericRepository<Favorite> FavoriteRepository
        {
            get
            {
                if (this.favoriteRepository == null)
                {
                    this.favoriteRepository = new GenericRepository<Favorite>(_context);
                }
                return this.favoriteRepository;
            }
        }

        public IGenericRepository<HeatingType> HeatingTypeRepository
        {
            get
            {
                if (this.heatingTypeRepository == null)
                {
                    this.heatingTypeRepository = new GenericRepository<HeatingType>(_context);
                }
                return this.heatingTypeRepository;
            }
        }

        public IGenericRepository<RealEstate> RealEstateRepository
        {
            get
            {
                if (this.realEstateRepository == null)
                {
                    this.realEstateRepository = new GenericRepository<RealEstate>(_context);
                }
                return this.realEstateRepository;
            }
        }

        public IGenericRepository<RealEstatePicture> RealEstatePictureRepository
        {
            get
            {
                if (this.realEstatePictureRepository == null)
                {
                    this.realEstatePictureRepository = new GenericRepository<RealEstatePicture>(_context);
                }
                return this.realEstatePictureRepository;
            }
        }

        public IGenericRepository<RealEstateStatus> RealEstateStatusRepository
        {
            get
            {
                if (this.realEstateStatusRepository == null)
                {
                    this.realEstateStatusRepository = new GenericRepository<RealEstateStatus>(_context);
                }
                return this.realEstateStatusRepository;
            }
        }

        public IGenericRepository<RealEstateSubtype> RealEstateSubtypeRepository
        {
            get
            {
                if (this.realEstateSubtypeRepository == null)
                {
                    this.realEstateSubtypeRepository = new GenericRepository<RealEstateSubtype>(_context);
                }
                return this.realEstateSubtypeRepository;
            }
        }

        public IGenericRepository<RealEstateType> RealEstateTypeRepository
        {
            get
            {
                if (this.realEstateTypeRepository == null)
                {
                    this.realEstateTypeRepository = new GenericRepository<RealEstateType>(_context);
                }
                return this.realEstateTypeRepository;
            }
        }

        public IGenericRepository<Town> TownRepository
        {
            get
            {
                if (this.townRepository == null)
                {
                    this.townRepository = new GenericRepository<Town>(_context);
                }
                return this.townRepository;
            }
        }

        public IGenericRepository<UserAccount> UserAccountRepository
        {
            get
            {
                if (this.userAccountRepository == null)
                {
                    this.userAccountRepository = new GenericRepository<UserAccount>(_context);
                }
                return this.userAccountRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
