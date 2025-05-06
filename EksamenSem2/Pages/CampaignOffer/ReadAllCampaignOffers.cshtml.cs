using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.CampaignOffer
{
    public class ReadAllCampaignOffersModel : PageModel
    {
        private CampaignOfferService _campaignOfferService;
        public ReadAllCampaignOffersModel(CampaignOfferService campaignOfferService)
        {
            _campaignOfferService = campaignOfferService;
        }
        public List<Models.CampaignOffer>? CampaignOffers { get; set; }

        [BindProperty]
        public string SearchString { get; set; }
        //Other search criteria properties can be added here:
        //
        
        public void OnGet()
        {
            // Get all campaign offers
            CampaignOffers = _campaignOfferService.ReadAllCampaignOffers();
            if (CampaignOffers == null)
            {
                // Handle not found case
                RedirectToPage("./Index");
            }
        }
        //Other onget methods such as sorting order can be added here:
        //

        public IActionResult OnPost()
        {
            // Handle search input
            if (!string.IsNullOrEmpty(SearchString))
            {
                CampaignOffers = _campaignOfferService.ReadAllCampaignOffers().ToList();
            }
            return Page();
        }
        //Other onpost methods such as filtering can be added here:
        //
    }
}
