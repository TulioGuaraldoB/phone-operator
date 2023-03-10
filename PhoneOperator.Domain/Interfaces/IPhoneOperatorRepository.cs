using System.Collections.Generic;
using PhoneOperator.Domain.Models;

namespace PhoneOperator.Domain.Interfaces
{
    public interface IPhoneOperatorRepository
    {
        List<Operator> GetAllOperators();
        Operator GetOperatorById(int operatorId);
        void InsertOperator(Operator phoneOperator);
        void DeleteOperator(int operatorId);
    }
}