using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SalesOfPharmacy
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;

                MessageBox.Show("Whoops! Please contact the developers with "
                   + "the following information:\n\n" + ex.Message + ex.StackTrace,
                   "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                Application.Exit();
            }
        }

        public static void Application_ThreadException
          (object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Abort;
            try
            {
                result = MessageBox.Show("Whoops! Please contact the developers "
                  + "with the following information:\n\n" + e.Exception.Message
                  + e.Exception.StackTrace, "Application Error",
                  MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            }
            finally
            {
                if (result == DialogResult.Abort)
                {
                    Application.Exit();
                }
            }
        }

        public static void DoWithWait(Action act, String message = "Идет сбор информации. Ожидайте...")
        {
            fWait f = new fWait(message);
            f.Show();
            f.Refresh();

            TimeSpan startTime = DateTime.Now.TimeOfDay;
            f.Do(act);
            TimeSpan ebdTime = DateTime.Now.TimeOfDay;

            f.Close();
            f.Dispose();
        }
    }
}
