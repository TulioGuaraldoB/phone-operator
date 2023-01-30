using System.Collections.Generic;
using PhoneOperator.Infra.Context;
using PhoneOperator.Domain.Interfaces;
using PhoneOperator.Domain.Models;
using System.Linq;
using System;

namespace PhoneOperator.Infra.Repositories
{
    public class PhoneOperatorRepository : IPhoneOperatorRepository
    {
        private readonly DatabaseContext _context;

        public PhoneOperatorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Operator> GetAllOperators()
        {
            return _context.Operators.ToList();
        }

        public Operator GetOperatorById(int operatorId)
        {
            return _context.Operators.Find(operatorId);
        }

        public void InsertOperator(Operator phoneOperator)
        {
            try
            {
                if (_context.Operators.Any(o => o.OperatorCode == phoneOperator.OperatorCode))
                    throw new Exception($"Operator: {phoneOperator.OperatorCode} already exists");

                _context.Operators.Add(phoneOperator);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to insert product. {(ex ?? ex.InnerException).Message}");
            }
        }
    }
}