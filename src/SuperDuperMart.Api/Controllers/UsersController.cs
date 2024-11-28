﻿using SuperDuperMart.Shared.DTOs;
using SuperDuperMart.Api.Filters;

namespace SuperDuperMart.Api.Controllers
{
    [HasAccess]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryParams parameters)
        {
            var pagedList = await _unitOfWork.UserRepository.GetAsync(parameters);
            var pagedListDto = _mapper.Map<PagedListDto<UserDto>>(pagedList);

            var userDtos = new List<UserDto>();
            foreach (var user in pagedList.Data)
            {
                var role = await _unitOfWork.UserRepository.GetPrimaryRoleAsync(user);

                var dto = _mapper.Map<UserDto>(user);
                dto.Role = _mapper.Map<RoleDto>(role);

                userDtos.Add(dto);
            }

            pagedListDto.Data = userDtos;

            return Ok(pagedListDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var role = await _unitOfWork.UserRepository.GetPrimaryRoleAsync(user);

            var dto = _mapper.Map<UserDto>(user);
            dto.Role = _mapper.Map<RoleDto>(role);

            return Ok(dto);
        }

        [ConfirmPassword]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _unitOfWork.UserRepository.CreateAsync(user, model.Password);
            return Ok(new 
            { 
                result.Succeeded, 
                result.Errors 
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto model)
        {
            // Get user 
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            // Create new or update existing location
            if (user.Location is null)
            {
                var newLocation = new Location
                {
                    StreetName = model.StreetName,
                    ZipCode = model.ZipCode,
                    City = model.City,
                    UserId = user.Id
                };

                await _unitOfWork.LocationRepository.CreateAsync(newLocation);
            }
            else
            {
                user.Location.StreetName = model.StreetName;
                user.Location.ZipCode = model.ZipCode;
                user.Location.City = model.City;
                
                _unitOfWork.LocationRepository.Update(user.Location);
            }

            // Save location changes to database
            await _unitOfWork.SaveAsync();

            // Update user
            user = _mapper.Map(source: model, destination: user);
            await _unitOfWork.UserRepository.UpdateAsync(user);

            // Get role
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(model.RoleId);
            if (role is null)
            {
                return NotFound();
            }

            // Clear all existing roles and add new
            var result = await _unitOfWork.UserRepository.ClearRolesAsync(user);
            if (result.Succeeded)
            {
                await _unitOfWork.UserRepository.AddToRoleAsync(user, role.Name);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            if (user.Location is not null)
            {
                _unitOfWork.LocationRepository.Delete(user.Location);
            }

            if (user.Cart is not null)
            {
                _unitOfWork.CartRepository.Delete(user.Cart);
            }

            await _unitOfWork.SaveAsync();
            await _unitOfWork.UserRepository.DeleteAsync(user);

            return NoContent();
        }
    }
}
