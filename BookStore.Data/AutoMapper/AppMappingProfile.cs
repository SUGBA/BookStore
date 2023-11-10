using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Admin.Dto;
using BookStore.Admin.Entity;
using BookStore.Catalog.Dto;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.AdminDto;
using BookStore.Data.EntityDto.ContactDto;
using BookStore.Data.EntityDto.MainDto;
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

            #region Мап к базовому Dto

            CreateMap<UserEntity, BaseAdminItemDto>()
              .ForMember(dto => dto.ViewName, opt => opt.MapFrom(ent => ent.Name))
              .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id));

            CreateMap<StoreEntity, BaseAdminItemDto>()
              .ForMember(dto => dto.ViewName, opt => opt.MapFrom(ent => ent.Book.Name))
              .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id));

            CreateMap<NewsEntity, BaseAdminItemDto>()
              .ForMember(dto => dto.ViewName, opt => opt.MapFrom(ent => ent.Content))
              .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id));

            #endregion

            #region Мап к выбранному Dto

            CreateMap<UserEntity, AdminUserDto>()
                .ForMember(dto => dto.Role, opt => opt.MapFrom(ent => ent.Role))
                .ForMember(dto => dto.Login, opt => opt.MapFrom(ent => ent.Login))
                .ForMember(dto => dto.Password, opt => opt.MapFrom(ent => ent.Password))
                .ForMember(dto => dto.ViewName, opt => opt.MapFrom(ent => ent.Name))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id))
                .ReverseMap();

            CreateMap<NewsEntity, AdminNewsDto>()
                .ForMember(dto => dto.ViewName, opt => opt.MapFrom(ent => ent.Content))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id))
                .ReverseMap();

            CreateMap<StoreEntity, AdminCatalogDto>()
                .ForMember(dto => dto.Price, opt => opt.MapFrom(ent => ent.Book.Price))
                .ForMember(dto => dto.PageCount, opt => opt.MapFrom(ent => ent.Book.PageCount))
                .ForMember(dto => dto.Genre, opt => opt.MapFrom(ent => ent.Book.Genre))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(ent => ent.Department.Address))
                .ForMember(dto => dto.BookCount, opt => opt.MapFrom(ent => ent.BookCount))
                .ForMember(dto => dto.ViewName, opt => opt.MapFrom(ent => ent.Book.Name))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id))
                .ReverseMap();

            #endregion

            CreateMap<BookEntity, MainDto>();

            CreateMap<ManagerEntity, ContactDto>();

            CreateMap<NewsEntity, NewsDto>();
        }
    }
}
