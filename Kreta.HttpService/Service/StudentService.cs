using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                try
                {
                    List<StudentDto>? resultDto = await _httpClient.GetFromJsonAsync<List<StudentDto>>("api/Student");
                    if (resultDto is not null)
                    {
                        List<Student> result = resultDto.Select(studentDto => studentDto.ToStudent()).ToList();
                        return result;
                    }
                } catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return new List<Student>();
        }

        public async Task<ControllerResponse> UpdateAsync(Student student)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {
                    StudentDto studentDto = student.ToStudentDto();
                    HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync("api/Student", studentDto);
                    if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        ControllerResponse? response = JsonConvert.DeserializeObject<ControllerResponse>(content);
                        if (response is null)
                        {
                            defaultResponse.ClearAndAddError("A törlés http kérés hibát okozott!");
                        }
                        else return response;
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                    else
                    {
                        return defaultResponse;
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }

        public async Task<ControllerResponse> DeleteAsync(Guid id)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }


        public async Task<ControllerResponse> InsertAsync(Student student)
        {
            ControllerResponse defaultResponse = new();
            if (_httpClient is not null)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            defaultResponse.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return defaultResponse;
        }
    }
}
