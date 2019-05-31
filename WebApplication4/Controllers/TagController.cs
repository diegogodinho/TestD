using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Service;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Authorize]
    public class TagController : BaseController
    {
        private readonly ITagService service;
        private readonly IMapper mapper;

        public TagController(ITagService service, IMapper mapper, IHttpContextAccessor accessor) : base(accessor)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TagModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<Tag>(model);
                var userId = GetUserID();
                entity.UserID = userId;
                service.SaveTag(entity);
                return View("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult GetTagsJson(RequestGrid model)
        {

            var userId = GetUserID();

            var data = service.GetTasksPaginated(model, userId);


            List<TagListViewModel> response = mapper.Map<List<TagListViewModel>>(data);
            return Ok(ConvertGridViewModel<TagListViewModel>(response.ToArray(), model));
        }

        [HttpPost]
        public IActionResult UpdateTag(int idTag)
        {
            return null;
            
        }
    }
}