﻿using System.Data.Entity;
using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories
{
    public class ServiceAndRepairingRepository : Repository<ServiceOrRepairing>, IServiceOrRepairingRepository
    {
        public ServiceAndRepairingRepository(DbContext context) 
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext
        {
            get
            {
                return Context as AssetDbContext;
            }
        }  
    }
}
