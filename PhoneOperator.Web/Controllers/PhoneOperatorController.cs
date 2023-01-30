using System;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneOperator.Domain.Models;
using PhoneOperator.Domain.Interfaces;
using PhoneOperator.Web.Dtos;

namespace PhoneOperator.Web.Controllers
{
    [ApiController]
    [Route("api/v1/operator")]
    public class PhoneOperatorController : Controller
    {
        private readonly IPhoneOperatorService _phoneOperatorService;

        public PhoneOperatorController(IPhoneOperatorService phoneOperatorService)
        {
            _phoneOperatorService = phoneOperatorService;
        }

        [HttpGet]
        public IActionResult GetAllPhoneOperators()
        {
            var phoneOperators = _phoneOperatorService.GetAllPhoneOperators();
            var phoneOperatorsRes = phoneOperators.Select(phoneOperatorRes => new PhoneOperatorResponse
            {
                Id = phoneOperatorRes.Id,
                Name = phoneOperatorRes.Name,
                OperatorCode = phoneOperatorRes.OperatorCode,
                CreatedAt = phoneOperatorRes.CreatedAt,
                UpdatedAt = phoneOperatorRes.UpdatedAt,
            });

            return Ok(phoneOperatorsRes);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoneOperatorById(int id)
        {
            var phoneOperator = _phoneOperatorService.GetOperatorById(id);
            var phoneOperatorRes = new PhoneOperatorResponse
            {
                Id = phoneOperator.Id,
                Name = phoneOperator.Name,
                OperatorCode = phoneOperator.OperatorCode,
                CreatedAt = phoneOperator.CreatedAt,
                UpdatedAt = phoneOperator.UpdatedAt,
            };

            return Ok(phoneOperatorRes);
        }

        [HttpPost]
        public IActionResult CreatePhoneOperator(PhoneOperatorRequest phoneOperatorReq)
        {
            try
            {
                var phoneOperator = new Operator()
                {
                    Name = phoneOperatorReq.Name,
                    OperatorCode = phoneOperatorReq.OperatorCode,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                };

                _phoneOperatorService.InsertOperator(phoneOperator);
                return Ok(new
                {
                    message = "phone operator inserted successfully!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = $"Failed to create product. ${(ex ?? ex.InnerException).Message}",
                });
            }
        }
    }
}