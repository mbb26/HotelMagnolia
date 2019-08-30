using System;

namespace Ulacit.Mandiola.Model
{
    public class PaymentMethod
    {
        public int ID { get; set; }

        public string CardNumber { get; set; }

        public string ExpiredDate { get; set; }

        public string Cvv { get; set; }

        public string Email { get; set; }

        public string Nombre { get; set; }
    }
}