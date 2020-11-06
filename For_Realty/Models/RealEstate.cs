using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace For_Realty.Models
{
    public class RealEstate
    {
        public int RealEstateID { get; set; }
        public int Code { get; set; }
        public int? AmountBathrooms { get; set; }
        public int? AmountBedrooms { get; set; }
        public int? AmountToilets { get; set; }
        public int? ConstructionYear { get; set; }
        public int? AmountFacades { get; set; }
        public bool? HasParkingFacility { get; set; }
        public int? LivingArea { get; set; }
        public int? AreaKitchen { get; set; }
        public bool? HasDressing { get; set; }
        public bool? IsIsolated { get; set; }
        public bool? HasTerrace { get; set; }
        public bool? HasGarden { get; set; }
        public int AreaSpace { get; set; }
        public string DescriptionTitle { get; set; }
        public string Description { get; set; }
        public string HouseNr { get; set; }
        public string Street { get; set; }
        public Decimal Price { get; set; }
        public bool IsFloodArea { get; set; }
        public int? AmountOfFloors { get; set; }
        public int? FloorLevel { get; set; }
        public bool? HasLift { get; set; }
        public bool? HasAttic { get; set; }
        public Decimal Cadastral { get; set; }
        public bool? HasBuildingPermit { get; set; }

        public int? HeatingTypeID { get; set; }
        public HeatingType HeatingType { get; set; }

        public int? EnergyClassID { get; set; }
        public EnergyClass EnergyClass { get; set; }

        public int RealEstateTypeID { get; set; }
        public RealEstateType RealEstateType { get; set; }

        public int AgencyID { get; set; }
        public Agency Agency { get; set; }

        public int RealEstateStatusID { get; set; }
        public RealEstateStatus RealEstateStatus { get; set; }

        public int TownID { get; set; }
        public Town Town { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<RealEstatePicture> RealEstatePictures { get; set; }

    }
}
