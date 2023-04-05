using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EGMTraning.UI.ActionFilters
{
    public class ExceptionlogFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionMessage = context.Exception.Message;
            var stackTrace = context.Exception.StackTrace;
            var controllerName = context.RouteData.Values["controller"].ToString();
            var actionName = context.RouteData.Values["action"].ToString();

            var message = "Date:" + DateTime.Now.ToString("dd-MM-yyy hh:mm tt") +" Error Message: "+ exceptionMessage + Environment.NewLine + " Stack Trace: "+ stackTrace;

            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo = null;

            string logFilePath = @"D:\\Ertug\\Ertug2\\UdemyEgitmen\\EgmTraning\";
            logFilePath = logFilePath +"Log - "+DateTime.Today.ToString("dd-MM-yyyy")+".txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo= new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists)
                logDirInfo.Create();
            if (!logDirInfo.Exists)
                fileStream= logFileInfo.Create();
            else
                fileStream = new FileStream(logFilePath, FileMode.Append);


            log = new StreamWriter(fileStream);
            log.WriteLine("----------- Start-----------");
            log.WriteAsync("Log Created at - "+DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") + "Controller Name "+controllerName + "Action : "+actionName+" Message:- " + message);
            log.WriteLine("----------- End-----------");
            log.Close();

            //TODO: Reditect
            context.Result = new RedirectResult("/Error/Index");
            base.OnException(context);
        }
    }
}
