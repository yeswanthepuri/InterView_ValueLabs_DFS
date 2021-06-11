using System;
using Xunit;
using EntryRepresents.lib.Repositories;
using EntryRepresents.lib.Model.Response;
using EntryRepresents.lib.Repositories.Interface;
using EntryRepresents.lib.Model.Request;

namespace EntryRepresents.Test
{
    public class GroupMyPatientsTest
    {
        private readonly IGroupMyPatients<int> groupMyPatients;
        PatientGroup<int> patientGroup = new PatientGroup<int>();

        public GroupMyPatientsTest()
        {
            groupMyPatients = new GroupMyPatients();
            patientGroup.Matrix = new int[6][];
            patientGroup.Matrix[0] = new int[] { 1, 1, 0, 0, 0, 0 };
            patientGroup.Matrix[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            patientGroup.Matrix[2] = new int[] { 1, 0, 1, 0, 0, 0 };
            patientGroup.Matrix[3] = new int[] { 0, 0, 0, 0, 1, 0 };
            patientGroup.Matrix[4] = new int[] { 0, 0, 0, 0, 0, 1 };
            patientGroup.Matrix[5] = new int[] { 1, 1, 0, 1, 0, 0 };
        }
        
        [Fact]
        public void Repo_GroupMyPatients_int_Test_Happy()
        {
            //Arrange
            var returnvalue = new PatientsCount(4);
            //Act
            var result = groupMyPatients.GroupedCount(patientGroup);
            //Assert
            Assert.Equal(returnvalue.TotalGroups, result);
        }
        [Fact]
        public void Repo_GroupMyPatients_int_Test_UnHappy()
        {
            //Arrange
            var returnvalue = new PatientsCount(5);
            //Act
            var result = groupMyPatients.GroupedCount(patientGroup);
            //Assert
            Assert.NotEqual(returnvalue.TotalGroups, result);
        }
        [Fact]
        public void Repo_GroupMyPatients_int_Test_empty()
        {
            //Arrange
            var returnvalue = new PatientsCount(0);
            patientGroup.Matrix = new int[0][];
            //Act
            var result = groupMyPatients.GroupedCount(patientGroup);
            //Assert
            Assert.Equal(returnvalue.TotalGroups, result);
        }
    }
}
