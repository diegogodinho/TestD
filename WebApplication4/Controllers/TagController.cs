using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Contracts.Repository;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagRepository repository;

        public TagController(ITagRepository repository)
        {
            this.repository = repository;
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
                return View();

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult GetTagsJson(RequestGrid model)
        {
            List<TagModel> response = new List<TagModel>() {
                new TagModel
                {
                    Id = 1,
                    Name = "Tag 1"
                },
                new TagModel
                {
                    Id = 2,
                    Name = "Tag 2"
                },
                new TagModel
                {
                    Id = 3,
                    Name = "Tag 3"
                }
            };


            return Ok(new { data = response });
        }
    }
}