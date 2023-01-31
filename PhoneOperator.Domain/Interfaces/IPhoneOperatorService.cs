using System.Collections.Generic;
using PhoneOperator.Domain.Models;

namespace PhoneOperator.Domain.Interfaces
{
    public interface IPhoneOperatorService
    {
        List<Operator> GetAllPhoneOperators();
        Operator GetOperatorById(int phoneOperatorId);
        void InsertOperator(Operator phoneOperator);
        void DeleteOperator(int operatorId);
    }
}