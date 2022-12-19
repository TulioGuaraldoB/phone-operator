using System.Collections.Generic;
using System.Linq;
using PhoneOperator.Domain.Interfaces;
using PhoneOperator.Domain.Models;

namespace PhoneOperator.Domain.Services
{
    public class PhoneOperatorService : IPhoneOperatorService
    {
        private readonly IPhoneOperatorRepository _phoneOperatorRepository;

        public PhoneOperatorService(IPhoneOperatorRepository phoneOperatorRepository)
        {
            _phoneOperatorRepository = phoneOperatorRepository;
        }

        public List<Operator> GetAllPhoneOperators()
        {
            var phoneOperators = _phoneOperatorRepository.GetAllOperators();
            return phoneOperators.ToList();
        }

        public Operator GetOperatorById(int phoneOperatorId)
        {
            return _phoneOperatorRepository.GetOperatorById(phoneOperatorId);
        }
    }
}