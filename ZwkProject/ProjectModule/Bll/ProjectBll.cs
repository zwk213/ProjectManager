using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using ProjectModule.Enum;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class ProjectBll
    {
        private readonly IDataLayer<Project> _projectDataLayer;

        public ProjectBll(IDataLayer<Project> projectDataLayer)
        {
            _projectDataLayer = projectDataLayer;
        }

        public async Task AddAsync(Project project)
        {
            await _projectDataLayer.InsertAsync(project);
        }

        public async Task<Project> GetAsync(string key)
        {
            return await _projectDataLayer.SelectAsync(p => p.PrimaryKey == key);
        }

        public async Task<PageData<Project>> GetListAsync(string orderby, int page, int size)
        {
            return await _projectDataLayer.SelectPageAsync(p => true, orderby, page, size);
        }

        public async Task UpdateAsync(Project project)
        {
            await _projectDataLayer.UpdateAsync(project);
        }

        public async Task UpdateStatusAsync(string key, ProjectStatus status, string updateBy)
        {
            Project temp = await _projectDataLayer.SelectAsync(p => p.PrimaryKey == key);
            temp.Status = status;
            temp.UpdateBy = updateBy;
            temp.UpdateDate = DateTime.Now;
            await _projectDataLayer.UpdateAsync(temp);
        }

    }
}
