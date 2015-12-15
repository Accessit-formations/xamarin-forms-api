using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using XamarinFormsApi.Dependencies;
using XamarinFormsApi.Uwp.Dependencies;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace XamarinFormsApi.Uwp.Dependencies
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation() { }

        public async void Speak(string text)
        {
            MediaElement mediaElement = new MediaElement();

            var synth = new SpeechSynthesizer();

            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
            await synth.SynthesizeTextToStreamAsync(text);
        }
    }
}