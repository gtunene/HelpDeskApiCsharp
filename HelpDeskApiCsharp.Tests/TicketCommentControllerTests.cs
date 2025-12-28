using Xunit;
using Moq;
using HelpDesk.TicketComment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDeskApiCsharp.Tests
{
    public class TicketCommentControllerTests
    {
        [Fact]
        public async Task GetCommentsForTicket_ReturnsOkResult_WithAListOfComments()
        {
            // Arrange
            var mockService = new Mock<ITicketCommentService>();
            mockService.Setup(service => service.GetCommentsForTicketAsync(1))
                .ReturnsAsync(new List<TicketCommentDTO>());
            var controller = new TicketCommentController(mockService.Object);

            // Act
            var result = await controller.GetCommentsForTicket(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TicketCommentDTO>>(okResult.Value);
        }

        [Fact]
        public async Task CreateCommentForTicket_ReturnsCreatedAtActionResult_WithCreatedComment()
        {
            // Arrange
            var commentDto = new TicketCommentCreateDTO();
            var createdComment = new TicketCommentDTO { Id = 1 };
            var mockService = new Mock<ITicketCommentService>();
            mockService.Setup(service => service.CreateAsync(1, commentDto))
                .ReturnsAsync(createdComment);
            var controller = new TicketCommentController(mockService.Object);

            // Act
            var result = await controller.CreateCommentForTicket(1, commentDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var model = Assert.IsType<TicketCommentDTO>(createdAtActionResult.Value);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task DeleteComment_ReturnsNoContentResult()
        {
            // Arrange
            var mockService = new Mock<ITicketCommentService>();
            mockService.Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(true);
            var controller = new TicketCommentController(mockService.Object);

            // Act
            var result = await controller.DeleteComment(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
