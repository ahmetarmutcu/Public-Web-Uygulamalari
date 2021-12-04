using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SettingManager:ISettingService
    {
        ISettingDal _settingDal;
        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }

        public Setting GetByID(int id)
        {
            return _settingDal.Get(x => x.ID == id);
        }

        public List<Setting> GetList()
        {
            return _settingDal.List();
        }

        public void SettingAdd(Setting setting)
        {
            _settingDal.Insert(setting);
        }

        public void SettingDelete(Setting setting)
        {
            _settingDal.Delete(setting);
        }

        public void SettingUpdate(Setting setting)
        {
            _settingDal.Update(setting);
        }
    }
}
