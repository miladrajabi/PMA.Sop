//using FluentValidation;
//using PMA.Sop.Domain.User.Commands;

//namespace PMA.Sop.ApplicationServices.User.Command
//{
//    public class CreateUserInfoCommandValidator : AbstractValidator<AddApplicationUserInfoCommand>
//    {
//        public CreateUserInfoCommandValidator()
//        {
//            RuleFor(x => x.NationalCode).MinimumLength(10).MaximumLength(10).WithErrorCode("");
//        }
//    }
//}