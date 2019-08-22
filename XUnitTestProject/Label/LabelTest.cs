// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelTest.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Mahesh Aurad"/>
// --------------------------------------------------------------------------------------------------------------------
namespace XUnitTestProject.Label
{
    using BusinessManager.Service;
    using CommanLayer.Model;
    using Moq;
    using RepositoryManager.Interface;
    using Xunit;

    public class LabelTest
    {
        [Fact]
        public void Test()
        {
            var Label = new Mock<ILabelRepositoryManager>();
            var LabelData = new LabelBusinessService(Label.Object);

            var data = new LabelModel()
            {
                NoteId = 1,
                UserId = "UserID",
                Lebel = "Lebel"
            };

            //Act
            var Data = LabelData.AddLabel(data);

            //Asert
            Assert.NotNull(Data);
        }
    }
}
