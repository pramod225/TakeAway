using System.Windows.Input;

namespace TakeAway.Resuable;

public partial class CustomDetailsView : ContentView
{
    public event EventHandler ItemSelectedClicked;
    #region Binding Properties
    public ImageSource HeartImageSource
    {
        get => (ImageSource)GetValue(HeartImageSourceProperty);
        set => SetValue(HeartImageSourceProperty, value);
    }

    public static readonly BindableProperty HeartImageSourceProperty =
                                  BindableProperty.Create(
                                  nameof(HeartImageSource),
                                  typeof(ImageSource),
                                  typeof(CustomDetailsView),
                                  default(ImageSource), BindingMode.OneWay);

    public Color FrameBackGroundColor
    {
        get => (Color)GetValue(FrameBackGroundColorProperty);
        set => SetValue(FrameBackGroundColorProperty, value);
    }



    public static readonly BindableProperty FrameBackGroundColorProperty =
                                    BindableProperty.Create(
                                    nameof(FrameBackGroundColor),
                                    typeof(Color),
                                    typeof(CustomDetailsView),
                                    default(Color), BindingMode.OneWay);

    public string IncrementOrDecrementText
    {
        get => (string)GetValue(IncrementOrDecrementTextProperty);
        set => SetValue(IncrementOrDecrementTextProperty, value);
    }

    public static readonly BindableProperty IncrementOrDecrementTextProperty =
                                    BindableProperty.Create(
                                    nameof(IncrementOrDecrementText),
                                    typeof(string),
                                    typeof(CustomDetailsView),
                                    string.Empty, BindingMode.OneWay);

    public ImageSource AlarmImageSource
    {
        get => (ImageSource)GetValue(AlarmImageSourceProperty);
        set => SetValue(AlarmImageSourceProperty, value);
    }

    public static readonly BindableProperty AlarmImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(AlarmImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomDetailsView),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource PlusImageSource
    {
        get => (ImageSource)GetValue(PlusImageSourceProperty);
        set => SetValue(PlusImageSourceProperty, value);
    }

    public static readonly BindableProperty PlusImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(PlusImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomDetailsView),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource MinusImageSource
    {
        get => (ImageSource)GetValue(MinusImageSourceProperty);
        set => SetValue(MinusImageSourceProperty, value);
    }

    public static readonly BindableProperty MinusImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(MinusImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomDetailsView),
                                    default(ImageSource), BindingMode.OneWay);

    public ImageSource VegorNonImageSource
    {
        get => (ImageSource)GetValue(VegorNonImageSourceProperty);
        set => SetValue(VegorNonImageSourceProperty, value);
    }

    public static readonly BindableProperty VegorNonImageSourceProperty =
                                    BindableProperty.Create(
                                    nameof(VegorNonImageSource),
                                    typeof(ImageSource),
                                    typeof(CustomDetailsView),
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
                                    typeof(CustomDetailsView),
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
                                    typeof(CustomDetailsView),
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
                                  typeof(CustomDetailsView),
                                  string.Empty, BindingMode.OneWay);


    public string DescriptionText
    {
        get => (string)GetValue(DescriptionTextProperty);
        set => SetValue(DescriptionTextProperty, value);
    }

    public static readonly BindableProperty DescriptionTextProperty =
                                  BindableProperty.Create(
                                  nameof(DescriptionText),
                                  typeof(string),
                                  typeof(CustomDetailsView),
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
                                  typeof(CustomDetailsView),
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
                                  typeof(CustomDetailsView),
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
                                  typeof(CustomDetailsView),
                                  string.Empty, BindingMode.OneWay);

    public ICommand ItemSelectedCommand
    {
        get => (ICommand)GetValue(ItemSelectedCommandProperty);
        set => SetValue(ItemSelectedCommandProperty, value);
    }

    public static readonly BindableProperty ItemSelectedCommandProperty =
    BindableProperty.Create(nameof(ItemSelectedCommand),
                            typeof(ICommand),
                            typeof(CustomDetailsView),
                            default(ICommand));

    #endregion
    public CustomDetailsView()
    {
        InitializeComponent();
    }
    void ItemSelectedTapped(object sender, EventArgs e)
    {
        ItemSelectedClicked?.Invoke(sender, e);
    }
}
