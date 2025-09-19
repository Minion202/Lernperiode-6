using Avalonia.Controls;
using Avalonia.Controls.Primitives;   // ToggleButton
using Avalonia.Layout;
using System.Collections.Generic;

namespace Lego_Ninjago
{
    public partial class WeaponsWindow : Window
    {
        public Ninja SelectedNinja { get; }
        private readonly List<ToggleButton> _buttons = new();

        public WeaponsWindow(Ninja ninja)
        {
            InitializeComponent();    // muss zuerst kommen
            SelectedNinja = ninja;

            TxtHeader.Text = $"Select Weapons for {SelectedNinja.Name}";

            foreach (var w in WeaponService.GetDefaultSix())
            {
                var card = new ToggleButton
                {
                    Content = new StackPanel
                    {
                        Spacing = 4,
                        Children =
                        {
                            new TextBlock { Text = w.Name, FontWeight = Avalonia.Media.FontWeight.SemiBold, HorizontalAlignment = HorizontalAlignment.Center },
                            new TextBlock { Text = w.Description, TextWrapping = Avalonia.Media.TextWrapping.Wrap, HorizontalAlignment = HorizontalAlignment.Center, Opacity = 0.9 }
                        }
                    },
                    Width = 200,
                    Height = 100,
                    Margin = new Avalonia.Thickness(8)
                };
                WeaponPanel.Children.Add(card);
                _buttons.Add(card);
            }

            BtnConfirm.Click += (_, __) => Close();
            BtnCancel.Click  += (_, __) => Close();
        }
    }
}