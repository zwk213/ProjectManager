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
    public class UserBll
    {
        private readonly ICacheDataLayer<User> _userDataLayer;
        private readonly ICacheDataLayer<UserGroup> _userGroupDataLayer;

        public UserBll(ICacheDataLayer<User> userDataLayer, ICacheDataLayer<UserGroup> userGroupDataLayer)
        {
            _userDataLayer = userDataLayer;
            _userGroupDataLayer = userGroupDataLayer;
        }

        #region User

        public async Task AddAsync(User user)
        {
            user.Validate();
            await _userDataLayer.InsertAsync(user);
            //移除用户所属组的缓存，等下次获取再更新
            await _userGroupDataLayer.CacheService.RemoveAsync(user.GroupId);
        }

        public async Task<User> GetAsync(string key)
        {
            return await _userDataLayer.SelectAsync(p => p.PrimaryKey == key);
        }

        public async Task<PageData<User>> GetListAsync(string projectid, string orderby, int page, int size)
        {
            return await _userDataLayer.SelectPageAsync(p => p.ProjectId == projectid, orderby, page, size);
        }

        public async Task<List<SelectOption>> GetOptionsAsync(string projectId)
        {
            var temp = await _userDataLayer.DbContext.Set<User>()
                .Where(p => p.ProjectId == projectId)
                .OrderByDescending(p => p.CreateDate)
                .Select(p =>
                    new SelectOption()
                    {
                        Label = p.UserName,
                        Value = p.PrimaryKey,
                    }).ToListAsync();
            return temp;
        }

        public async Task UpdateAsync(User user)
        {
            var temp = await GetAsync(user.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该用户");
            temp.UpdateFrom(user);
            temp.Validate();
            await _userDataLayer.UpdateAsync(temp);
            //移除用户所属组的缓存，等下次获取再更新
            await _userGroupDataLayer.CacheService.RemoveAsync(temp.GroupId);
        }

        #endregion

        #region UserGroup

        public async Task AddGroupAsync(UserGroup group)
        {
            group.Validate();
            await _userGroupDataLayer.InsertAsync(group);
        }

        public async Task<UserGroup> GetGroupAsync(string key)
        {
            return await _userGroupDataLayer.SelectAsync(p => p.PrimaryKey == key, p => p.Users);
        }

        public async Task<PageData<UserGroup>> GetGroupListAsync(string projectid, string orderby, int page, int size)
        {
            return await _userGroupDataLayer.SelectPageAsync(p => p.ProjectId == projectid, orderby, page, size, p => p.Users);
        }

        public async Task<List<SelectOption>> GetGroupOptionsAsync(string projectId)
        {
            var temp = await _userGroupDataLayer.DbContext.Set<UserGroup>()
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

        public async Task UpdateGroupAsync(UserGroup group)
        {
            var temp = await GetGroupAsync(group.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该用户组");
            temp.UpdateFrom(group);
            temp.Validate();
            await _userGroupDataLayer.UpdateAsync(temp);
        }

        #endregion

    }
}
