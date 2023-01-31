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
            var operators = _context.Operators
            .Where(o => o.DeletedAt == null);

            return operators.ToList();
        }

        public Operator GetOperatorById(int operatorId)
        {
            try
            {
                var phoneOperator = _context.Operators.
                Where(o => o.Id == operatorId).
                Where(o => o.DeletedAt == null).
                First();

                return phoneOperator;
            }
            catch
            {
                throw new Exception("Operator not found.");
            }
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
                throw new Exception($"Failed to insert operator. {(ex ?? ex.InnerException).Message}");
            }
        }

        public void DeleteOperator(int operatorId)
        {
            try
            {
                var phoneOperator = _context.Operators.
                Where(o => o.Id == operatorId).First();
                phoneOperator.DeletedAt = DateTime.Now;

                _context.Operators.Update(phoneOperator);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete operator. {(ex ?? ex.InnerException).Message}");
            }
        }
    }
}