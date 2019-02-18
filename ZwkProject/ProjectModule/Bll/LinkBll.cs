using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class LinkBll
    {
        private readonly IDataLayer<Link> _linkDataLayer;

        public LinkBll(IDataLayer<Link> linkDataLayer)
        {
            _linkDataLayer = linkDataLayer;
        }

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
            await _linkDataLayer.UpdateAsync(link);
        }

        public async Task DeleteAsync(string key)
        {
            await _linkDataLayer.DeleteAsync(p => p.PrimaryKey == key);
        }

    }
}
