using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProjectBll
    {
        private readonly ICacheDataLayer<Project> _projectDataLayer;

        public ProjectBll(ICacheDataLayer<Project> projectDataLayer)
        {
            _projectDataLayer = projectDataLayer;
        }

        public async Task AddAsync(Project project)
        {
            project.Validate();
            await _projectDataLayer.InsertAsync(project);
        }

        public async Task<Project> GetAsync(string key)
        {
            return await _projectDataLayer.SelectAsync(key);
        }

        public List<string> SelectKeys(Expression<Func<Project, bool>> where, string orderby, int page, int size)
        {
            var result = _projectDataLayer.DbContext.Set<Project>()
                .Where(where)
                .SortBy(orderby)
                .Skip((page - 1) * size)
                .Take(size)
                .Select(p => p.PrimaryKey)
                .ToList();
            return result;
        }

        public List<Project> SelectAny(List<string> keys, out List<string> notInCache)
        {
            List<Project> result = new List<Project>();
            notInCache = new List<string>();
            foreach (var key in keys)
            {
                var temp = _projectDataLayer.CacheService.Get<Project>(key);
                if (temp != null)
                    result.Add(temp);
                else
                    notInCache.Add(key);
            }
            return result;
        }


        public async Task<PageData<Project>> GetPageAsync(string name, string orderby, int page, int size)
        {

            var keys = SelectKeys(p => true, orderby, page, size);
            var data = SelectAny(keys, out var not);

            PageData<Project> result = new PageData<Project>()
            {
                Page = page,
                Size = size,
                Count = 0,
                Data = data,
            };


            Expression<Func<Project, bool>> where = p => true;
            if (!string.IsNullOrEmpty(name))
                where = where.And(p => p.Name.Contains(name));
            return await _projectDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        public async Task UpdateAsync(Project project)
        {
            project.Validate();
            var temp = await GetAsync(project.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该项目");
            temp.UpdateFrom(project);
            await _projectDataLayer.UpdateAsync(project);
        }

        public async Task UpdateStatusAsync(string key, ProjectStatus status, string updateBy)
        {
            Project temp = await GetAsync(key);
            if (temp == null)
                throw new Exception("未发现该项目");
            temp.Status = status;
            temp.UpdateBy = updateBy;
            temp.UpdateDate = DateTime.Now;
            await _projectDataLayer.UpdateAsync(temp);
        }

    }
}
