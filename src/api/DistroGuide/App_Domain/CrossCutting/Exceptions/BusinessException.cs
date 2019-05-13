using System;

namespace DistroGuide.App_Domain.CrossCutting.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}