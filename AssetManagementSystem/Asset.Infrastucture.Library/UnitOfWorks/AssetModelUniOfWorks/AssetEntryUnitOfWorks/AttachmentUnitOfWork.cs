using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetEntryUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks
{
    public class AttachmentUnitOfWork : IAttachmentUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AttachmentUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Attachment = new AttachmentRepository(_context);
        }

        public IAttchmentRepository Attachment { get; set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
