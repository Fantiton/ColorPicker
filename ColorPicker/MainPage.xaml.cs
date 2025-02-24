namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int RedValue = 0;
        int GreenValue = 0;
        int BlueValue = 0;
        private DebounceDispatcher debounceDispatcher = new DebounceDispatcher();
        public MainPage()
        {
            InitializeComponent();
        }
        private void RedSliderMoved(object sender, ValueChangedEventArgs e)
        {
            int newValue = (int)e.NewValue;
            RedLabel.Text = $"Red Value: {newValue}";
            RedValue = newValue;
            BackgroundRepaint();
        }

        private void GreenSliderMoved(object sender, ValueChangedEventArgs e)
        {
            int newValue = (int)e.NewValue;
            GreenLabel.Text = $"Green Value: {newValue}";
            GreenValue = newValue;
            BackgroundRepaint();
        }

        private void BlueSliderMoved(object sender, ValueChangedEventArgs e)
        {
            int newValue = (int)e.NewValue;
            BlueLabel.Text = $"Blue Value: {newValue}";
            BlueValue = newValue;
            BackgroundRepaint();
        }

        private void BackgroundRepaint()
        {
            Color newColor = Color.FromRgb(RedValue, GreenValue, BlueValue);
            BackgroundColor = newColor;
            ColorFrame.BackgroundColor = newColor;
            ColorLabel.BackgroundColor = newColor;
            ColorLabel.Text = $"#{RedValue:X2}{GreenValue:X2}{BlueValue:X2}";
        }

        private async void OnLabelTapped(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                await Clipboard.SetTextAsync(label.Text);
                await DisplayAlert("Skopiowano", "Wartość została skopiowana do schowka", "OK");
            }
        }

        private void RandomColor(object sender, EventArgs e)
        {
            Random random = new Random();
            RedValue = random.Next(0, 256);
            GreenValue = random.Next(0, 256);
            BlueValue = random.Next(0, 256);
            RedSlider.Value = RedValue;
            GreenSlider.Value = GreenValue;
            BlueSlider.Value = BlueValue;
            RandomColorButton.BackgroundColor = Color.FromRgb(RedValue, GreenValue, BlueValue);
            BackgroundRepaint();
        }

        
    }

}
