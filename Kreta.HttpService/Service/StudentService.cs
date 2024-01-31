using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Kreta.HttpService.Service
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient? _httpClient;

        public StudentService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("KretaApi");
            }
        }

        public async Task<List<Student>> SelectAllStudentAsync()
        {
            if (_httpClient is not null)
            {
                List<StudentDto>? resultDto = await _httpClient.GetFromJsonAsync<List<StudentDto>>("api/Student");
                if (resultDto is not null)
                {
                    List<Student> result = new List<Student>();
                    foreach(StudentDto studentDto in resultDto)
                    {
                        result.Add(studentDto);
                    }

                }
            }
            return new List<Student>();
        }

        public async Task<ControllerResponse> Update(StudentDto studentDto)
        {
            ControllerResponse defaultResponse = new();
            return defaultResponse;
        }

        public async Task<ControllerResponse> DeleteAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            return defaultResponse;
        }


        public async Task<ControllerResponse> InsertAsync(Student student)
        {
            ControllerResponse defaultResponse = new();
            return defaultResponse;
        }
    }
}
