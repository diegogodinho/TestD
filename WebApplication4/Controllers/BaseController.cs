using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpContextAccessor accessor;

        public BaseController(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }
        public GridViewModel<T> ConvertGridViewModel<T>(T[] data, RequestGrid model) where T : class
        {
            var result = new GridViewModel<T>
            {
                data = data,
                draw = model.draw,
                recordsTotal = model.Total,
                recordsFiltered = model.Total
            };
            return result;
        }

        public int GetUserID()
        {
            return int.Parse(accessor.HttpContext.User.FindFirst("UserID").Value);
        }

    }
}