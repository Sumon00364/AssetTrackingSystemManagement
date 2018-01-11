using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetEntryManagers
{
    public class AttachmentManager : IRepositoryManager<Attchment>
    {
        private readonly AttachmentGetway _attachmentGetway;
        public AttachmentManager()
        {
            _attachmentGetway = new AttachmentGetway();
        }


        public Attchment Get(int id)
        {
            return _attachmentGetway.Get(id);
        }

        public IEnumerable<Attchment> GetAll()
        {
            return _attachmentGetway.GetAll();
        }

        public int Add(Attchment entity)
        {
            return _attachmentGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Attchment> entities)
        {
            return _attachmentGetway.AddRange(entities);
        }

        public int Update(Attchment entity)
        {
            return _attachmentGetway.Update(entity);
        }

        public int Remove(Attchment entity)
        {
            return _attachmentGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Attchment> entities)
        {
            return _attachmentGetway.RemoveRange(entities);
        }
    }
}
