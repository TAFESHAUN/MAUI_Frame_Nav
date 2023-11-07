namespace MAUI_Frame_Nav
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 450;
            const int newHeight = 750;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}