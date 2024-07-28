using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {//FluenValidatior paketini indirdik.
    
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adreisni Boş Geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adıı bOş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 Karakater Girişi Yapın.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 Karakater Girişi Yapın.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 Karakaterden fazla  Girişi Yapmayın");
         
        }
    }
}
