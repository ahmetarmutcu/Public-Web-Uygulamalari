using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter  giriş yapınız");
            RuleFor(x => x.Name).MaximumLength(250).WithMessage("Lütfen 250 karakterden fazla değer girişi yapmayınız");


            RuleFor(x => x.Content).NotEmpty().WithMessage("Ürün açıklması boş geçilemez");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Lütfen en az 10 karakter  giriş yapınız");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayınız");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");

            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");


            RuleFor(x => x.Img1Path).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");

        }
    }
}
