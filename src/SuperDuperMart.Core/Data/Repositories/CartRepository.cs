using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SuperDuperMartDbContext _context;

        public CartRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetAsync()
        {
            var carts = await _context.Carts.ToListAsync();
            return carts;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId)
        {
            var cartItems = Enumerable.Empty<CartItem>();

            cartItems = await _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .Include(ci => ci.Product)
                .ToListAsync();

            return cartItems;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cart;
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return cart;
        }

        public async Task<Result> AddItemAsync(int cartId, int productId)
        {
            Cart? cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart is null)
            {
                return Result.Failure([$"Cart with id: {cartId} does not exist"]);
            }

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product is null)
            {
                return Result.Failure([$"Product with id: {productId} does not exist"]);
            }

            CartItem? cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.ProductId == product.Id);
            if (cartItem is null)
            {
                await _context.CartItems.AddAsync(new CartItem
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
                _context.CartItems.Update(cartItem);
            }

            await _context.SaveChangesAsync();

            var items = await _context.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.CartId == cart.Id)
                .ToListAsync();

            cart.TotalCost = items.Sum(x => x.Product.Price * x.Quantity);
            cart.LastModified = DateTime.Now;

            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Cart> CreateAsync(Cart entity)
        {
            var entry = await _context.Carts.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Cart entity)
        {
            entity.LastModified = DateTime.Now;
            _context.Carts.Update(entity);
        }

        public void Delete(Cart entity) => _context.Carts.Remove(entity);
    }
}
