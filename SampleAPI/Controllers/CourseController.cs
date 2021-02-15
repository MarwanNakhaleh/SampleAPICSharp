using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleAPI.Data.Queries;
using SampleAPI.Domain;
using System;
using System.Collections.Generic;

namespace SampleAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly BaseQuery _queryService;
        private readonly ILogger _logger;

        public CourseController(BaseQuery queryService, ILoggerFactory logger)
        {
            _queryService = queryService;
            _logger = logger.CreateLogger("CourseController");
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            _logger.LogInformation("starting GET /api/v1/courses");
            try
            {
                return _queryService.GetCourseInformation().coursesList;
            } 
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return new List<Course>();
            }
        }
    }
}
