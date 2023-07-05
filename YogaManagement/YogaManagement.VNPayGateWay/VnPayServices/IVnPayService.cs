using Microsoft.AspNetCore.Http;
using YogaManagement.VNPayGateWay.VnPayModels;

namespace YogaManagement.VNPayGateWay.Services;
public interface IVnPayService
{
    string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
    PaymentResponseModel PaymentExecute(IQueryCollection collections);
}