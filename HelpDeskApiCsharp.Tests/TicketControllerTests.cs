using Xunit;
using Moq;
using HelpDesk.Ticket;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpDesk.User;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace HelpDeskApiCsharp.Tests
{
    public class TicketControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithAListOfTickets()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.GetAllAsync(1, 10, null, null, null, null, null))
                .ReturnsAsync(new List<TicketDTO>());
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketDTO>>(okResult.Value);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithTicket()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.GetByIdAsync(1))
                .ReturnsAsync(new TicketDTO { Id = 1 });
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TicketDTO>(okResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult_WithCreatedTicket()
        {
            // Arrange
            var ticketCreateDto = new TicketCreateDTO();
            var createdTicket = new TicketDTO { Id = 1 };
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.CreateAsync(ticketCreateDto))
                .ReturnsAsync(createdTicket);
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.Create(ticketCreateDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsType<TicketDTO>(createdAtActionResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedTicket()
        {
            // Arrange
            var ticketUpdateDto = new TicketUpdateDTO();
            var updatedTicket = new TicketDTO { Id = 1 };
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.UpdateAsync(1, ticketUpdateDto))
                .ReturnsAsync(updatedTicket);
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.Update(1, ticketUpdateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TicketDTO>(okResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(true);
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetTicketsForUser_ReturnsOkResult_WithAListOfTickets()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.GetAllAsync(1, 100, null, 1, null, null, null))
                .ReturnsAsync(new List<TicketDTO>());
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.GetTicketsForUser(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketDTO>>(okResult.Value);
        }

        [Fact]
        public async Task GetTicketsByStatus_ReturnsOkResult_WithAListOfTickets()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.GetAllAsync(1, 100, "open", null, null, null, null))
                .ReturnsAsync(new List<TicketDTO>());
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.GetTicketsByStatus("open");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketDTO>>(okResult.Value);
        }

        [Fact]
        public async Task GetTicketsByCategory_ReturnsOkResult_WithAListOfTickets()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.GetAllAsync(1, 100, null, null, 1, null, null))
                .ReturnsAsync(new List<TicketDTO>());
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.GetTicketsByCategory(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketDTO>>(okResult.Value);
        }

        [Fact]
        public async Task GetTicketsByPriority_ReturnsOkResult_WithAListOfTickets()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(service => service.GetAllAsync(1, 100, null, null, null, 1, null))
                .ReturnsAsync(new List<TicketDTO>());
            var controller = new TicketController(mockService.Object);

            // Act
            var result = await controller.GetTicketsByPriority(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketDTO>>(okResult.Value);
        }
    }
}
