using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneOperator.Domain.Interfaces;

namespace PhoneOperator.Web.Controllers
{
    [Route("api/operator")]
    public class PhoneOperatorController : Controller
    {
        private readonly IPhoneOperatorService _phoneOperatorService;

        public PhoneOperatorController(IPhoneOperatorService phoneOperatorService)
        {
            _phoneOperatorService = phoneOperatorService;
        }

        [HttpGet("")]
        public IActionResult GetAllPhoneOperators()
        {
            var phoneOperators = _phoneOperatorService.GetAllPhoneOperators();

            return Ok(phoneOperators);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoneOperatorById(int id)
        {
            var phoneOperator = _phoneOperatorService.GetOperatorById(id);

            return Ok(phoneOperator);
        }
    }
}