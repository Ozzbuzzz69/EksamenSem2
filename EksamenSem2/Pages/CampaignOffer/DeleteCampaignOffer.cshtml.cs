using EksamenProjekt2Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EksamenProjekt2Sem.Pages.CampaignOffer
{
    public class DeleteCampaignOfferModel : PageModel
    {
        private CampaignOfferService _campaignOfferService;
        public DeleteCampaignOfferModel(CampaignOfferService campaignOfferService)
        {
            _campaignOfferService = campaignOfferService;
        }
        [BindProperty]
        public Models.CampaignOffer CampaignOffer { get; set; }
        public IActionResult OnGet(int id)
        {
            // Get the campaign offer by id
            CampaignOffer = _campaignOfferService.ReadCampaignOffer(id);
            if (CampaignOffer == null)
            {
                // Handle not found case
                RedirectToPage("./Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.CampaignOffer deletedCampaignOffer = _campaignOfferService.DeleteCampaignOffer(CampaignOffer.Id);
            if (deletedCampaignOffer == null)
            {
                // Handle not found case
                RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}

