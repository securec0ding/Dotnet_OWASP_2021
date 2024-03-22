using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InsecureCouponAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {
        private static Dictionary<string, double> _couponCodes = new Dictionary<string, double>();

        [HttpPost("add")]
        public IActionResult AddCoupon([FromBody] CouponRequest request)
        {
            _couponCodes[request.Code] = request.Discount;
            return Ok($"Coupon code '{request.Code}' with discount '{request.Discount}' added successfully.");
        }

        [HttpGet("apply")]
        public IActionResult ApplyCoupon([FromQuery] string code, [FromQuery] double total)
        {
            if (_couponCodes.ContainsKey(code))
            {
                var discount = _couponCodes[code];
                var discountedTotal = total * (1 - discount);
                return Ok($"Discounted total after applying coupon '{code}': {discountedTotal}");
            }
            else
            {
                return NotFound("Coupon code not found.");
            }
        }
    }

    public class CouponRequest
    {
        public string Code { get; set; }
        public double Discount { get; set; }
    }
}
