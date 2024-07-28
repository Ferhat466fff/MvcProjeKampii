using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz.");
            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("E-posta adresi boş olamaz.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.Subject).MaximumLength(200).WithMessage("Lütfen En fazla 200 Karakter Girişi Yapın");
            
        }
    }
}
