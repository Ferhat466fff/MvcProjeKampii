using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {//FluenValidatior paketini indirdik.
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Alanını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).Matches(".*[aA].*").WithMessage("Hakkımda Alanında Mutlaka Bir 'a' Harfi Bulunmalıdır.");//matches-->doğrulama yapıyor
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Alanını Boş Geçemezsiniz.");

        }
    }
}
