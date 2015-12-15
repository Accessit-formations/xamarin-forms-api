using Android.Speech.Tts;
using Java.Lang;
using Xamarin.Forms;
using XamarinFormsApi.Dependencies;
using XamarinFormsApi.Droid.Dependencies;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace XamarinFormsApi.Droid.Dependencies
{
    public class TextToSpeechImplementation : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speaker;
        string _toSpeak;

        public TextToSpeechImplementation() { }

        public void Speak(string text)
        {
            var ctx = Forms.Context; // useful for many Android SDK features
            _toSpeak = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(ctx, this);
            }
            else {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, "");
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, "");
            }
        }
        #endregion
    }
}