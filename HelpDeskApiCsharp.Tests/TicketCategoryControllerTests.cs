using Xunit;
using Moq;
using HelpDesk.TicketCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace HelpDeskApiCsharp.Tests
{
    public class TicketCategoryControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithAListOfCategories()
        {
            // Arrange
            var mockService = new Mock<ITicketCategoryService>();
            mockService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<TicketCategoryDTO>());
            var controller = new TicketCategoryController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketCategoryDTO>>(okResult.Value);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithCategory()
        {
            // Arrange
            var mockService = new Mock<ITicketCategoryService>();
            mockService.Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync(new TicketCategoryDTO { Id = 1 });
            var controller = new TicketCategoryController(mockService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TicketCategoryDTO>(okResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult_WithCreatedCategory()
        {
            // Arrange
            var categoryDto = new TicketCategoryCreateUpdateDTO();
            var createdCategory = new TicketCategoryDTO { Id = 1 };
            var mockService = new Mock<ITicketCategoryService>();
            mockService.Setup(service => service.CreateAsync(categoryDto))
                .ReturnsAsync(createdCategory);
            var controller = new TicketCategoryController(mockService.Object);

            // Act
            var result = await controller.Create(categoryDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsType<TicketCategoryDTO>(createdAtActionResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedCategory()
        {
            // Arrange
            var categoryDto = new TicketCategoryCreateUpdateDTO();
            var updatedCategory = new TicketCategoryDTO { Id = 1 };
            var mockService = new Mock<ITicketCategoryService>();
            mockService.Setup(service => service.UpdateAsync(1, categoryDto))
                .ReturnsAsync(updatedCategory);
            var controller = new TicketCategoryController(mockService.Object);

            // Act
            var result = await controller.Update(1, categoryDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TicketCategoryDTO>(okResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<ITicketCategoryService>();
            mockService.Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(true);
            var controller = new TicketCategoryController(mockService.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
