using System.Collections.Generic;
using Asset.DataAccess.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace Asset.BisnessLogic.Library.Organizations
{
    public class DesignationManager:IRepositoryManager<Designation>
    {
        private readonly DesignationGetway _designationGetway;

        public DesignationManager()
        {
            _designationGetway = new DesignationGetway();
        }


        public Designation Get(int id)
        {
            return _designationGetway.Get(id);
        }

        public IEnumerable<Designation> GetAll()
        {
            return _designationGetway.GetAll();
        }

        public int Add(Designation entity)
        {
            return _designationGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Designation> entities)
        {
            return _designationGetway.AddRange(entities);
        }


        public bool IsDesignationShortNameExist(string shortNme)
        {
            bool isDesignationExist = false;
            var designation = GetDesignationByShortName(shortNme);
            if (designation != null)
            {
                isDesignationExist = true;
            }
            return isDesignationExist;
        }

        private Designation GetDesignationByShortName(string shortNme)
        {
            return _designationGetway.GetDesignationByShortName(shortNme);
        }

        public bool IsDesignationNameExist(string name)
        {
            bool isName = false;
            var designation = GetDesignationByName(name);
            if (designation != null)
            {
                isName = true;
            }
            return isName;
        }

        private Designation GetDesignationByName(string name)
        {
            return _designationGetway.GetDesignationByName(name);
        }

        public IEnumerable<Designation> FindById(int id)
        {
            return _designationGetway.Find(id);
        }

        public Designation SingleDesignation(int id)
        {
            return _designationGetway.SingleDesignation(id);
        }

        public IEnumerable<Designation> DesignationWithDepartment()
        {
            return _designationGetway.DesignationWithDepartment();
        }

        public int Update(Designation entity)
        {
            return _designationGetway.Update(entity);
        }

        public int Remove(Designation entity)
        {
            return _designationGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Designation> entities)
        {
            return _designationGetway.RemoveRange(entities);
        }
    }
}
