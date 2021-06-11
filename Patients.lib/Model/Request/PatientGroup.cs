using System;
namespace EntryRepresents.lib.Model.Request
{
    public class PatientGroup<T>  
    {
        public PatientGroup()
        {
        }
        //Matrix in form of rectangular or square
        public T[][] Matrix { get; set; }
    }
}
