using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGround.ViewModel.Validator
{
    public class PlayerValidator<T> : AbstractValidator<T> where T : VmPlayer
    {
        public PlayerValidator()
        {
            this.RuleFor(m => m.Name).NotEmpty().WithMessage("Required");
        }
    }

    public class RegistryValidator<T> : PlayerValidator<VmRegistry>
    {
        public RegistryValidator()
        {
            this.RuleFor(m => m.Login).NotEmpty().WithMessage("Required");
            this.RuleFor(m => m.Email).NotEmpty().WithMessage("Required");
            this.RuleFor(m => m.Password).Equal(m => m.CheckPassword).WithMessage("NotSame");

        }
    }

    //public class AccountValidator : UserValidator<VmAccount>
    //{
    //    public AccountValidator()
    //    {
    //        this.RuleFor(m => m.Login).NotEmpty().WithMessage("Required");
    //    }
    //}

    //public class ChangePasswordValidator : AbstractValidator<VmeChangePassword>
    //{
    //    public ChangePasswordValidator()
    //    {
    //        this.RuleFor(m => m.Password).NotEmpty().WithMessage("Requried");
    //        this.RuleFor(m => m.NewPassword).NotEmpty().Length(6, 20).WithMessage("Requried");
    //        this.RuleFor(m => m.ConfirmPassword).NotEmpty().Must((model, confirm) =>
    //        {
    //            return model.NewPassword == confirm;
    //        }).WithMessage("Requried");
    //    }
    //}

    public class LoginValidator<T> : AbstractValidator<T> where T:VmLogin
    {
        public LoginValidator()
        {
            this.RuleFor(m => m.Login).NotEmpty().WithMessage("Required");
            this.RuleFor(m => m.Password).NotEmpty().WithMessage("Required");
        }
    }

}
