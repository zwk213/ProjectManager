﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Helper;
using EFHelper.Interface;
using EFHelper.Model;
using ProjectModule.Enum;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class IssueBll
    {
        private readonly IDataLayer<Issue> _issueDataLayer;

        public IssueBll(IDataLayer<Issue> issueDataLayer)
        {
            _issueDataLayer = issueDataLayer;
        }

        public async Task AddAsync(Issue issue)
        {
            await _issueDataLayer.InsertAsync(issue);
        }

        public async Task<Issue> GetAsync(string key)
        {
            return await _issueDataLayer.SelectAsync(p => p.PrimaryKey == key);
        }

        public async Task<PageData<Issue>> GetListAsync(string projectId, string scheduleId, string orderby, int page, int size)
        {
            Expression<Func<Issue, bool>> where = p => p.ProjectId == projectId;
            if (!string.IsNullOrEmpty(scheduleId))
                where = where.And(p => p.ScheduleId == scheduleId);
            return await _issueDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        public async Task UpdateAsync(Issue issue)
        {
            await _issueDataLayer.UpdateAsync(issue);
        }

    }

}