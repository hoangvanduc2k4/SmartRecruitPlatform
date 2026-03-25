using System;

namespace SmartRecruit.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("Bạn không có quyền thực hiện hành động này.") { }
        public UnauthorizedException(string message) : base(message) { }
    }
}
