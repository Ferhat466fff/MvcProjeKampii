using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{//. Hata Mesajları
    public class AdminValidator : AbstractValidator<Admin>
    {//FluenValidatior paketini indirdik.
        public AdminValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Adını Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez.");
            RuleFor(x => x.AdminPassword).MinimumLength(3).WithMessage("Lütfen En Az 1 Karakter Girişi Yapın");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Rol Alanını Boş Geçemezsiniz.");
        }
    }
}
