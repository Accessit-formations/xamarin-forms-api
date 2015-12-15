using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormsApi.Dependencies;

namespace XamarinFormsApi.Views
{
    public partial class SpeakPage
    {
        public SpeakPage()
        {
            InitializeComponent();

            SpeakButton.Clicked += (sender, args) => DependencyService.Get<ITextToSpeech>().Speak(SpeakEntry.Text);
        }
    }
}
