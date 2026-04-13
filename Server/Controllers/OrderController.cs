using BaseLibrary.DTOs.Order;
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderRepositoryInterface<Order> orderRepositoryInterface) : GenericController<Order>(orderRepositoryInterface)
    {
        [HttpGet("getallorders")]
        public async Task<ActionResult<List<GetOrdersDto>>> GetAllOrders()
        {
            var orders = await orderRepositoryInterface.GetAllOrdersAsync();

            if (orders == null || orders.Count == 0)
                return NotFound("Жодного замовлення не знайдено.");

            return Ok(orders);
        }


        [HttpPost("save")]
        public async Task<IActionResult> SaveOrder([FromBody] SaveOrderDto saveOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors));
            }

            try
            {
                var orderId = await orderRepositoryInterface.SaveOrderAsync(saveOrderDto);

                return Ok(new { OrderId = orderId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, $"Помилка при збереженні замовлення: {ex.Message}");
            }
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusDto dto)
        {
            var success = await orderRepositoryInterface.UpdateStatusAsync(dto);
            if (!success) return NotFound("Замовлення не знайдено.");

            return Ok(new { success = true });
        }
    }
}
