using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using UserModule.Model;

namespace UserModule.Bll
{
    public class UserGroupBll
    {

        private readonly IDataLayer<Group> _groupDataLayer;
        private readonly IDataLayer<UserInGroup> _userInGroupDataLayer;

        public UserGroupBll(IDataLayer<Group> groupDataLayer, IDataLayer<UserInGroup> userInGroupDataLayer)
        {
            _groupDataLayer = groupDataLayer;
            _userInGroupDataLayer = userInGroupDataLayer;
        }


        #region Group

        public async Task AddAsync(Group group)
        {
            await _groupDataLayer.InsertAsync(group);
        }

        public async Task<Group> GetAsync(string groupid)
        {
            return await _groupDataLayer.SelectAsync(p => p.PrimaryKey == groupid);
        }

        public async Task<PageData<Group>> GetListAsync(string orderby, int page, int size)
        {
            return await _groupDataLayer.SelectPageAsync(p => true, orderby, page, size);
        }


        #endregion

        #region UserInGroup

        public async Task AddUserAsync(UserInGroup model)
        {
            await _userInGroupDataLayer.InsertAsync(model);
        }

        public async Task DeleteUserAsync(string userid, string groupid)
        {
            await _userInGroupDataLayer.DeleteAsync(p => p.UserId == userid && p.GroupId == groupid);
        }

        #endregion



    }
}
