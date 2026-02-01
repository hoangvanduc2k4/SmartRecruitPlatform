using SmartRecruit.Domain.Constants;

namespace SmartRecruit.Domain.Exceptions
{
    public class InsufficientFundException : Exception
    {
        public InsufficientFundException()
            : base(Messages.WalletMsg.INSUFFICIENT_BALANCE) { }
    }
}