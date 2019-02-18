using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Helper;
using EFHelper.Interface;
using EFHelper.Model;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class FileBll
    {
        private readonly IDataLayer<Folder> _folderDataLayer;
        private readonly IDataLayer<File> _fileDataLayer;

        public FileBll(IDataLayer<Folder> folderDataLayer, IDataLayer<File> docDataLayer)
        {
            _folderDataLayer = folderDataLayer;
            _fileDataLayer = docDataLayer;
        }

        #region file

        public async Task AddAsync(File doc)
        {
            await _fileDataLayer.InsertAsync(doc);
        }

        public async Task UpdateAsync(File doc)
        {
            await _fileDataLayer.UpdateAsync(doc);
        }

        public async Task<File> GetAsync(string fileId)
        {
            return await _fileDataLayer.SelectAsync(p => p.PrimaryKey == fileId);
        }

        /// <summary>
        /// 获取文件夹的文件
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="folderId"></param>
        /// <param name="fileName"></param>
        /// <param name="orderby"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<PageData<File>> GetListAsync(string projectId, string folderId, string fileName, string orderby, int page, int size)
        {
            Expression<Func<File, bool>> where = p => p.ProjectId == projectId;
            if (!string.IsNullOrEmpty(fileName))
                where = where.And(p => p.Name.Contains(fileName));
            else
                where = string.IsNullOrEmpty(folderId) ?
                            where.And(p => string.IsNullOrEmpty(p.FolderId)) :
                            where.And(p => p.FolderId == folderId);
            return await _fileDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        /// <summary>
        /// 获取某个时间节点的文件
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="orderby"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<PageData<File>> GetListAsync(string projectId, string scheduleId, string orderby, int page, int size)
        {
            Expression<Func<File, bool>> where = p => p.ProjectId == projectId && p.ScheduleId == scheduleId;
            return await _fileDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        #endregion

        #region folder

        public async Task AddAsync(Folder docGroup)
        {
            await _folderDataLayer.InsertAsync(docGroup);
        }

        public async Task UpdateAsync(Folder docGroup)
        {
            await _folderDataLayer.InsertAsync(docGroup);
        }

        public async Task<Folder> GetFolderAsync(string folderId)
        {
            return await _folderDataLayer.SelectAsync(p => p.PrimaryKey == folderId);
        }

        public async Task<PageData<Folder>> GetFolderListAsync(string projectid, string folderId, string orderby, int page, int size)
        {
            Expression<Func<Folder, bool>> where = p => p.ProjectId == projectid;
            where = !string.IsNullOrEmpty(folderId) ? 
                where.And(p => p.ParentId == folderId) : 
                where.And(p => string.IsNullOrEmpty(p.ParentId));
            return await _folderDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        #endregion

    }
}
