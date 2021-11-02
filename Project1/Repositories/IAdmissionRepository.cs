using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Repositories
{
    public interface IAdmissionRepository
    {
        Task<IEnumerable<Admission>> ListAsync();
        IEnumerable<Admission> GetAdmissionsDetails();
        IEnumerable<Admission> GetAdmissionsSearch(string start, string end);
        Task<Admission> GetAdmissionById(int id);
        Task<Admission> GetAdmissionDetailsById(int id);
        Task UpdateAdmission(Admission admission);
        Task<Admission> CreateAdmission(Admission admission);
        Task DeleteAdmission(int id);
    }
}
