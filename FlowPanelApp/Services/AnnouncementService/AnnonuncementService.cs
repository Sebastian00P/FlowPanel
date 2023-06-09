using FlowPanelApp.Context;
using FlowPanelApp.Models;
using FlowPanelApp.Services.Announcement;
using FlowPanelApp.Services.AppService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowPanelApp.Services.AnnouncementService
{
    public class AnnonuncementService : IAnnouncementService
    {
        private readonly FlowContext _flowContext;
        private readonly IAppService _appService;
        public AnnonuncementService(FlowContext flowContext, IAppService appService) 
        {
            _flowContext = flowContext;
            _appService = appService;
        }
        public async Task<List<Models.Announcement>> GetAll()
        {
            return await _flowContext.Announcements.ToListAsync();
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
    }
}
