using Microsoft.AspNetCore.Mvc;
using SampleAPI.Data.Queries;
using SampleAPI.Domain;
using System.Collections.Generic;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly BaseQuery _queryService;

        public CourseController(BaseQuery queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _queryService.GetCourseInformation().coursesList;
        }
    }
}
