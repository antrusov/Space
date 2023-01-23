using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Space
{
    public class Logger
    {
        public static void Err(object msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger((new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().DeclaringType).Error(msg);
            log4net.LogManager.Shutdown();
        }

        public static void Dbg(object msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger((new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().DeclaringType).Debug(msg);
            log4net.LogManager.Shutdown();
        }

        public static void Info(object msg)
        {
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger((new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().DeclaringType).Info(msg);
            log4net.LogManager.Shutdown();
        }

        public static void Err(object msg, Exception _error)
        {
            log4net.Config.XmlConfigurator.Configure();
            LogManager.GetLogger((new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().DeclaringType).Error(msg, _error);
            log4net.LogManager.Shutdown();
        }
    }
}
