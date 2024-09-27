using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CartController> _logger;

        public CartController(ApplicationDbContext context, ILogger<CartController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Add to Cart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            _logger.LogInformation("AddToCart called with productId: {ProductId}, quantity: {Quantity}", productId, quantity);

            if (quantity <= 0)
            {
                _logger.LogWarning("Invalid quantity: {Quantity}", quantity);
                return BadRequest("Quantity must be greater than zero.");
            }

            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", productId);
                    return NotFound("Product not found.");
                }

                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    _logger.LogWarning("User is not authenticated.");
                    return Unauthorized("User is not authenticated.");
                }

                var existingCartItem = await _context.Carts
                    .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                    existingCartItem.TotalAmount = existingCartItem.Quantity * product.Price;
                    _context.Carts.Update(existingCartItem);
                }
                else
                {
                    var cart = new Cart
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        TotalAmount = product.Price * quantity,
                        UserId = userId
                    };
                    await _context.Carts.AddAsync(cart);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Product added to cart successfully.");
                return RedirectToAction("ViewCart");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "An error occurred while updating the database.");
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception details.");
                }
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // View Cart
        public async Task<IActionResult> ViewCart()
        {
            try
            {
                var userId = GetUserId();

                var cartItems = await _context.Carts
                    .Include(c => c.Product)
                    .Where(c => c.UserId == userId)
                    .ToListAsync();

                return View(cartItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the cart items.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
