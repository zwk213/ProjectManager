﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Schedule schedule)
        {
            schedule.Validate();
            await _scheduleDataLayer.InsertAsync(schedule);
        }

        public async Task<PageData<Schedule>> GetListAsync(string projectId, string orderby, int page, int size)
        {
            return await _scheduleDataLayer.SelectPageAsync(p => p.ProjectId == projectId, orderby, page, size);
        }

        public async Task<List<SelectOption>> GetOptionsAsync(string projectId)
        {
            var temp = await _scheduleDataLayer.DbContext.Set<Schedule>()
                .Where(p => p.ProjectId == projectId)
                .OrderByDescending(p => p.CreateDate)
                .Select(p =>
                 new SelectOption()
                 {
                     Label = p.Name,
                     Value = p.PrimaryKey,
                 }).ToListAsync();
            return temp;
        }

        public async Task<Schedule> GetAsync(string primaryKey)
        {
            return await _scheduleDataLayer.SelectAsync(p => p.PrimaryKey == primaryKey);
        }

        public async Task UpdateAsync(Schedule schedule)
        {
            var temp = await GetAsync(schedule.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该时间节点");
            temp.UpdateFrom(schedule);
            temp.Validate();
            await _scheduleDataLayer.UpdateAsync(temp);
        }

    }
}
