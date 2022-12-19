using System.Collections.Generic;
using PhoneOperator.Infra.Context;
using PhoneOperator.Domain.Interfaces;
using PhoneOperator.Domain.Models;
using System.Linq;

namespace PhoneOperator.Infra.Repositories
{
    public class PhoneOperatorRepository : IPhoneOperatorRepository
    {
        private readonly DatabaseContext _context;

        public PhoneOperatorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<Operator> GetAllOperators()
        {
            return _context.Operators.AsQueryable();
        }

        public Operator GetOperatorById(int operatorId)
        {
            return _context.Operators.Find(operatorId);
        }
    }
}