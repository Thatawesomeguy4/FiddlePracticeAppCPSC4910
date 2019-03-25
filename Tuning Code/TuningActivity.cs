
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.SimpleAudioPlayer;

namespace FidLinn
{


    [Activity(Label = "TuningActivity")]
    public class TuningActivity : Activity
    {
        ISimpleAudioPlayer Gplayer;
        ISimpleAudioPlayer Dplayer;
        ISimpleAudioPlayer Aplayer;
        ISimpleAudioPlayer Eplayer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tuning);

            Gplayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Dplayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Aplayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Eplayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

            Gplayer.Load(Assets.Open("Audio/G10sec.wav"));
            Dplayer.Load(Assets.Open("Audio/D10sec.wav"));
            Aplayer.Load(Assets.Open("Audio/A10sec.wav"));
            Eplayer.Load(Assets.Open("Audio/E10sec.wav"));

            Button Gbutton = FindViewById<Android.Widget.Button>(Resource.Id.aButton);
            Button Dbutton = FindViewById<Android.Widget.Button>(Resource.Id.bButton);
            Button Abutton = FindViewById<Android.Widget.Button>(Resource.Id.cButton);
            Button Ebutton = FindViewById<Android.Widget.Button>(Resource.Id.dButton);
            Button ALLbutton = FindViewById<Android.Widget.Button>(Resource.Id.playButton);
            Button backButton = FindViewById<Android.Widget.Button>(Resource.Id.backButton);

            Gbutton.Click += delegate { playSound("g"); };
            Dbutton.Click += delegate { playSound("d"); };
            Abutton.Click += delegate { playSound("a"); };
            Ebutton.Click += delegate { playSound("e"); };
            ALLbutton.Click += delegate { playSound("all"); };
            backButton.Click += delegate { StartActivity(typeof(MainActivity)); };


        }

        public void playSound(String sound)
        {
            if (Gplayer.IsPlaying || Dplayer.IsPlaying || Aplayer.IsPlaying || Eplayer.IsPlaying)
            {
                //do nothing, we only want 1 playing at a time.
            }
            else
            {
                if (sound.Equals("g"))
                {
                    Gplayer.Play();
                }
                else if (sound.Equals("d"))
                {
                    Dplayer.Play();
                }
                else if (sound.Equals("a"))
                {
                    Aplayer.Play();
                }
                else if (sound.Equals("e"))
                {
                    Eplayer.Play();
                }
                else
                {
                    Gplayer.Play();
                    Dplayer.Play();
                    Aplayer.Play();
                    Eplayer.Play();
                }
            }
        }

    }
}
