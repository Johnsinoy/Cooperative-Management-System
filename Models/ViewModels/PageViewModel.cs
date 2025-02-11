namespace Cooperative_Financing.Models.ViewModels
{
    public class PageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CurrentPage { get; set; }

        public PageViewModel(string title, string description, string currentPage)
        {
            Title = title;
            Description = description;
            CurrentPage = currentPage;
        }

        public string GetFormattedTitle()
        {
            return $"{Title} - Cooperative Financing";
        }
    }
}
