using AutoMapper;
using Financ.Data.Models;
using Financ.Api.View.Models;

namespace Financ.API.Tools
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserView, User>().ReverseMap();
            CreateMap<ProfileIncomeView, ProfileIncome>().ReverseMap();
            CreateMap<ProfileExpenseView, ProfileExpense>().ReverseMap();
            CreateMap<IncomeView, Income>().ReverseMap();
            CreateMap<ExpenseView, Expense>().ReverseMap();
            CreateMap<OriginView, Origin>().ReverseMap();
            CreateMap<CategoryView, Category>().ReverseMap();
            CreateMap<ProfilePayView, ProfilePay>().ReverseMap();
            CreateMap<TypePayView, TypePay>().ReverseMap();
        }
    }
}
