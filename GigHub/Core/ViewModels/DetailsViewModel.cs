using GigHub4.Core.Models;

namespace GigHub4.Core.ViewModels
{
    public class DetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}