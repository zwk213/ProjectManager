using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class ScheduleBll
    {
        private readonly ICacheDataLayer<Schedule> _scheduleDataLayer;

        public ScheduleBll(ICacheDataLayer<Schedule> issueGroupDataLayer)
        {
            _scheduleDataLayer = issueGroupDataLayer;
        }

        public async Task AddAsync(Schedule group)
        {
            await _scheduleDataLayer.InsertAsync(group);
        }

        public async Task<PageData<Schedule>> GetListAsync(string projectId, string orderby, int page, int size)
        {
            return await _scheduleDataLayer.SelectPageAsync(p => p.ProjectId == projectId, orderby, page, size);
        }

        public async Task<Schedule> GetAsync(string primaryKey)
        {
            return await _scheduleDataLayer.SelectAsync(p => p.PrimaryKey == primaryKey);
        }

        public async Task UpdateAsync(Schedule group)
        {
            await _scheduleDataLayer.UpdateAsync(group);
        }

    }
}
