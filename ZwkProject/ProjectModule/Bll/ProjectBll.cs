using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CacheHelper.Enum;
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

        public async Task<PageData<Project>> GetPageAsync(string name, string orderby, int page, int size)
        {
            Expression<Func<Project, bool>> where = p => true;
            if (!string.IsNullOrEmpty(name))
                where = where.And(p => p.Name.Contains(name));
            return await _projectDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        public async Task UpdateAsync(Project project)
        {
            var temp = await GetAsync(project.PrimaryKey);
            if (temp == null)
                throw new Exception("未发现该项目");
            temp.UpdateFrom(project);
            temp.Validate();
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
