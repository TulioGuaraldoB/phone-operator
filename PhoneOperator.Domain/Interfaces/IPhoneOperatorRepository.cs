using System.Linq;
using PhoneOperator.Domain.Models;

namespace PhoneOperator.Domain.Interfaces
{
    public interface IPhoneOperatorRepository
    {
        IQueryable<Operator> GetAllOperators();
        Operator GetOperatorById(int operatorId);
    }
}