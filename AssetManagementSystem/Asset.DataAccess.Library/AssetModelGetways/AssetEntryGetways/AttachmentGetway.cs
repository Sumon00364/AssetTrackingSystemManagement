using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways
{
    public class AttachmentGetway : IRepositoryGetway<Attchment>
    {
        private readonly AttachmentUnitOfWork _attachmentUnitOfWork;
        public AttachmentGetway()
        {
            _attachmentUnitOfWork = new AttachmentUnitOfWork(new AssetDbContext());
        }


        public Attchment Get(int id)
        {
            return _attachmentUnitOfWork.Attachment.Get(id);
        }

        public IEnumerable<Attchment> GetAll()
        {
            return _attachmentUnitOfWork.Attachment.GetAll();
        }

        public int Add(Attchment entity)
        {
            _attachmentUnitOfWork.Attachment.Add(entity);
            return _attachmentUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Attchment> entities)
        {
            _attachmentUnitOfWork.Attachment.AddRange(entities);
            return _attachmentUnitOfWork.Complete();
        }

        public int Update(Attchment entity)
        {
            _attachmentUnitOfWork.Attachment.Update(entity);
            return _attachmentUnitOfWork.Complete();
        }

        public int Remove(Attchment entity)
        {
            _attachmentUnitOfWork.Attachment.Remove(entity);
            return _attachmentUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Attchment> entities)
        {
            _attachmentUnitOfWork.Attachment.RemoveRange(entities);
            return _attachmentUnitOfWork.Complete();
        }
    }
}
