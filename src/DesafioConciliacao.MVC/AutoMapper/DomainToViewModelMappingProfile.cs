using AutoMapper;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.MVC.Models;
using System;
using System.Globalization;

namespace DesafioConciliacao.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Transaction, TransactionViewModel>();
            //CreateMap<Transaction, TransactionViewModel>().ForMember(destino => destino.IdFile, opt => opt.MapFrom(fonteEntrada => fonteEntrada.IdFile))
            //                                     .ForMember(destino => destino.Type, opt => opt.MapFrom(fonteEntrada => fonteEntrada.Type))
            //                                     .ForMember(destino => ConvertToDateTime(destino.Date), opt => opt.MapFrom(fonteEntrada => fonteEntrada.Date))
            //                                     .ForMember(destino => decimal.Parse(destino.Amount, CultureInfo.InvariantCulture), opt => opt.MapFrom(fonteEntrada => fonteEntrada.Amount))
            //                                     .ForMember(destino => destino.Name, opt => opt.MapFrom(fonteEntrada => fonteEntrada.Name))
            //                                     ;

        }
        private static DateTime ConvertToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString.Replace("[-03:EST]", ""), "yyyyMMddHHmmss", new CultureInfo("pt-BR"));
        }
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
       
    }
}