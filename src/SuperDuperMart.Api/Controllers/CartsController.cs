using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Api.Controllers
{
    [HasAccess]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("{cartId}/items/add/{productId}")]
        public async Task<IActionResult> AddItem(int cartId, int productId)
        {
            Cart? cart = await _unitOfWork.CartRepository.GetByIdAsync(cartId);
            if (cart is null)
            {
                return NotFound();
            }

            Product? product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            if (product is null)
            {
                return NotFound();
            }

            var item = new CartItem
            {
                CartId = cart.Id,
                ProductId = productId,
                Quantity = 1
            };

            await _unitOfWork.CartRepository.AddItemAsync(item);
            await _unitOfWork.SaveAsync();

            decimal totalCost = 0;
            var cartItems = await _unitOfWork.CartRepository.GetItemsAsync(cart);
            foreach (var cartItem in cartItems)
            {
                totalCost += cartItem.Product.Price * cartItem.Quantity;
            }

            cart.TotalCost = totalCost;
            _unitOfWork.CartRepository.Update(cart);
            await _unitOfWork.SaveAsync();

            return Ok();
        }

        [HttpDelete("{cartId}/items/delete/{productId}")]
        public async Task<IActionResult> DeleteItem(int cartId, int productId)
        {
            Cart? cart = await _unitOfWork.CartRepository.GetByIdAsync(cartId);
            if (cart is null)
            {
                return NotFound();
            }

            Product? product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            if (product is null)
            {
                return NotFound();
            }

            CartItem? item = await _unitOfWork.CartRepository.GetItemByIdAsync(cart.Id, product.Id);
            if (item is null)
            {
                return NotFound();
            }

            _unitOfWork.CartRepository.DeleteItem(item);
            await _unitOfWork.SaveAsync();

            decimal totalCost = 0;
            var cartItems = await _unitOfWork.CartRepository.GetItemsAsync(cart);
            foreach (var cartItem in cartItems)
            {
                totalCost += cartItem.Product.Price * cartItem.Quantity;
            }

            cart.TotalCost = totalCost;
            _unitOfWork.CartRepository.Update(cart);
            await _unitOfWork.SaveAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carts = await _unitOfWork.CartRepository.GetAsync();

            return Ok(_mapper.Map<IEnumerable<CartModel>>(carts));
        }

        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetItems(int id)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(id);
            if (cart is null)
            {
                return NotFound();
            }

            var cartItems = await _unitOfWork.CartRepository.GetItemsAsync(cart);

            return Ok(_mapper.Map<IEnumerable<CartItemModel>>(cartItems));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(id);
            if (cart is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CartModel>(cart));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var cart = await _unitOfWork.CartRepository.GetByUserIdAsync(userId);
            if (cart is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CartModel>(cart));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartCreateModel model)
        {
            User? user = await _unitOfWork.UserRepository.GetByIdAsync(model.UserId);
            if (user is null)
            {
                return NotFound();
            }

            if (await _unitOfWork.UserRepository.HasCartAsync(user))
            {
                return BadRequest(new { Message = $"Cart already exists on user with id: {model.UserId}" });
            }

            var cart = _mapper.Map<Cart>(model);
            var createdCart = await _unitOfWork.CartRepository.CreateAsync(cart);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { createdCart.Id }, createdCart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CartUpdateModel model)
        {
            Cart? cart = await _unitOfWork.CartRepository.GetByIdAsync(id);
            if (cart is null)
            {
                return NotFound();
            }

            cart = _mapper.Map(source: model, destination: cart);

            _unitOfWork.CartRepository.Update(cart);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Cart? cart = await _unitOfWork.CartRepository.GetByIdAsync(id);
            if (cart is null)
            {
                return NotFound();
            }

            _unitOfWork.CartRepository.Delete(cart);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("user/{userId}")]
        public async Task<IActionResult> DeleteByUserId(int userId)
        {
            Cart? cart = await _unitOfWork.CartRepository.GetByUserIdAsync(userId);
            if (cart is null)
            {
                return NotFound();
            }

            _unitOfWork.CartRepository.Delete(cart);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
