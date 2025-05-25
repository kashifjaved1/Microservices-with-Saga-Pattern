namespace StockService.Exceptions
{
    public class InvalidPaymentCardException : Exception
    {
        public InvalidPaymentCardException() : base("Invalid card!")
        {
            
        }
    }
}
