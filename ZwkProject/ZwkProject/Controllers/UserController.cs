using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreHelper;
using EFHelper.Model;
using JwtService;
using LogModule.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserModule.Bll;
using UserModule.Enum;
using UserModule.Model;

namespace ZwkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserBll _userBll;
        private readonly UserGroupBll _userGroupBll;

        private readonly LogBll _logBll;

        public UserController(UserBll userBll, UserGroupBll userGroupBll, LogBll logBll)
        {
            _userBll = userBll;
            _userGroupBll = userGroupBll;
            _logBll = logBll;
        }

        #region user

        [Route("/api/user/add")]
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            user.Create(Request.RequestUser().UserId);
            user.Status = UserStatus.Normal;
            await _userBll.AddAsync(user);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了用户：" + user.UserName,
                JsonHelper.Serialize(user),
                user.PrimaryKey
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/user/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            user.Update(Request.RequestUser().UserId);
            await _userBll.UpdateAsync(user);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "更新了用户：" + user.UserName,
                JsonHelper.Serialize(user),
                user.PrimaryKey
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/user/get")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            User user = await _userBll.GetAsync(userId);
            return new JsonResult(new { success = true, data = user });
        }

        [Route("/api/user/getPage")]
        [HttpGet]
        public async Task<IActionResult> GetUserPage(string userName, int page, int size)
        {
            PageData<User> user = await _userBll.GetListAsync(userName, "CreateDate desc", page, size);
            return new JsonResult(new { success = true, data = user });
        }

        #endregion

        #region group

        [Route("/api/group/add")]
        [HttpPost]
        public async Task<IActionResult> AddGroup(Group group)
        {
            group.Create(Request.RequestUser().UserId);
            await _userGroupBll.AddAsync(group);
            //日志
            await _logBll.AddAsync(
                Request.RequestUser().UserId,
                Request.RequestUser().UserName + "添加了用户组：" + group.GroupName,
                JsonHelper.Serialize(group),
                group.PrimaryKey
            );
            return new JsonResult(new { success = true });
        }

        [Route("/api/group/getList")]
        [HttpGet]
        public async Task<IActionResult> GetGroupList()
        {
            var result = await _userGroupBll.GetListAsync("", 1, 1000);
            return new JsonResult(new { success = true, data = result.Data });
        }

        #endregion

    }
}