using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace Lego_Ninjago
{
    public partial class NinjaDetailWindow : Window
    {
        private readonly Ninja _ninja;
        private readonly string _asmName;

        public NinjaDetailWindow(Ninja ninja, string asmName)
        {
            InitializeComponent();
            _ninja = ninja;
            _asmName = asmName;

            TxtTitle.Text = _ninja.Name;
            TxtElement.Text = $"Element: {_ninja.Element}";
            ListAbilities.ItemsSource = _ninja.Abilities;
            ListStrengths.ItemsSource = _ninja.Strengths;

            TryLoadImage(_ninja);

            BtnBack.Click += (_, __) => Close();
            
            BtnChoose.Click += (_, __) =>
            {
                try
                {
                    var win = new WeaponsWindow(_ninja);
                    win.Show(); 
                    
                    Close();
                }
                catch (Exception ex)
                {
                    new Window
                    {
                        Title = "Navigation error",
                        Width = 500,
                        Height = 260,
                        Content = new ScrollViewer
                        {
                            Content = new TextBlock
                            {
                                Text = ex.ToString(),
                                TextWrapping = Avalonia.Media.TextWrapping.Wrap
                            }
                        }
                    }.Show();
                }
            }; // ← fehlte vorher
        }

        private void TryLoadImage(Ninja n)
        {
            var name = n.Name.ToUpperInvariant();
            foreach (var ext in new[] { ".webp", ".png", ".jpg", ".jpeg" })
            {
                var uri = new Uri($"avares://{_asmName}/Ninjapic/{name}{ext}");
                try
                {
                    if (AssetLoader.Exists(uri))
                    {
                        using var s = AssetLoader.Open(uri);
                        ImgDetail.Source = new Bitmap(s);
                        return;
                    }
                }
                catch { }
            }
        }
    }
}
