using System.ComponentModel;

namespace Levara.Domain.Enum
{
    public enum PaymentMethod
    {
        [Description("Cash")]
        Cash = 1,

        [Description("BankTransfer")]
        BankTransfer,

        //[Description("CreditCard")]
        //CreditCard,

        //[Description("DebitCard")]
        //DebitCard,

        //[Description("Check")]
        //Check
    }
}
