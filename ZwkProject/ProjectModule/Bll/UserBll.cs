using System;
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

        public UserBll(ICacheDataLayer<User> userDataLayer)
        {
            _userDataLayer = userDataLayer;
        }

        public async Task AddAsync(User user)
        {
            user.Validate();
            await _userDataLayer.InsertAsync(user);
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
            if(temp==null)
                throw new Exception("未发现该用户");
            temp.UpdateFrom(user);
            temp.Validate();
            await _userDataLayer.UpdateAsync(temp);
        }


    }
}
