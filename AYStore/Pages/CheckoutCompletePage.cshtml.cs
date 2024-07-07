using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYStore.Pages
{
    public class CheckoutCompletePageModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "Thanks for your order. You'll receive your order soon!";
        }
    }
}
