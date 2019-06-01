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

        [HttpGet]
        public async Task<IActionResult> GetTagsJson(RequestGrid model)
        {
            List<TasksListViewModel> response = mapper.Map<List<TasksListViewModel>>(await service.GetPaginatedAsync(model, GetUserID()));
            return Ok(ConvertGridViewModel<TasksListViewModel>(response.ToArray(), model));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = mapper.Map<Tasks>(model);
                entity.UserID = GetUserID();
                service.Add(entity);
                return View("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tasks taskmodel = service.Get(id, GetUserID());
            if (taskmodel == null)
                return RedirectToAction("Index");
            return View(mapper.Map<TaskModelEdit>(taskmodel));
        }

        [HttpPost]
        public IActionResult Edit(TaskModelEdit model)
        {
            if (ModelState.IsValid)
            {
                Tasks tasks = mapper.Map<Tasks>(model);
                service.Update(tasks, GetUserID());
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        [HttpPost]
        public IActionResult CheckTask(int taskID)
        {
            try
            {
                service.UpdateStatus(taskID, GetUserID());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            service.Delete(id, GetUserID());
            return Ok();
        }
    }
}