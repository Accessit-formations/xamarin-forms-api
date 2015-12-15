using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsApi.Models;
using XamarinFormsApi.ViewModels;

namespace XamarinFormsApi.Views
{
    public partial class RootPage
    {
        private Task _navigation;

        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
            {
                Title = "Accueil"
            };

            NavigateAsync(MenuType.Speak);
        }

        Dictionary<MenuType, NavigationPage> Pages { get; }

        public async Task NavigateAsync(MenuType id)
        {
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {
                    case MenuType.Speak:
                        Pages.Add(id, new NavigationPage(new SpeakPage()));
                        break;
                }
            }

            Page newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}
