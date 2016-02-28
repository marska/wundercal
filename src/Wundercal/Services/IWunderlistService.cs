using System;

namespace Wundercal.Services
{
  internal interface IWunderlistService
  {
    int CreateTask(int listId, string title, DateTime dueDate);

    int CreateReminder(int taskId, DateTime date);

    int GetListId(string name);
  }
}