﻿using BookStore.Data.EntityDto.ContactDto;
using BookStore.Data.EntityDto.MainDto;

namespace BookStore.App.Services.Interfaces
{
    public interface IContactService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        Task<List<ContactDto>> CreateViewModel();
    }
}
