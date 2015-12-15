using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormsApi.Models;
using XamarinFormsApi.ViewModels;

namespace XamarinFormsApi.Views
{
    public partial class MenuPage : ContentPage
    {
        readonly RootPage _root;

        public MenuPage(RootPage root)
        {
            List<HomeMenuItem> menuItems;
            _root = root;
            InitializeComponent();


            BindingContext = new BaseViewModel
            {
                Title = "Xamarin Forms Api",
                Icon = "slideout.png"
            };

            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Title = "Speak", MenuType = MenuType.Speak, Icon ="speak.png" }

            };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await _root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
            };
        }
    }
}
