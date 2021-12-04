using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Ad ve Soyadı boş geçilemez");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Email adresi boş geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.Message).MinimumLength(15).WithMessage("Mesaj en az 15 karakter olmalıdır.");
        }
    }
}
