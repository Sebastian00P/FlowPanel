using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.Announcement
{
    public interface IAnnouncementService
    {
        Task<List<Models.Announcement>> GetAll();
        Task CreateAnnouncement(Models.Announcement announcement);
    }
}
