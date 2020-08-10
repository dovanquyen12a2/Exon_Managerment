using MetroFramework.Forms;
using System.Threading;
using System.Windows.Forms;

namespace EXON.Common
{
    public partial class SplashScreenManager : MetroForm
    {
        private static Thread thread;
        public SplashScreenManager()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private delegate void CloseDelegate();

        private static SplashScreenManager splashForm;

        static public void ShowSplashScreen()
        {
            if (splashForm != null)
                return;
            if (thread == null || !thread.IsAlive) thread = new Thread(new ThreadStart(SplashScreenManager.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.MTA);
            thread.Start();
        }

        static private void ShowForm()
        {
            splashForm = new SplashScreenManager();
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            Thread.Sleep(200);
            if (splashForm != null)
                splashForm.Invoke(new CloseDelegate(SplashScreenManager.CloseFormInternal));

            while (thread != null && thread.IsAlive)
                thread.Abort();
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
            splashForm = null;
        }
    }
}