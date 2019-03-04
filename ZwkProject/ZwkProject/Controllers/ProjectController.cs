using System.Threading.Tasks;
using CoreHelper;
using EFHelper.Model;
using JwtService;
using LogModule.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectModule.Bll;
using ProjectModule.Model;
using ZwkProject.Model.Project;

namespace ZwkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        //项目
        private readonly ProjectBll _projectBll;
        private readonly FileBll _fileBll;
        private readonly IssueBll _issueBll;
        private readonly ScheduleBll _scheduleBll;
        private readonly UserBll _userBll;
        private readonly LinkBll _linkBll;
        //用户
        private readonly UserModule.Bll.UserBll _userModuleUserBll;
        //日志
        private readonly LogBll _logBll;

        public ProjectController(ProjectBll projectBll, FileBll fileBll, IssueBll issueBll, UserBll userBll, LinkBll linkBll, ScheduleBll scheduleBll, UserModule.Bll.UserBll userModuleUserBll, LogBll logBll)
        {
            _projectBll = projectBll;
            _fileBll = fileBll;
            _issueBll = issueBll;
            _userBll = userBll;
            _linkBll = linkBll;
            _scheduleBll = scheduleBll;
            _userModuleUserBll = userModuleUserBll;
            _logBll = logBll;
        }

        #region project

        [Route("/api/project/add")]
        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            project.Create(Request.RequestUser().UserId);
            await _projectBll.AddAsync(project);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "创建了项目：" + project.Name,
                JsonHelper.Serialize(project),
                project.PrimaryKey
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            project.Update(Request.RequestUser().UserId);
            await _projectBll.UpdateAsync(project);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "修改了项目：" + project.Name,
                JsonHelper.Serialize(project),
                project.PrimaryKey
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/get")]
        [HttpGet]
        public async Task<IActionResult> GetProject(string projectId)
        {
            Project result = await _projectBll.GetAsync(projectId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/getPage")]
        [HttpGet]
        public async Task<IActionResult> GetProjectPage(int page, int size)
        {
            PageData<Project> result = await _projectBll.GetListAsync("CreateDate Desc", page, size);
            return new JsonResult(new { success = true, data = result });
        }

        #endregion

        #region Schedule

        [Route("/api/project/schedule/add")]
        [HttpPost]
        public async Task<IActionResult> AddSchedule(Schedule schedule)
        {
            schedule.Create(Request.RequestUser().UserId);
            await _scheduleBll.AddAsync(schedule);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了时间节点：" + schedule.Name,
                JsonHelper.Serialize(schedule),
                schedule.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/schedule/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateSchedule(Schedule schedule)
        {
            schedule.Update(Request.RequestUser().UserId);
            await _scheduleBll.UpdateAsync(schedule);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了时间节点：" + schedule.Name,
                JsonHelper.Serialize(schedule),
                schedule.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/schedule/get")]
        [HttpGet]
        public async Task<IActionResult> GetSchedule(string scheduleId)
        {
            Schedule result = await _scheduleBll.GetAsync(scheduleId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/schedule/getList")]
        [HttpGet]
        public async Task<IActionResult> GetScheduleList(string projectId)
        {
            PageData<Schedule> result = await _scheduleBll.GetListAsync(projectId, "CreateDate Desc", 1, 1000);
            return new JsonResult(new { success = true, data = result.Data });
        }

        #endregion

        #region issue

        [Route("/api/project/issue/add")]
        [HttpPost]
        public async Task<IActionResult> AddIssue(Issue issue)
        {
            //获取节点名称
            if (!string.IsNullOrEmpty(issue.ScheduleId))
            {
                var temp = await _scheduleBll.GetAsync(issue.ScheduleId);
                if (temp != null)
                    issue.ScheduleName = temp.Name;
                else
                    return new JsonResult(new { success = false, message = "未发现该节点" });
            }
            //获取负责人名称
            if (!string.IsNullOrEmpty(issue.PrincipalId))
            {
                var temp = await _userBll.GetAsync(issue.PrincipalId);
                if (temp != null)
                    issue.PrincipalName = temp.UserName;
                else
                    return new JsonResult(new { success = false, message = "未发现该负责人" });
            }

            issue.Create(Request.RequestUser().UserId);
            issue.CreateName = Request.RequestUser().UserName;

            await _issueBll.AddAsync(issue);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了问题：" + issue.Summary,
                JsonHelper.Serialize(issue),
                issue.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/issue/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateIssue(Issue issue)
        {
            //获取节点名称
            if (!string.IsNullOrEmpty(issue.ScheduleId))
            {
                var temp = await _scheduleBll.GetAsync(issue.ScheduleId);
                if (temp != null)
                    issue.ScheduleName = temp.Name;
                else
                    return new JsonResult(new { success = false, message = "未发现该节点" });
            }
            //获取负责人名称
            if (!string.IsNullOrEmpty(issue.PrincipalId))
            {
                var temp = await _userBll.GetAsync(issue.PrincipalId);
                if (temp != null)
                    issue.PrincipalName = temp.UserName;
                else
                    return new JsonResult(new { success = false, message = "未发现该负责人" });
            }

            issue.Update(Request.RequestUser().UserId);
            await _issueBll.UpdateAsync(issue);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了问题：" + issue.Summary,
                JsonHelper.Serialize(issue),
                issue.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/issue/updateStatus")]
        [HttpPost]
        public async Task<IActionResult> UpdateIssueStatus(Issue model)
        {
            var issue = await _issueBll.GetAsync(model.PrimaryKey);
            issue.Status = model.Status;
            issue.Update(Request.RequestUser().UserId);
            await _issueBll.UpdateAsync(issue);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了问题【" + issue.Summary + "】状态为" + issue.Status.ToString() + "",
                JsonHelper.Serialize(issue),
                issue.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/issue/get")]
        [HttpGet]
        public async Task<IActionResult> GetIssue(string issueId)
        {
            Issue result = await _issueBll.GetAsync(issueId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/issue/getPage")]
        [HttpGet]
        public async Task<IActionResult> GetIssuePage(string projectId, string scheduleId, int page, int size)
        {
            PageData<Issue> result = await _issueBll.GetListAsync(projectId, scheduleId, "CreateDate Desc", page, size);
            return new JsonResult(new { success = true, data = result });
        }

        #endregion

        #region user

        [Route("/api/project/user/add")]
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var temp = await _userModuleUserBll.GetAsync(user.UserId);
            if (temp != null)
                user.UserName = temp.UserName;
            else
                return new JsonResult(new { success = false, message = "用户不存在" });
            user.Create(Request.RequestUser().UserId);
            await _userBll.AddAsync(user);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了项目用户：" + user.UserName,
                JsonHelper.Serialize(user),
                user.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/user/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await _userBll.UpdateAsync(user);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了项目用户：" + user.UserName,
                JsonHelper.Serialize(user),
                user.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/user/get")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            User result = await _userBll.GetAsync(userId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/user/getList")]
        [HttpGet]
        public async Task<IActionResult> GetUserList(string projectId)
        {
            PageData<User> result = await _userBll.GetListAsync(projectId, "CreateDate Desc", 1, 1000);
            return new JsonResult(new { success = true, data = result.Data });
        }

        #endregion

        #region folder

        [Route("/api/project/folder/add")]
        [HttpPost]
        public async Task<IActionResult> AddFolder(Folder folder)
        {
            folder.Create(Request.RequestUser().UserId);
            await _fileBll.AddAsync(folder);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了项目文件夹：" + folder.Name,
                JsonHelper.Serialize(folder),
                folder.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/folder/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateFolder(Folder folder)
        {
            folder.Create(Request.RequestUser().UserId);
            await _fileBll.UpdateAsync(folder);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了项目文件夹：" + folder.Name,
                JsonHelper.Serialize(folder),
                folder.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/folder/get")]
        [HttpGet]
        public async Task<IActionResult> GetFolder(string folderId)
        {
            Folder result = await _fileBll.GetFolderAsync(folderId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/folder/getList")]
        [HttpGet]
        public async Task<IActionResult> GetFolderList(string projectId, string folderId)
        {
            PageData<Folder> result = await _fileBll.GetFolderListAsync(projectId, folderId, "CreateDate Desc", 1, 1000);
            return new JsonResult(new { success = true, data = result.Data });
        }

        #endregion

        #region file

        [Route("/api/project/file/add")]
        [HttpPost]
        public async Task<IActionResult> AddFile(File file)
        {
            file.Create(Request.RequestUser().UserId);
            file.UpdateName = Request.RequestUser().UserName;
            await _fileBll.AddAsync(file);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了项目文件：" + file.Name,
                JsonHelper.Serialize(file),
                file.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/file/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateFile(File file)
        {
            file.Create(Request.RequestUser().UserId);
            file.UpdateName = Request.RequestUser().UserName;
            await _fileBll.AddAsync(file);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了项目文件：" + file.Name,
                JsonHelper.Serialize(file),
                file.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/file/get")]
        [HttpPost]
        public async Task<IActionResult> GetFile(string fileId)
        {
            var result = await _fileBll.GetAsync(fileId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/file/getList")]
        [HttpGet]
        public async Task<IActionResult> GetFileList(string projectId, string folderId, string fileName)
        {
            PageData<File> result = await _fileBll.GetListAsync(projectId, folderId, fileName, "CreateDate Desc", 1, 1000);
            return new JsonResult(new { success = true, data = result.Data });
        }

        #endregion

        #region link

        [Route("/api/project/link/add")]
        [HttpPost]
        public async Task<IActionResult> AddLink(Link link)
        {
            link.Create(Request.RequestUser().UserId);
            await _linkBll.AddAsync(link);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了项目地址：" + link.Name,
                JsonHelper.Serialize(link),
                link.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/link/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateLink(Link link)
        {
            link.Update(Request.RequestUser().UserId);
            await _linkBll.UpdateAsync(link);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了项目地址：" + link.Name,
                JsonHelper.Serialize(link),
                link.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/link/delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteLink(DeleteLinkReq req)
        {
            var link = await _linkBll.GetAsync(req.LinkId);
            await _linkBll.DeleteAsync(req.LinkId);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "删除了项目地址：" + link.Name,
                JsonHelper.Serialize(link),
                link.ProjectId
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/project/link/get")]
        [HttpGet]
        public async Task<IActionResult> GetLink(string linkId)
        {
            Link result = await _linkBll.GetAsync(linkId);
            return new JsonResult(new { success = true, data = result });
        }

        [Route("/api/project/link/getList")]
        [HttpGet]
        public async Task<IActionResult> GetLinkList(string projectId)
        {
            PageData<Link> result = await _linkBll.GetListAsync(projectId, "CreateDate Desc", 1, 1000);
            return new JsonResult(new { success = true, data = result.Data });
        }

        #endregion

    }
}