using Xunit;
using Moq;
using HelpDesk.TicketPriority;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDeskApiCsharp.Tests
{
    public class TicketPriorityControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithAListOfPriorities()
        {
            // Arrange
            var mockService = new Mock<ITicketPriorityService>();
            mockService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<TicketPriorityDTO>());
            var controller = new TicketPriorityController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketPriorityDTO>>(okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedPriority()
        {
            // Arrange
            var priorityDto = new TicketPriorityCreateUpdateDTO();
            var updatedPriority = new TicketPriorityDTO { Id = 1 };
            var mockService = new Mock<ITicketPriorityService>();
            mockService.Setup(service => service.UpdateAsync(1, priorityDto))
                .ReturnsAsync(updatedPriority);
            var controller = new TicketPriorityController(mockService.Object);

            // Act
            var result = await controller.Update(1, priorityDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TicketPriorityDTO>(okResult.Value);
            Assert.Equal(1, model.Id);
        }
    }
}
