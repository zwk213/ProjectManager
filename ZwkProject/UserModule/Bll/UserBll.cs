using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EFHelper.Helper;
using EFHelper.Interface;
using EFHelper.Model;
using UserModule.Enum;
using UserModule.Model;

namespace UserModule.Bll
{
    public class UserBll
    {
        private readonly ICacheDataLayer<User> _userDataLayer;

        public UserBll(ICacheDataLayer<User> userDataLayer)
        {
            _userDataLayer = userDataLayer;
        }

        public async Task<User> LoginAsync(string loginName, string password)
        {
            return await _userDataLayer.SelectAsync(p => p.UserName == loginName && p.Password == password && p.Status == UserStatus.Normal);
        }

        public async Task<User> ValidateAsync(string primaryKey, string loginName)
        {
            return await _userDataLayer.SelectAsync(p => p.PrimaryKey == primaryKey && p.UserName == loginName && p.Status == UserStatus.Normal);
        }

        public async Task AddAsync(User user)
        {
            await _userDataLayer.InsertAsync(user);
        }

        public async Task<User> GetAsync(string key)
        {
            return await _userDataLayer.SelectAsync(key);
        }

        public async Task<PageData<User>> GetListAsync(string userName, string orderby, int page, int size)
        {
            Expression<Func<User, bool>> where = p => true;
            if (!string.IsNullOrEmpty(userName))
                where = where.And(p => p.UserName.Contains(userName));
            return await _userDataLayer.SelectPageAsync(where, orderby, page, size);
        }

        public async Task UpdateAsync(User user)
        {
            await _userDataLayer.UpdateAsync(user);
        }

    }
}
