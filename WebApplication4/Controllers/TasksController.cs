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
    public class TasksController : BaseController
    {
        private readonly ITaskService service;
        private readonly IMapper mapper;

        public TasksController(ITaskService service, IMapper mapper, IHttpContextAccessor accessor) : base(accessor)
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
                var entity = mapper.Map<Domain.Entities.Tasks>(model);
                var userId = GetUserID();
                entity.UserID = userId;
                entity.LastChange = DateTime.Now;
                service.Add(entity);
                return View("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTagsJson(RequestGrid model)
        {
            List<TagListViewModel> response = mapper.Map<List<TagListViewModel>>(await service.GetPaginatedAsync(model, GetUserID()));
            return Ok(ConvertGridViewModel<TagListViewModel>(response.ToArray(), model));
        }

        [HttpPost]
        public IActionResult UpdateTask(int idTag)
        {
            try
            {
                service.UpdateStatus(idTag);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}