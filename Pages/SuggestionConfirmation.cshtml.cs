using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SparktonianNet.Pages
{
    public class SuggestionConfirmationModel : PageModel
    {
        public void OnGet()
        {
        }

        // TODO: save the suggestion to a database
        // TODO: Create a unique user ID so we can track suggestions and time submitted to avoid spam
        // TODO: Create a suggestion ID so we can avoid conflicts
    }
}
