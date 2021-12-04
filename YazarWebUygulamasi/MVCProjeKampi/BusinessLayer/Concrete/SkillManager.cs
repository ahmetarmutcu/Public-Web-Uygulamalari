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
    public class SkillManager : ISkillService
    {

        ISkillDal _skilldal;

        public SkillManager(ISkillDal skilldal)
        {
            _skilldal = skilldal;

        }

        public Skill GetByID(int id)
        {
            return _skilldal.Get(x => x.ID == id);
        }

        public void UpdateSkill(Skill skill)
        {
            _skilldal.Update(skill);
        }
    }
}
