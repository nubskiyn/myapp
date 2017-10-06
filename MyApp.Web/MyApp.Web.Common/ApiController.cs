using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Core.Commands;
using MyApp.Core.Queries;

namespace MyApp.Web.Common
{
    public abstract class ApiController : Controller
    {
        protected IQueryDispatcher QueryDispatcher { get; set; }
        protected ICommandDispatcher CommandDispatcher { get; set; }

        // Imagine that there is a method that assigns values to these variables depending on
        // AcceptLanguage header or http://url?lang=x
        protected Guid RequestLanguageId { get; set; }
        protected Guid DefaultLanguageId { get; set; }

        protected ApiController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            QueryDispatcher = queryDispatcher;
            CommandDispatcher = commandDispatcher;
        }
    }
}