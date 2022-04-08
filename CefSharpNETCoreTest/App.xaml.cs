using CefSharp;
using CefSharp.Wpf;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CefSharpNETCoreTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // https://github.com/cefsharp/CefSharp/issues/1714#issuecomment-227041722

        public App()
        {
            CefRuntime.SubscribeAnyCpuAssemblyResolver();

            //Any CefSharp references have to be in another method with NonInlining
            // attribute so the assembly rolver has time to do it's thing.
            InitializeCefSharp();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InitializeCefSharp()
        {
            var settings = new CefSettings();

            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
        }
    }
}
