using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using Microsoft.EntityFrameworkCore;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class LinkBll
    {
        private readonly ICacheDataLayer<Link> _linkDataLayer;
        private readonly ICacheDataLayer<LinkGroup> _linkGroupDataLayer;

        public LinkBll(ICacheDataLayer<Link> linkDataLayer, ICacheDataLayer<LinkGroup> linkGroupDataLayer)
        {
            _linkDataLayer = linkDataLayer;
            _linkGroupDataLayer = linkGroupDataLayer;
        }

        #region Link

        public async Task AddAsync(Link link)
        {
            await _linkDataLayer.InsertAsync(link);
        }

        public async Task<Link> GetAsync(string key)
        {
            return await _linkDataLayer.SelectAsync(p => p.PrimaryKey == key);
        }

        public async Task<PageData<Link>> GetListAsync(string projectid, string orderby, int page, int size)
        {
            return await _linkDataLayer.SelectPageAsync(p => p.ProjectId == projectid, orderby, page, size);
        }

        public async Task UpdateAsync(Link link)
        {
            var temp = await GetAsync(link.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该链接");
            temp.UpdateFrom(link);
            temp.Validate();
            await _linkDataLayer.UpdateAsync(temp);
        }

        public async Task DeleteAsync(string key)
        {
            await _linkDataLayer.DeleteAsync(p => p.PrimaryKey == key);
        }

        #endregion

        #region LinkGroup

        public async Task AddGroupAsync(LinkGroup group)
        {
            group.Validate();
            await _linkGroupDataLayer.InsertAsync(group);
        }

        public async Task<LinkGroup> GetGroupAsync(string key)
        {
            return await _linkGroupDataLayer.SelectAsync(p => p.PrimaryKey == key, p => p.Links);
        }

        public async Task<PageData<LinkGroup>> GetGroupListAsync(string projectid, string orderby, int page, int size)
        {
            return await _linkGroupDataLayer.SelectPageAsync(p => p.ProjectId == projectid, orderby, page, size, p => p.Links);
        }

        public async Task<List<SelectOption>> GetGroupOptionsAsync(string projectId)
        {
            var temp = await _linkGroupDataLayer.DbContext.Set<LinkGroup>()
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

        public async Task UpdateGroupAsync(LinkGroup group)
        {
            var temp = await GetGroupAsync(group.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该用户组");
            temp.UpdateFrom(group);
            temp.Validate();
            await _linkGroupDataLayer.UpdateAsync(temp);
        }

        #endregion






    }
}
