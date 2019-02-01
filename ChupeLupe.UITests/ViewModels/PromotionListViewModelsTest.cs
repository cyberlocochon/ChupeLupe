using System;
using NUnit.Framework;
using AutoFixture;
using ChupeLupe.UITests.Helpers;
using Moq;
using ChupeLupe.Services;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using ChupeLupe.ViewModels;
using System.Collections.Generic;
using ChupeLupe.Models;

namespace ChupeLupe.UITests.ViewModels
{
    [TestFixture]
    public class PromotionListViewModelsTest
    {
        Fixture Fixture { get; set; }
        DependencyServiceshub DependencyService { get; set; }
        Mock<IWebServicesApi> ServerSideDataMock { get; set; }
        Mock<INavigation> NavigationMock { get; set; }

        [SetUp]
        public void SetUp()
        {
            MockForms.Init();

            Fixture = new Fixture();
            DependencyService = new DependencyServiceshub();

            ServerSideDataMock = new Mock<IWebServicesApi>();
            DependencyService.Register<IWebServicesApi>(ServerSideDataMock.Object);

            NavigationMock = new Mock<INavigation>();
            DependencyService.Register<INavigation>(NavigationMock.Object);
        }

        [Test]
        public void GetPromotionsCommandIsSuccesful()
        {
            // Arrange
            var vm = new PromotionListViewModel(NavigationMock.Object, DependencyService);
            List<Promotion> list = new List<Promotion>
            {
                new Promotion
                {
                    Id = Fixture.Create<int>(),
                    Title = Fixture.Create<string>()

                }
            };
            ServerSideDataMock.Setup(m => m.GetPromotions()).ReturnsAsync(list);

            //Act
            vm.GetPromotionsCommand.Execute(null);

            //Assert
            ServerSideDataMock.Verify(m => m.GetPromotions(), Times.Once());
            Assert.IsNotNull(vm.PromotionList);
            Assert.AreEqual(1, vm.PromotionList.Count);
            Assert.IsFalse(vm.IsBusy);

        }

    }
    }

