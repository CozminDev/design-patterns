using System;

namespace template
{
    //this is a modern implementation of Template Method Pattern using SOLID principles in mind instead of abstract classes
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            CartValidator cartValidator = new CartValidator();
            EmailSender emailSender = new EmailSender();
            SmsSender smsSender = new SmsSender();

            Cart cart1 = new Cart(paymentProcessor, cartValidator, emailSender);
            cart1.Checkout();

            Cart cart2 = new Cart(paymentProcessor, cartValidator, smsSender);
            cart2.Checkout();
        }
    }

    public class Cart
    {
        private readonly IPaymentProcessor paymentProcessor;
        private readonly ICartValidator validator;
        private readonly INotificationSender notificationSender;

        public Cart(IPaymentProcessor paymentProcessor, ICartValidator validator, INotificationSender notificationSender)
        {
            this.paymentProcessor = paymentProcessor;
            this.validator = validator;
            this.notificationSender = notificationSender;
        }

        public void Checkout()
        {
            validator.Validate();
            paymentProcessor.ProcessPayment();
            notificationSender.Send();
        }
    }

    public interface INotificationSender
    {
        void Send();
    }

    public interface ICartValidator
    {
        void Validate();
    }

    public interface IPaymentProcessor
    {
        void ProcessPayment();
    }

    public class EmailSender : INotificationSender
    {
        public void Send()
        {
            Console.WriteLine("Email has been sent");
        }
    }

    public class SmsSender : INotificationSender
    {
        public void Send()
        {
            Console.WriteLine("SMS has been sent");
        }
    }

    public class CartValidator : ICartValidator
    {
        public void Validate()
        {
            Console.WriteLine("Cart has been validated");
        }
    }

    public class PaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Payment has been processed");
        }
    }
}
