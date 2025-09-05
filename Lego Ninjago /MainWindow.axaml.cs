using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Lego_Ninjago
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, Ninja> _ninjas;
        private readonly string[] _order = { "COLE", "JAY", "LLOYD", "KAI", "ZANE" };
        private int _index = 0;

        private static readonly string[] ImageExts = { ".webp", ".png", ".jpg", ".jpeg" };
        private readonly string _asmName;

        public MainWindow()
        {
            InitializeComponent();

            _asmName = Assembly.GetExecutingAssembly().GetName().Name!;
            _ninjas = NinjaService.BuildAll();

            BtnPrev.Click += (_, __) => ShowPrev();
            BtnNext.Click += (_, __) => ShowNext();
            BtnDone.Click += (_, __) => ShowChoose();

            KeyDown += (_, e) =>
            {
                if (e.Key == Key.Left) ShowPrev();
                if (e.Key == Key.Right) ShowNext();
            };

            ShowCurrent();
        }

        private void ShowPrev()
        {
            _index = (_index - 1 + _order.Length) % _order.Length;
            ShowCurrent();
        }

        private void ShowNext()
        {
            _index = (_index + 1) % _order.Length;
            ShowCurrent();
        }

        private void ShowCurrent()
        {
            var key = _order[_index];
            using var stream = TryOpenImageStream(_asmName, key, out _);
            if (stream != null)
                ImgNinja.Source = new Bitmap(stream);
            
            BtnDone.IsVisible = _index == _order.Length - 1;
        }

        private void ShowChoose()
        {
            SlideshowView.IsVisible = false;
            ChooseView.IsVisible = true;
        }

        private static Stream? TryOpenImageStream(string asmName, string name, out Uri? foundUri)
        {
            foreach (var ext in ImageExts)
            {
                var uri = new Uri($"avares://{asmName}/Ninjapic/{name}{ext}");
                try
                {
                    if (AssetLoader.Exists(uri))
                    {
                        foundUri = uri;
                        return AssetLoader.Open(uri);
                    }
                }
                catch { }
            }
            foundUri = null;
            return null;
        }
    }
}
