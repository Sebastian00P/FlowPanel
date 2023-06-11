using FlowPanelApp.Context;
using FlowPanelApp.Models;
using FlowPanelApp.Services.Announcement;
using FlowPanelApp.Services.AppService;
using FlowPanelApp.Services.UserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.AnnouncementService
{
    public class AnnonuncementService : IAnnouncementService
    {
        private readonly FlowContext _flowContext;
        private readonly IAppService _appService;
        private readonly IUserService _userService;
        public AnnonuncementService(FlowContext flowContext, IAppService appService, IUserService userService) 
        {
            _flowContext = flowContext;
            _appService = appService;
            _userService = userService;
        }
        public async Task<List<Models.Announcement>> GetAll()
        {
            var announcements = await _flowContext.Announcements.Where(x => x.IsActive).OrderByDescending(x => x.CreationTime).ToListAsync();
            foreach (var item in announcements)
            {
                item.User = await _userService.GetUserById(item.UserId);
            }
            return announcements;
        }
        public async Task CreateAnnouncement(Models.Announcement announcement)
        {
            var user = _appService.GetCurrentSessionUserData();
            announcement.IsActive = true;
            announcement.CreationTime = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            announcement.UserId = user.UserId;
            _flowContext.Announcements.Add(announcement);
            await _flowContext.SaveChangesAsync();
        }
        public async Task<Models.Announcement> GetAnnouncementById(long announcementId)
        {
            return await _flowContext.Announcements.AsNoTracking().FirstOrDefaultAsync(x => x.Id == announcementId);
        }
        public async Task DeActiveAnnouncement(long announcementId)
        {
            var item = await GetAnnouncementById(announcementId);
            item.IsActive = false;
            _flowContext.Announcements.Update(item);
            await _flowContext.SaveChangesAsync();
        }
    }
}
