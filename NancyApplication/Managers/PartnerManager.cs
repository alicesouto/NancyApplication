using GatewayApiClient;
using System;
using UmRioCheckoutNancy.Mapper;
using UmRioCheckoutNancy.Models;
using UmRioCheckoutNancy.Utilities;

namespace UmRioCheckoutNancy.Manager
{
    public class PartnerManager
    {
        public CheckoutResult VerifyPartner(Partner partner)
        {
            var result = new CheckoutResult();
            var checkoutMapper = new CheckoutMapper();
            var configurationUtility = new ConfigurationUtility();

            // MerchantKey
            Guid merchantKey = configurationUtility.MundiPaggMerchantKey;
            if (merchantKey == null)
            {
                result.Message = Resources.Resources.InvalidMerchantKey;
                result.Valid = false;

                return result;
            }

            // Cria o client que enviará a transação.
            var serviceClient = new GatewayServiceClient(merchantKey, configurationUtility.MundiPaggApiUrl);

            try
            {
                // Autoriza a transação e recebe a resposta do gateway.
                var httpResponse = serviceClient.Sale.Create(checkoutMapper.MapSaleRequest(partner));

                if (httpResponse.Response.CreditCardTransactionResultCollection != null)
                {
                    result.Valid = true;
                    return result;
                }
                else
                {
                    for (var i = 0; i < httpResponse.Response.ErrorReport.ErrorItemCollection.Count; i++)
                    {
                        result.Message += httpResponse.Response.ErrorReport.ErrorItemCollection[i].Description + ' ';
                    }

                    result.Valid = false;
                    return result;
                }
            }
            catch (Exception ex)
            {
                #region Exception Log

                #endregion

                result.Message = @Resources.Resources.ExceptionError;
                result.Valid = false;
            }

            return result;
        }
    }
}
}