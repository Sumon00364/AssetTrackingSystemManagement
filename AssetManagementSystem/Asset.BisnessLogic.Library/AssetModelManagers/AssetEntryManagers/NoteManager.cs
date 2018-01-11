using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetEntryManagers
{
    public class NoteManager : IRepositoryManager<Note>
    {
        private readonly NoteGetway _noteGetway;
        public NoteManager()
        {
            _noteGetway = new NoteGetway();
        }


        public Note Get(int id)
        {
            return _noteGetway.Get(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteGetway.GetAll();
        }

        public int Add(Note entity)
        {
            return _noteGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Note> entities)
        {
            return _noteGetway.AddRange(entities);
        }

        public int Update(Note entity)
        {
            return _noteGetway.Update(entity);
        }

        public int Remove(Note entity)
        {
            return _noteGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Note> entities)
        {
            return _noteGetway.RemoveRange(entities);
        }
    }
}
