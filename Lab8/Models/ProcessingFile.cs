using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

namespace Lab8.Models
{
    public class ProcessingFile
    {
        public static void SaveFile(string path, List<ObservableCollection<DailyTask>> tasks)
        {
            File.WriteAllText(path, "");
            List<string> data = new List<string>();
            foreach (ObservableCollection<DailyTask> taskList in tasks)
            {
                foreach (DailyTask task in taskList)
                {
                    data.Add(task.Status);
                    data.Add(task.Header);
                    data.Add(task.MainText);
                    data.Add(task.ImagePath);
                }
                data.Add("");
            }
            File.WriteAllLines(path, data);
        }

        public static List<ObservableCollection<DailyTask>> LoadFile(string path)
        {
            List<ObservableCollection<DailyTask>> tasks = new List<ObservableCollection<DailyTask>>
            {
                new ObservableCollection<DailyTask>(),
                new ObservableCollection<DailyTask>(),
                new ObservableCollection<DailyTask>()
            };

            StreamReader file = new StreamReader(path);

            for (int i = 0; i < tasks.Count(); i++)
            {
                ObservableCollection<DailyTask> tmp = new ObservableCollection<DailyTask>();
                while (true)
                {
                    string status = file.ReadLine();
                    if (status == "")
                        break;
                    string header = file.ReadLine();
                    string text = file.ReadLine();
                    string imagePath = file.ReadLine();

                    tmp.Add(new DailyTask(status, header, text, imagePath));
                }
                tasks[i] = tmp;
            }
            file.Close();
            return tasks;
        }
    }
}