using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISettingService
    {
        List<Setting> GetList();
        void SettingAdd(Setting setting);
        Setting GetByID(int id);
        void SettingDelete(Setting setting);
        void SettingUpdate(Setting setting);
    }
}
