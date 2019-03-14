using Android.Content.Res;
using Plugin.SimpleAudioPlayer;
using Android.Content;

namespace FiddleYourself
{
    class BrainTunerMedia
    {

        public ISimpleAudioPlayer GPlayer;
        public ISimpleAudioPlayer DPlayer;
        public ISimpleAudioPlayer APlayer;
        public ISimpleAudioPlayer EPlayer;
        public Context content;

        //default constructor to load audio assets
        public BrainTunerMedia()
        {
            //create audio players
            this.GPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            this.DPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            this.APlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            this.EPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

            //get the local context into our variable
            this.content = Android.App.Application.Context;

            //create asset manager
            AssetManager assetManager = this.content.Assets;

            //load audio files using the asset manager
            this.GPlayer.Load(assetManager.Open("Gravity Falls.mp3"));
            this.DPlayer.Load(assetManager.Open("Gravity Falls.mp3"));
            this.APlayer.Load(assetManager.Open("Gravity Falls.mp3"));
            this.EPlayer.Load(assetManager.Open("Gravity Falls.mp3"));
        }

    }
}
