using GeekShopping.Email.Messages;

namespace GeekShopping.Email.Repositories
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
