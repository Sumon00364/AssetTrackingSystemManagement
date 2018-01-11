using System.Collections.Generic;
using Asset.Models.Library.EntityModels.OrganizationModels;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.Organizations
{
    public interface IDesignationRepository : IRepository<Designation>
    {
        Designation GetDesignationByName(string name);
        Designation GetDesignationByShortName(string shortNme);
        IEnumerable<Designation> DesignationWithDepartment();   
    }
}
