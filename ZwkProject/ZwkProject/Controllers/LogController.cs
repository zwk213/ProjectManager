using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFHelper.Model;
using LogModule.Bll;
using LogModule.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZwkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly LogBll _logBll;

        public LogController(LogBll logBll)
        {
            _logBll = logBll;
        }

        [Route("/api/log/operating/get")]
        public async Task<IActionResult> GetOperatingLog(string logId)
        {
            OperatingLog log = await _logBll.GetOperatingLogAsync(logId);
            return new JsonResult(new { success = true, data = log });
        }

        [Route("/api/log/operating/getPage")]
        public async Task<IActionResult> GetOperatingLogPage(string linkid, string summary, DateTime? start, DateTime? end, string orderBy, int page, int size)
        {
            PageData<OperatingLog> data = await _logBll.GetPageOperatingLogAsync(linkid, summary, start, end, "CreateDate desc", page, size);
            return new JsonResult(new { success = true, data });
        }

        [Route("/api/log/exception/get")]
        public async Task<IActionResult> GetExceptionLog(string logId)
        {
            ExceptionLog log = await _logBll.GetExceptionLogAsync(logId);
            return new JsonResult(new { success = true, data = log });
        }

        [Route("/api/log/exception/getPage")]
        public async Task<IActionResult> GetExceptionLogPage(DateTime? start, DateTime? end, int page, int size)
        {
            PageData<ExceptionLog> data = await _logBll.GetPageExceptionLogAsync(start, end, page, size);
            return new JsonResult(new { success = true, data });
        }

    }
}