using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmWebAPI.AppDatabase;
using FarmWebAPI.Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Data;
using FarmWebAPI.Models;
using Azure.Core;
using FarmWebAPI.Domain.Common;
using System.Net;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using FarmWebAPI.Models.Users;
using ResetPasswordRequest = FarmWebAPI.Models.Users.ResetPasswordRequest;

namespace FarmWebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;


        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
			_userManager = userManager;
			_roleManager = roleManager;

		}

		// GET: api/ApplicationUsers
		[HttpGet]
        public async Task<ActionResult<PagedUserResponse>> GetUsers( 
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 10,
			[FromQuery] string? search = null,
			[FromQuery] int? companyId = null){

			var query = _userManager.Users.Where(u => u.DeletedOn == null);
			if (companyId.HasValue)
			{
				query = query.Where(u => u.CompanyId == companyId.Value);
			}
			if (!string.IsNullOrEmpty(search))
				query = query.Where(u=> u.FirstName!.Contains(search)||
				u.LastName!.Contains(search)|| u.Email!.Contains(search)|| u.UserName!.Contains(search));

				var totalCount = await query.CountAsync();
				var users = await query
					.OrderBy(u=> u.FirstName)
					.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.ToListAsync();

				var userResponses = new List<UserResponse>();
				foreach (var user in users)
				{
					var roles = await _userManager.GetRolesAsync(user);
					userResponses.Add(MapToResponse(user, [.. roles]));
				}
				return Ok(new PagedUserResponse
				{
					Users = userResponses,
					TotalCount = totalCount,
					Page = page,
					PageSize = pageSize
				});
			

        }

        // GET: api/ApplicationUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null || user.DeletedOn != null)
			{
				return NotFound(new {message = $"User with ID `{id}` was not found."});
			}
			var roles = await _userManager.GetRolesAsync(user);


			return Ok(MapToResponse(user, [.. roles]));
        }

		// POST: api/ApplicationUsers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<UserResponse>> CreateUser([FromBody]CreateUserRequest request)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var existingUser = await _userManager.FindByEmailAsync(request.Email);
			if (existingUser is not null) { 
			     return Conflict(new {message = $"A user with email `{request.Email}` already exists."});
			}
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				PhoneNumber = request.PhoneNumber,
				Gender = request.Gender,
				DateOfBirth = request.DateOfBirth,
				Address = request.Address,
				Country = request.Country,
				NationalId = request.NationalId,
				PassportNumber = request.PassportNumber,
				CompanyId = request.CompanyId,
				CreatedOn = DateTime.UtcNow,
				EmailConfirmed = true
			};

			var createResult = await _userManager.CreateAsync(user, request.Password);
			if(!createResult.Succeeded)
			{
				return BadRequest(new {errors = createResult.Errors.Select(e => e.Description)});
			}
			if(request.Roles.Count > 0)
			{
				foreach (var role in request.Roles)
				{
					if(!await _roleManager.RoleExistsAsync(role))  return BadRequest(new { message = $"Role `{role}` does not exist"});
				}
				
				var rolesResult = await _userManager.AddToRolesAsync(user, request.Roles);
				if (!rolesResult.Succeeded)
				{
					return BadRequest(new { errors = rolesResult.Errors.Select(e => e.Description) });
				}
			}
			var assignedRoles = await _userManager.GetRolesAsync(user);
			return CreatedAtAction(nameof(GetUser), new {id = user.Id}, MapToResponse(user, [.. assignedRoles]));
		}
		
		[HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequest request)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}
			    user.FirstName = request.FirstName;
			    user.LastName = request.LastName;
				user.Email = request.Email;
				user.UserName = request.UserName;
				user.PhoneNumber = request.PhoneNumber;
				user.Gender = request.Gender;
				user.DateOfBirth = request.DateOfBirth;
				user.Address = request.Address;
				user.Country = request.Country;
				user.NationalId = request.NationalId;
				user.PassportNumber = request.PassportNumber;
				user.ModifiedOn = DateTime.UtcNow;

			var updateResult = await _userManager.UpdateAsync(user);
			if(!updateResult.Succeeded)
				return BadRequest(new { errors = updateResult.Errors.Select(e => e.Description) });

			var roles = await _userManager.GetRolesAsync(user);
			return Ok(MapToResponse(user, [.. roles]));
		}

        

        // DELETE: api/ApplicationUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}

			user.DeletedOn = DateTime.UtcNow;
			user.LockoutEnabled = true;
			user.LockoutEnd = DateTimeOffset.MaxValue;

			var result = await _userManager.DeleteAsync(user);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });

			return NoContent();
        }
		[HttpPut("{id}/change-password")]
		public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}
			var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });

			return Ok(new { message = $"Password changed successfully." });
		}
		[HttpPut("{id}/reset-password")]
		public async Task<IActionResult> ResetPassword(string id, [FromBody] ResetPasswordRequest request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}
			var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
			var result = await _userManager.ResetPasswordAsync(user, resetToken, request.NewPassword);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });

			return Ok(new { message = $"Password reset successfully." });
		}
		[HttpPut("{id}/activate")]
		public async Task<IActionResult> ActivateUser(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}

			user.LockoutEnd = null;
			user.LockoutEnabled = false;
			user.ModifiedOn = DateTime.UtcNow;

			var result = await _userManager.UpdateAsync(user);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
			return Ok(new { message = $"User activated successfully." });
		}
		[HttpPut("{id}/deactivate")]
		public async Task<IActionResult> DeactivateUser(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}

			user.LockoutEnd = DateTimeOffset.MaxValue;
			user.LockoutEnabled = true;
			user.ModifiedOn = DateTime.UtcNow;

			var result = await _userManager.UpdateAsync(user);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });

			return Ok(new { message = $"User deactivated successfully." });
		}

		[HttpPut("{id}/unlock")]
		public async Task<IActionResult> UnlockUser(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}

			var result = await _userManager.SetLockoutEndDateAsync(user,null);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });

			await _userManager.ResetAccessFailedCountAsync(user);

			return Ok(new { message = $"User unlocked successfully." });
		}
		[HttpGet("{id}/roles")]
		public async Task<ActionResult<IList<string>>> GetUserRoles(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}

			var roles = await _userManager.GetRolesAsync(user);

			return Ok(roles);
		}

		[HttpPost("{id}/roles")]
		public async Task<IActionResult> AssignRole(string id, [FromBody] AssignRoleRequest request)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}
			if(!await _roleManager.RoleExistsAsync(request.RoleName)) 
				return BadRequest(new { message = $"Role `{request.RoleName}` does not exist" });
			if(await _userManager.IsInRoleAsync(user,request.RoleName))
				return Conflict(new { message = $"User is already assigned to role `{request.RoleName}`." });

			var result = await _userManager.AddToRoleAsync(user, request.RoleName);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });


			return Ok(new { message = $"Role '{request.RoleName}` assigned successfully." });
		}

		[HttpDelete("{id}/roles/{roleName}")]
		public async Task<IActionResult> RemoveRole(string id, string roleName)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null || user.DeletedOn != null)
			{
				return NotFound(new { message = $"User with ID `{id}` was not found." });
			}
		
			if (await _userManager.IsInRoleAsync(user, roleName))
				return BadRequest(new { message = $"User is not assigned to role `{roleName}`." });

			var result = await _userManager.RemoveFromRoleAsync(user, roleName);
			if (!result.Succeeded)
				return BadRequest(new { errors = result.Errors.Select(e => e.Description) });


			return Ok(new { message = $"Role '{roleName}` removed successfully." });
		}

		private static UserResponse MapToResponse(ApplicationUser user, List<string> roles) => new()
		{

			Id = user.Id,
			FirstName = user.FirstName ?? string.Empty,
			LastName = user.LastName ?? string.Empty,
			FullName = user.FullName,
			UserName = user.UserName ?? string.Empty,
			Email = user.Email ?? string.Empty,
			PhoneNumber = user.PhoneNumber ?? string.Empty,
			Gender = user.Gender,
			DateOfBirth = user.DateOfBirth,
			Address = user.Address,
			Country = user.Country,
			NationalId = user.NationalId,
			PassportNumber = user.PassportNumber,
			CompanyId = user.CompanyId,
			EmailConfirmed = user.EmailConfirmed,
			LockoutEnabled = user.LockoutEnabled,
			LockoutEnd = user.LockoutEnd,
			Roles = roles,
			CreatedOn = user.CreatedOn,
			ModifiedOn = user.ModifiedOn,
		};

	}

}
