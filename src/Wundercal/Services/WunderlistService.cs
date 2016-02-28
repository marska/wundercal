using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Wundercal.Services.Dto;

namespace Wundercal.Services
{
  public class WunderlistService : IWunderlistService
  {
    private readonly HttpClient _httpClient = new HttpClient();

    public WunderlistService(string accessToken, string clientId)
    {
      _httpClient.BaseAddress = new Uri("https://a.wunderlist.com/api/v1/");
      _httpClient.DefaultRequestHeaders.Accept.Clear();
      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      _httpClient.DefaultRequestHeaders.Add("X-Access-Token", accessToken);
      _httpClient.DefaultRequestHeaders.Add("X-Client-ID", clientId);
    }

    public int CreateTask(int listId, string title, DateTime dueDate)
    {
      var param = JsonConvert.SerializeObject(new { list_id = listId, title = title, due_date = dueDate });

      HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");
      var response = _httpClient.PostAsync("tasks", content).Result;

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception(response.StatusCode.ToString());
      }

      var task = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, new {id = 0});

      return task.id;
    }

    public int CreateReminder(int taskId, DateTime date)
    {
      var param = JsonConvert.SerializeObject(new { task_id = taskId, date = date });

      HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");
      var response = _httpClient.PostAsync("reminders", content).Result;

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception(response.StatusCode.ToString());
      }

      var reminder = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, new { id = 0 });

      return reminder.id;
    }

    public int GetListId(string name)
    {
      var result = 0;

      var response = _httpClient.GetAsync("lists").Result;

      if (response.IsSuccessStatusCode)
      {
        var responseString = response.Content.ReadAsStringAsync().Result;

        var wunderlistLists = JsonConvert.DeserializeObject<List<WunderlistList>>(responseString);

        result = wunderlistLists.First(l => l.Title == name).Id;
      }

      return result;
    }
  }
}