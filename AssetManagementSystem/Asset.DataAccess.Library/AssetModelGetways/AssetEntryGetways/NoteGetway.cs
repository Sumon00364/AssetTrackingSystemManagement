using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways
{
    public class NoteGetway : IRepositoryGetway<Note>
    {
        private readonly NoteUnitOfWork _noteUnitOfWork;
        public NoteGetway()
        {
            _noteUnitOfWork = new NoteUnitOfWork(new AssetDbContext());
        }


        public Note Get(int id)
        {
            return _noteUnitOfWork.Note.Get(id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _noteUnitOfWork.Note.GetAll();
        }

        public int Add(Note entity)
        {
            _noteUnitOfWork.Note.Add(entity);
            return _noteUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Note> entities)
        {
            _noteUnitOfWork.Note.AddRange(entities);
            return _noteUnitOfWork.Complete();
        }

        public int Update(Note entity)
        {
            _noteUnitOfWork.Note.Update(entity);
            return _noteUnitOfWork.Complete();
        }

        public int Remove(Note entity)
        {
            _noteUnitOfWork.Note.Remove(entity);
            return _noteUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Note> entities)
        {
            _noteUnitOfWork.Note.RemoveRange(entities);
            return _noteUnitOfWork.Complete();
        }
    }
}
