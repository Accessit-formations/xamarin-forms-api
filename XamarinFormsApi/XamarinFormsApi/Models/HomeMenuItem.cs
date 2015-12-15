using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsApi.Models
{
    class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.Speak;
        }

        public string Icon { get; set; }

        public MenuType MenuType { get; set; }
    }
}
