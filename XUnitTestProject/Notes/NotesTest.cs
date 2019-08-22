// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepositoryManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace XUnitTestProject.Notes
{
    using BusinessManager.Service;
    using CommanLayer.Model;
    using Moq;
    using RepositoryManager.Interface;
    using Xunit;

    /// <summary>
    /// Test the all functionality of NotesModel
    /// </summary>
    public class NotesTest
    {
        /// <summary>
        /// Tests this instance.
        /// </summary>
        [Fact]
        public void TestAddNotes()
        {
            var NotesData = new Mock<INotesRepositoryManager>();
            var addData = new BusinessManagerService(NotesData.Object);

            var data = new NotesModel()
            {
                UserId = " ",
                Title = " ",
                Description = "",
                Color = " ",
                Image = ""
            };

            ////Act 
            var Data = addData.AddNotes(data);

            ////Assert
            Assert.NotNull(Data);
        }

        /// <summary>
        /// Updates the note.
        /// </summary>
        [Fact]
        public void UpdateNote()
        {
            var NotesData = new Mock<INotesRepositoryManager>();
            var addData = new BusinessManagerService(NotesData.Object);

            var data = new NotesModel()
            {
                UserId = " ",
                Title = " ",
                Description = "",
                Color = " ",
                Image = ""
            };

            var Id = 1;
            
            ////Act
            var Data = addData.UpdateNotes(data, Id);

            ////Assert
            Assert.NotNull(Data);
        }


    }
}
