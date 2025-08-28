using Avalonia.Controls;
using System.Collections.Generic;

namespace Lego_Ninjago
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, Ninja> _ninjas;

        public MainWindow()
        {
            InitializeComponent();

            _ninjas = NinjaService.BuildAll();

            ToolTip.SetTip(BtnCole,  _ninjas["COLE"].BuildTooltip());
            ToolTip.SetTip(BtnJay,   _ninjas["JAY"].BuildTooltip());
            ToolTip.SetTip(BtnLloyd, _ninjas["LLOYD"].BuildTooltip());
            ToolTip.SetTip(BtnKai,   _ninjas["KAI"].BuildTooltip());
            ToolTip.SetTip(BtnZane,  _ninjas["ZANE"].BuildTooltip());
        }
    }
}