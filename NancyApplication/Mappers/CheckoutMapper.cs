using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using System;
using System.Collections.ObjectModel;
using UmRioCheckoutNancy.Models;
using UmRioCheckoutNancy.Utilities;

namespace UmRioCheckoutNancy.Mapper
{
    public class CheckoutMapper
    {
        public struct ExpiryDateStruct
        {
            public string Month { get; set; }

            public string Year { get; set; }
        };

        public CreateSaleRequest MapSaleRequest(Partner partner)
        {
            var buyer = new Buyer();
            var transaction = new CreditCardTransaction();
            var createSaleRequest = new CreateSaleRequest();

            buyer.Email = partner.Email;
            buyer.Name = partner.Name;

            ExpiryDateStruct expiryDate = new ExpiryDateStruct();
            expiryDate.Month = partner.CreditCard.ExpiryDate.Substring(0, 2); // MONTH_LENTH = 2
            expiryDate.Year = partner.CreditCard.ExpiryDate.Substring(2 + 3); // MONTH_LENTH+1 + space + /

            var computedBrand = CreditCardUtility.GetBrandByNumber(partner.CreditCard.Number);

            // Cria a transação
            transaction.AmountInCents = partner.Plan;
            transaction.CreditCard = new GatewayApiClient.DataContracts.CreditCard();
            transaction.CreditCard.CreditCardBrand = computedBrand;
            transaction.CreditCard.CreditCardNumber = partner.CreditCard.Number;
            transaction.CreditCard.ExpMonth = Convert.ToInt16(expiryDate.Month);
            transaction.CreditCard.ExpYear = Convert.ToInt16(expiryDate.Year);
            transaction.CreditCard.HolderName = partner.Name;
            transaction.CreditCard.SecurityCode = partner.CreditCard.Cvv;
            transaction.InstallmentCount = 1;
            transaction.Recurrency = new Recurrency()
            {
                DateToStartBilling = DateTime.Now,
                Frequency = FrequencyEnum.Monthly,
                Interval = 1,
                Recurrences = 0
            };

            // Adiciona a transação na requisição.
            createSaleRequest.CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction });
            createSaleRequest.Order = new Order();
            createSaleRequest.Order.OrderReference = "NumeroDoPedido";

            return createSaleRequest;
        }
    }
}