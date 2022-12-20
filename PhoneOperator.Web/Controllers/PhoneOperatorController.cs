using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneOperator.Domain.Interfaces;
using PhoneOperator.Web.Dtos;

namespace PhoneOperator.Web.Controllers
{
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
            };

            return Ok(phoneOperatorRes);
        }
    }
}