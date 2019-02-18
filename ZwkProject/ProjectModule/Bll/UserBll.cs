using System.Threading.Tasks;
using EFHelper.Interface;
using EFHelper.Model;
using ProjectModule.Model;

namespace ProjectModule.Bll
{
    public class UserBll
    {
        private readonly IDataLayer<User> _userDataLayer;

        public UserBll(IDataLayer<User> userDataLayer)
        {
            _userDataLayer = userDataLayer;
        }

        public async Task AddAsync(User user)
        {
            await _userDataLayer.InsertAsync(user);
        }

        public async Task<User> GetAsync(string key)
        {
            return await _userDataLayer.SelectAsync(p => p.PrimaryKey == key);
        }

        public async Task<PageData<User>> GetListAsync(string projectid, string orderby, int page, int size)
        {
            return await _userDataLayer.SelectPageAsync(p => p.ProjectId == projectid, orderby, page, size);
        }

        public async Task UpdateAsync(User user)
        {
            await _userDataLayer.UpdateAsync(user);
        }


    }
}
