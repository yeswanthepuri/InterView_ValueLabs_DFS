using System;
using EntryRepresents.lib.Model.Request;

namespace EntryRepresents.lib.Repositories.Interface
{
    public interface IGroupMyPatients<T>
    {
        int GroupedCount(PatientGroup<T> patientGroup);
    }
}
