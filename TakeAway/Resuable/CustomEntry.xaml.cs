namespace TakeAway.Resuable;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntry : ContentView
    {
    public event EventHandler<TextChangedEventArgs> TextChanged;
    private const int PlaceholderFontSize = 18;
    private const int FloatFontSize = 12;
    private const int TopMargin = -24;
    private const int LeftMargin = 4;
    

    #region BindingProperties
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(CustomEntry),
        string.Empty,
        BindingMode.TwoWay,
        null,
        HandleBindingPropertyChangedDelegate);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    public static readonly BindableProperty TextColorProperty =
      BindableProperty.Create(nameof(TextColor),
                              typeof(Color),
                              typeof(CustomEntry),
                              Colors.Black,
                              defaultBindingMode: BindingMode.OneWay);
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder),
        typeof(string),
        typeof(CustomEntry),
        string.Empty,
        BindingMode.TwoWay);

    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }

    public static readonly BindableProperty IsValidationEnabledProperty =
       BindableProperty.Create(nameof(IsValidationEnabled),
                               typeof(bool),
                               typeof(CustomEntry),
                               false,
                               BindingMode.OneWay);
    public bool IsValidationEnabled
    {
        get { return (bool)GetValue(IsValidationEnabledProperty); }
        set { SetValue(IsValidationEnabledProperty, value); }
    }

    public bool IsEntryTextValid
    {
        get { return (bool)GetValue(IsEntryTextValidProperty); }
        set { SetValue(IsEntryTextValidProperty, value); }
    }
    public static readonly BindableProperty IsEntryTextValidProperty =
      BindableProperty.Create(nameof(IsEntryTextValid),
                              typeof(bool),
                              typeof(CustomEntry),
                              true);


    public ReturnType ReturnType
    {
        get { return (ReturnType)GetValue(ReturnTypeProperty); }
        set { SetValue(ReturnTypeProperty, value); }
    }

    public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
        nameof(ReturnType),
        typeof(ReturnType),
        typeof(CustomEntry),
        ReturnType.Default
        );

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
        nameof(Keyboard),
        typeof(Keyboard),
        typeof(CustomEntry),
        Keyboard.Default,
        coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

    public Keyboard Keyboard
    {
        get { return (Keyboard)GetValue(KeyboardProperty); }
        set { SetValue(KeyboardProperty, value); }
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword),
        typeof(bool),
        typeof(CustomEntry),
        default(bool));

    public bool IsPassword
    {
        get { return (bool)GetValue(IsPasswordProperty); }
        set { SetValue(IsPasswordProperty, value); }
    }

    public static readonly BindableProperty FloatingColorProperty = BindableProperty.Create(
        nameof(FloatingColor),
        typeof(Color),
        typeof(CustomEntry),
        Colors.Black);

    public Color FloatingColor
    {
        get { return (Color)GetValue(FloatingColorProperty); }
        set { SetValue(FloatingColorProperty, value); }
    }

    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
        nameof(Border),
        typeof(Color),
        typeof(CustomEntry),
        Colors.Black);

    public Color Border
    {
        get { return (Color)GetValue(BorderColorProperty); }
        set { SetValue(BorderColorProperty, value); }
    }


    #endregion
    private static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
    {
        if (!(bindable is CustomEntry control))
        {
            return;
        }

        if (control.InputControl.IsFocused)
        {
            return;
        }

        if (string.IsNullOrEmpty((string)newValue))
        {
            await control.TransitionToPlaceholder(false);
        }
        else
        {
            await control.TransitionToFloat(false);
        }
    }

    public CustomEntry()
    {
        InitializeComponent();

        _ = TransitionToPlaceholder(false);
    }

    private async Task TransitionToFloat(bool animated)
    {
        if (animated)
        {
            var t1 = PlaceholderControl.TranslateTo(LeftMargin, TopMargin, 100);
            var t2 = SizeTo(FloatFontSize);
            var t3 = ColorTo(FloatingColor);

            await Task.WhenAll(t1, t2, t3);
        }
        else
        {
            PlaceholderControl.TranslationX = LeftMargin;
            PlaceholderControl.TranslationY = TopMargin;
            PlaceholderControl.FontSize = FloatFontSize;
            PlaceholderControl.TextColor = FloatingColor;
        }
    }

    private async Task TransitionToPlaceholder(bool animated)
    {
        if (animated)
        {
            var t1 = PlaceholderControl.TranslateTo(LeftMargin, 0, 100);
            var t2 = SizeTo(PlaceholderFontSize);
            var t3 = ColorTo(InputControl.PlaceholderColor);

            await Task.WhenAll(t1, t2, t3);
        }
        else
        {
            PlaceholderControl.TranslationX = LeftMargin;
            PlaceholderControl.TranslationY = 0;
            PlaceholderControl.FontSize = PlaceholderFontSize;
            PlaceholderControl.TextColor = InputControl.PlaceholderColor;
        }
    }

    private async void Handle_Focused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            await TransitionToFloat(true);
        }
    }

    private async void Handle_Unfocused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            await TransitionToPlaceholder(true);
        }
    }

    public new void Focus()
    {
        if (IsEnabled)
        {
            InputControl.Focus();
        }
    }

    private Task SizeTo(int fontSize)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();
        var startingHeight = PlaceholderControl.FontSize;
        var endingHeight = fontSize;
        var rate = 5u;
        var length = 100u;

        PlaceholderControl.Animate("size", callback, startingHeight, endingHeight, rate, length, Easing.Linear, (v, c) => taskCompletionSource.SetResult(c));

        return taskCompletionSource.Task;

        void callback(double input)
        {
            PlaceholderControl.FontSize = input;
        }
    }

    private Task ColorTo(Color color)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();
        var startingColor = PlaceholderControl.TextColor;
        var endColor = color;
        var rate = 16u;
        var length = 4000u;

        var animation = new Animation(callback: v => PlaceholderControl.TextColor = color);

        PlaceholderControl.Animate("color", animation, rate, length, Easing.Linear, (v, c) => taskCompletionSource.SetResult(c));

        return taskCompletionSource.Task;
    }
}

