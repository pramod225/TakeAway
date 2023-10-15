using System.Windows.Input;


namespace TakeAway.Resuable;
public partial class CustomFrame : ContentView
{
	public CustomFrame()
	{
		InitializeComponent();
	}
    private int number = 0;
    private bool isFilled = false;
    public event EventHandler ItemSelectedClicked;
    #region Binding Properties
    //public ImageSource HeartImageSource
    //{
    //    get => (ImageSource)GetValue(HeartImageSourceProperty);
    //    set => SetValue(HeartImageSourceProperty, value);
    //}
    private void OnHeartButtonClicked(object sender, EventArgs e)
    {
        isFilled = !isFilled;
        string imageSource = isFilled ? "heart.png" : "heart_fill.png";
        heartButton.Source = imageSource;
    }

    private void OnStarButtonClicked(object sender , EventArgs e)
    {
        if (number < 5)
        {
            number++;

            // Update the label with the new number
            numberLabel.Text = number.ToString();
        }
    }
    //public static readonly BindableProperty HeartImageSourceProperty =
    //                                BindableProperty.Create(
    //                                nameof(HeartImageSource),
    //                                typeof(ImageSource),
    //                                typeof(CustomFrame),
    //                                default(ImageSource), BindingMode.OneWay);

    public ImageSource CompassImageSource
    {
        get => (ImageSource)GetValue(AddressImageSourceProperty);
        set => SetValue(AddressImageSourceProperty, value);
    }

    public static readonly BindableProperty AddressImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(CompassImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomFrame),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource AlarmImageSource
    {
        get => (ImageSource)GetValue(AlarmImageSourceProperty);
        set => SetValue(AlarmImageSourceProperty, value);
    }

    public static readonly BindableProperty AlarmImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(AlarmImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomFrame),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource VectorImageSource
    {
        get => (ImageSource)GetValue(VectorImageSourceProperty);
        set => SetValue(VectorImageSourceProperty, value);
    }

    public static readonly BindableProperty VectorImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(VectorImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomFrame),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource StarImageSource
    {
        get => (ImageSource)GetValue(StarImageSourceProperty);
        set => SetValue(StarImageSourceProperty, value);
    }

    public static readonly BindableProperty StarImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(StarImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomFrame),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource MainImageSource
    {
        get => (ImageSource)GetValue(MainImageSourceProperty);
        set => SetValue(MainImageSourceProperty, value);
    }

    public static readonly BindableProperty MainImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(MainImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomFrame),
                                    default(ImageSource), BindingMode.OneWay);

    public string MainText
    {
        get => (string)GetValue(MainTextProperty);
        set => SetValue(MainTextProperty, value);
    }

    public static readonly BindableProperty MainTextProperty =
                                  BindableProperty.Create(
                                  nameof(MainText),
                                  typeof(string),
                                  typeof(CustomFrame),
                                  string.Empty, BindingMode.OneWay);


    public string AddressText
    {
        get => (string)GetValue(AddressTextProperty);
        set => SetValue(AddressTextProperty, value);
    }

    public static readonly BindableProperty AddressTextProperty =
                                  BindableProperty.Create(
                                  nameof(AddressText),
                                  typeof(string),
                                  typeof(CustomFrame),
                                  string.Empty, BindingMode.OneWay);

    public string LeftText
    {
        get => (string)GetValue(LeftTextProperty);
        set => SetValue(LeftTextProperty, value);
    }

    public static readonly BindableProperty LeftTextProperty =
                                  BindableProperty.Create(
                                  nameof(LeftText),
                                  typeof(string),
                                  typeof(CustomFrame),
                                  string.Empty, BindingMode.OneWay);

    public string CenterText
    {
        get => (string)GetValue(CenterTextProperty);
        set => SetValue(CenterTextProperty, value);
    }

    public static readonly BindableProperty CenterTextProperty =
                                  BindableProperty.Create(
                                  nameof(CenterText),
                                  typeof(string),
                                  typeof(CustomFrame),
                                  string.Empty, BindingMode.OneWay);

    public string RightText
    {
        get => (string)GetValue(RightTextProperty);
        set => SetValue(RightTextProperty, value);
    }

    public static readonly BindableProperty RightTextProperty =
                                  BindableProperty.Create(
                                  nameof(RightText),
                                  typeof(string),
                                  typeof(CustomFrame),
                                  string.Empty, BindingMode.OneWay);

    public ICommand ItemSelectedCommand
    {
        get => (ICommand)GetValue(ItemSelectedCommandProperty);
        set => SetValue(ItemSelectedCommandProperty, value);
    }

    public static readonly BindableProperty ItemSelectedCommandProperty =
    BindableProperty.Create(nameof(ItemSelectedCommand),
                            typeof(ICommand),
                            typeof(CustomFrame),
                            default(ICommand));

    #endregion

    #region ToggleButton for favourite
    private ICommand _toggleCommand;
    private Image _toggleImage;

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomFrame), null);

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomFrame), null);

    public static readonly BindableProperty CheckedProperty =
        BindableProperty.Create("Checked", typeof(bool), typeof(CustomFrame), false, BindingMode.TwoWay,
            null, propertyChanged: OnCheckedChanged);

    public static readonly BindableProperty AnimateProperty =
        BindableProperty.Create(nameof(Animate), typeof(bool), typeof(CustomFrame), false);

    public static readonly BindableProperty CheckedImageProperty =
        BindableProperty.Create(
            nameof(CheckedImage),
            typeof(ImageSource),
            typeof(CustomFrame),
            null);

    public static readonly BindableProperty UnCheckedImageProperty =
        BindableProperty.Create(nameof(UnCheckedImage), typeof(ImageSource), typeof(CustomFrame), null);

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public object CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public bool Checked
    {
        get { return (bool)GetValue(CheckedProperty); }
        set { SetValue(CheckedProperty, value); }
    }

    public bool Animate
    {
        get { return (bool)GetValue(AnimateProperty); }
        set { SetValue(CheckedProperty, value); }
    }

    public ImageSource CheckedImage
    {
        get { return (ImageSource)GetValue(CheckedImageProperty); }
        set { SetValue(CheckedImageProperty, value); }
    }

    public ImageSource UnCheckedImage
    {
        get { return (ImageSource)GetValue(UnCheckedImageProperty); }
        set { SetValue(UnCheckedImageProperty, value); }
    }

    public ICommand ToogleCommand
    {
        get
        {
            return _toggleCommand
                   ?? (_toggleCommand = new Command(() =>
                   {
                       if (Checked)
                       {
                           Checked = false;
                       }
                       else
                       {
                           Checked = true;
                       }

                       if (Command != null)
                       {
                           Command.Execute(CommandParameter);
                       }
                   }));
        }
    }

    //private void Initialize()
    //{
    //    _toggleImage = new Image();

    //    Animate = true;

    //    GestureRecognizers.Add(new TapGestureRecognizer
    //    {
    //        Command = ToogleCommand
    //    });

    //    _toggleImage.Source = UnCheckedImage;
    //    Content = _toggleImage;
    //}

    //protected override void OnParentSet()
    //{
    //    base.OnParentSet();
    //    _toggleImage.Source = UnCheckedImage;
    //    Content = _toggleImage;
    //}

    private static async void OnCheckedChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var toggleButton = (CustomFrame)bindable;

        if (Equals(newValue, null) && !Equals(oldValue, null))
            return;

        if (toggleButton.Checked)
        {
            toggleButton._toggleImage.Source = toggleButton.CheckedImage;
        }
        else
        {
            toggleButton._toggleImage.Source = toggleButton.UnCheckedImage;
        }

        toggleButton.Content = toggleButton._toggleImage;

        if (toggleButton.Animate)
        {
            await toggleButton.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await toggleButton.ScaleTo(1, 50, Easing.Linear);
        }
    }
    void ItemSelectedTapped(object sender, EventArgs e)
    {
        ItemSelectedClicked?.Invoke(sender, e);
    }
    #endregion

}
