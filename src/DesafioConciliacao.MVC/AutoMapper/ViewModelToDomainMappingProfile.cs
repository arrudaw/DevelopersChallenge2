using AutoMapper;
using DesafioConciliacao.Domain.Entity;
using DesafioConciliacao.MVC.Models;
using System;
using System.Globalization;

namespace DesafioConciliacao.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile :Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<TransactionViewModel, Transaction>();

            CreateMap<TransactionViewModel, Transaction>().ForMember(destino => destino.IdFile, opt => opt.MapFrom(fonteEntrada => fonteEntrada.IdFile))
                                                 .ForMember(destino => destino.Type, opt => opt.MapFrom(fonteEntrada => fonteEntrada.Type))
                                                 .ForMember(destino => destino.Date, opt => opt.MapFrom(fonteEntrada => ConvertToDateTime(fonteEntrada.Date)))
                                                 .ForMember(destino => destino.Amount, opt => opt.MapFrom(fonteEntrada => decimal.Parse(fonteEntrada.Amount, CultureInfo.InvariantCulture)))
                                                 .ForMember(destino => destino.Name, opt => opt.MapFrom(fonteEntrada => fonteEntrada.Name))
                                                 ;

        }
        private static DateTime ConvertToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString.Replace("[-03:EST]", ""), "yyyyMMddHHmmss", new CultureInfo("pt-BR"));
        }
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

    }
}