using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SampleAPI.Data.Queries;
using SampleAPI.Data.Repositories;
using SampleAPI.Models;
using SampleAPI.UnitTest.Mocks;
using System.Linq;
using Xunit;

namespace SampleAPI.UnitTest
{
    public class QueryUnitTests
    {
        private BaseRepository _dataRepository;
        private ILoggerFactory _logger;

        public QueryUnitTests()
        {
            _logger = new NullLoggerFactory();
            _dataRepository = new MockRepository(_logger);
        }

        [Fact]
        public void TestGetCoursesQuery()
        {
            Query queryService = new Query(_dataRepository, _logger);
            CourseModel allCourseData = queryService.GetCourseInformation();
            Assert.Equal("Baby's First Course", allCourseData.coursesList.FirstOrDefault(course => course.Title == "Baby's First Course").Title);
        }
    }
}
