using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;
using Amazon.Util;
using System.IO;
namespace TestCoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var message = string.Empty;
            try
            {
                var instanceId = Amazon.Util.EC2InstanceMetadata.InstanceId;
                
                if (!string.IsNullOrWhiteSpace(instanceId))
                {
                    message = $"Intance Id is {instanceId}";
                }
                else
                {
                    message = $"Machine name is { System.Environment.MachineName}";
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            ViewBag.Message = message;
            return View();
        }

        public IActionResult Folders(string message = null)
        {
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);
            string[] files = System.IO.Directory.GetFiles(currentDirName);
            string[] directories = System.IO.Directory.GetDirectories(currentDirName);
            FoldersModel model = new FoldersModel()
            {
                CurrentDirectory = currentDirName,
                Files = files.ToList(),
                Folders=directories.ToList()
            };

            ViewBag.Message = message;


            return View(model);
        }
        [HttpPost]
        public IActionResult WriteToFile(string filePath)
        {
            var message = $"Logging to file: {DateTime.Now.ToString()}";
            try
            {
                using (var str = System.IO.File.Open(filePath, FileMode.Append))
                {
                    using(var streamWriter = new StreamWriter(str))
                    {
                        streamWriter.WriteLine(message);
                    }
                }
                    

            }
            catch (Exception ex)
            {
                message = $"Error: {ex.Message}";
            }


            return RedirectToAction("Folders", new { message = message });
        }




        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
