﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Logging;
using SampleAPI.Configurations;
using SampleAPI.Domain;
using System;
using System.Collections.Generic;

namespace SampleAPI.Data.Repositories
{
    public sealed class Repository : BaseRepository
    {
		private readonly string _dbServiceUrl;
		private readonly string _dbTableName;

		public Repository(DbConfiguration dbConf, ILoggerFactory logger) : base(logger)
        {
			_dbServiceUrl = dbConf.ServiceURL;
			_dbTableName = dbConf.TableName;
			_logger = logger.CreateLogger("Repository");
        } 

		private AmazonDynamoDBClient GetDbClient()
        {
            if (!String.IsNullOrEmpty(_dbServiceUrl))
            {
                AmazonDynamoDBClient client;

                AmazonDynamoDBConfig ddbConfig = new AmazonDynamoDBConfig()
                {
                    ServiceURL = _dbServiceUrl
                };
                client = new AmazonDynamoDBClient(ddbConfig);
                return client;
            }
            else
            {
                throw new Exception("No database URL has been provided!");
            }
        }

        private ScanResponse ScanAllItems(AmazonDynamoDBClient client)
        {
            ScanRequest request = new ScanRequest
            {
                TableName = _dbTableName,
            };

            try
            {
                var response = client.ScanAsync(request);
                ScanResponse result = response.Result;
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError("Unable to scan items: " + e.Message);
                return null;
            }
        }

        private void AddAllCoursesToCourseList(ScanResponse response)
        {
            if(response != null)
            {
                foreach (Dictionary<string, AttributeValue> item in response.Items)
                {
                    Course course = new Course(item["title"].S, item["category"].S, item["instructor"].S, item["description"].S, new List<Video>());
                    _courses.Add(course);
                }
            }
            else
            {
                throw new Exception("No retrieved courses to add.");
            }
        }

        public override List<Course> GetCourses()
        {
            try
            {
                AmazonDynamoDBClient client = GetDbClient();
                ScanResponse result = ScanAllItems(client);
                AddAllCoursesToCourseList(result);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return _courses;
        }
    }
}
