using System;
using CatsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Services.CatsService
{
	public interface ICatsService
	{

        Task<List<CatModel>> GetAllCats();


        Task<CatModel?> GetCat(int id);


        Task<List<CatModel>> AddCat(CatCreateDto cat);


        Task<List<CatModel>?> UpdateCat(int id, CatModel request);


        Task<List<CatModel>?> DeleteCat(int id);



    }


}

