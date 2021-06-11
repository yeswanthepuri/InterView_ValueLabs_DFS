using System;
namespace EntryRepresents.lib.Model.Response
{
    public class PatientsCount
    {
        public PatientsCount(int count)
        {
            TotalGroups = count;
        }
        public int TotalGroups { get; private set; }
    }
}
