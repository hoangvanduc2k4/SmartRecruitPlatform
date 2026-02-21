using AutoMapper;
using SmartRecruit.Application.DTO.Wallet;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, WalletResponse>()
                .ConstructUsing(src => new WalletResponse(
                    src.Id,
                    src.UserId,
                    src.User != null ? src.User.FullName : "Unknown",
                    src.User != null ? src.User.Email : "Unknown",
                    src.Balance,
                    src.Currency,
                    src.CreatedAt
                ));

            CreateMap<Transaction, TransactionResponse>()
                .ConstructUsing(src => new TransactionResponse(
                    src.Id,
                    src.UserId,
                    src.WalletId,
                    src.Amount,
                    src.Type.ToString(),
                    src.Status.ToString(),
                    src.OrderCode,
                    src.Description,
                    src.ReferenceId,
                    src.CreatedAt
                ));
        }
    }
}
