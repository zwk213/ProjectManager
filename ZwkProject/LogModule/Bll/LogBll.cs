using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Helper;
using EFHelper.Interface;
using EFHelper.Model;
using LogModule.Model;

namespace LogModule.Bll
{
    public class LogBll
    {

        private readonly IDataLayer<ExceptionLog> _exceptionDataLayer;
        private readonly IDataLayer<OperatingLog> _operatingDataLayer;

        public LogBll(IDataLayer<ExceptionLog> exceptionDataLayer, IDataLayer<OperatingLog> operatingDataLayer)
        {
            _exceptionDataLayer = exceptionDataLayer;
            _operatingDataLayer = operatingDataLayer;
        }

        #region ExceptionLog

        public async Task AddAsync(ExceptionLog log)
        {
            await _exceptionDataLayer.InsertAsync(log);
        }

        public async Task<ExceptionLog> GetExceptionLogAsync(string logId)
        {
            Expression<Func<ExceptionLog, bool>> where = p => p.PrimaryKey == logId;
            return await _exceptionDataLayer.SelectAsync(where);
        }

        public async Task<PageData<ExceptionLog>> GetPageExceptionLogAsync(DateTime? start, DateTime? end, int page, int size)
        {
            Expression<Func<ExceptionLog, bool>> where = p => true;
            if (start.HasValue)
            {
                where = end.HasValue ? where.And(p => p.CreateDate.Date >= start.Value.Date && p.CreateDate.Date <= end.Value.Date) :
                    where.And(p => p.CreateDate.Date == start.Value.Date);
            }
            return await _exceptionDataLayer.SelectPageAsync(where, "CreateDate Desc", page, size);
        }

        #endregion

        #region OperatingLog

        public async Task AddAsync(OperatingLog log)
        {
            await _operatingDataLayer.InsertAsync(log);
        }

        public async Task AddAsync(string createId, string summary, string model, string linkId)
        {
            var log = new OperatingLog();
            log.Create(createId);
            log.LinkId = linkId;
            log.Summary = summary;
            log.Model = model;
            await AddAsync(log);
        }

        public async Task<OperatingLog> GetOperatingLogAsync(string logId)
        {
            Expression<Func<OperatingLog, bool>> where = p => p.PrimaryKey == logId;
            return await _operatingDataLayer.SelectAsync(where);
        }

        public async Task<PageData<OperatingLog>> GetPageOperatingLogAsync(string linkid, string summary, DateTime? start, DateTime? end, string orderBy, int page, int size)
        {
            Expression<Func<OperatingLog, bool>> where = p => true;
            if (start.HasValue)
            {
                where = end.HasValue ? where.And(p => p.CreateDate.Date >= start.Value.Date && p.CreateDate.Date <= end.Value.Date) :
                    where.And(p => p.CreateDate.Date == start.Value.Date);
            }
            if (!string.IsNullOrEmpty(linkid))
            {
                where = where.And(p => p.LinkId == linkid);
            }
            return await _operatingDataLayer.SelectPageAsync(where, orderBy, page, size);
        }


        #endregion





    }
}
