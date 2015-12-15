using AVFoundation;
using Xamarin.Forms;
using XamarinFormsApi.Dependencies;
using XamarinFormsApi.iOS.Dependencies;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace XamarinFormsApi.iOS.Dependencies
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation()
        {
            
        }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("fr-FR"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}