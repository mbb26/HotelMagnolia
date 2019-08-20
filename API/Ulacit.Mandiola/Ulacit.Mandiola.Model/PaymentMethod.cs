using System;

namespace Ulacit.Mandiola.Model
{
    public class PaymentMethod
    {
        public int ID { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string Cvv { get; set; }

        public string Email { get; set; }
    }
}