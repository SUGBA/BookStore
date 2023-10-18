using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Auth.Dto;
using BookStore.Auth.Entity;
using BookStore.Catalog.Dto;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.News.Entity;

namespace BookStore.Data.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<StoreEntity, CatalogDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(ent => ent.Book.Name))
                .ForMember(dto => dto.PathToImage, opt => opt.MapFrom(ent => ent.Book.PathToImage))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(ent => ent.Book.Price))
                .ForMember(dto => dto.PageCount, opt => opt.MapFrom(ent => ent.Book.PageCount))
                .ForMember(dto => dto.Genre, opt => opt.MapFrom(ent => ent.Book.Genre))
                .ForMember(dto => dto.DepartmentsAddress, opt => opt.MapFrom(ent => ent.Book.Departments.Select(x => x.Address)))
                .ForMember(dto => dto.BookCount, opt => opt.MapFrom(ent => ent.BookCount));

            CreateMap<UserEntity, LoginUserDto>();

            CreateMap<NewsEntity, NewsDto>();
        }
    }
}
