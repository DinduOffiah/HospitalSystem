﻿using RegisterService.Models;

namespace RegisterService.Interface
{
    public interface IPatientService
    {
        Task<Patient> RegisterPatientAsync(Patient patient);
        Task<Patient> GetPatientAsync(Guid id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }

}
