using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Android.Media;

namespace Metrooo
{
    [Activity(Label = "Metrooo")]
    public partial class MetronomeActivity : Activity
    {
        
        MediaPlayer tikSound;       //tikSound file
        MediaPlayer tokSound;       //tokSound file
        private const int MAX_BPM = 280;
        private const int MIN_BPM = 30;
        private Multimedia.Timer _timer;
        private System.Threading.Thread tickThread;
        private int bpm;
        private float interval = 1000;
        private int[] measureArray = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
        private int measure = 0;
        private int measureCount = 0;
        private bool isStart = false;
        private bool soundOn = true;        
        private int defaultBPM = 60;        //need to implement a properties/settings or something that will store BPM between sessions... temporary solution
        private int defaultMeasure = 0;     //same as above


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MetroNome);

            
            tikSound = MediaPlayer.Create(this, Resource.Raw.tik);
            tokSound = MediaPlayer.Create(this, Resource.Raw.tok);

            var playButton = FindViewById<Button>(Resource.Id.startButton);
            var stopButton = FindViewById<Button>(Resource.Id.stopButton);

            var bpmIn = FindViewById<Button>(Resource.Id.bpmInButton);
            var bpmSub = FindViewById<Button>(Resource.Id.bpmSubButton);

            playButton.Click += delegate
            {
                //_player.Start();
                startBtn_Click(null, null);
            };
            stopButton.Click += delegate
            {
                //_player.Stop();
                stopBtn_Click(null, null);
            };
            bpmIn.Click += delegate
            {
                bpmIn_Click(null, null);
            };
            bpmSub.Click += delegate
            {
                bpmSub_Click(null, null);
            };


        }
        public MetronomeActivity()
        {
            _timer = new Multimedia.Timer();
            _timer.Period = 250;
            _timer.Tick += _timer_Tick;
            System.Threading.Thread thisThread = System.Threading.Thread.CurrentThread;
            thisThread.Priority = System.Threading.ThreadPriority.AboveNormal;
            
            bpm = defaultBPM;
            measure = defaultMeasure;
            Button btn1 = FindViewById<Button>(Resource.Id.bpmButton2);
            btn1.Text = bpm.ToString();
            tikSound = MediaPlayer.Create(this, Resource.Raw.tik);      
            tokSound = MediaPlayer.Create(this, Resource.Raw.tok);
            interval = 1000 * (60f / bpm);

            

        }

        // Timer tick event
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (measureCount >= measureArray[measure]) { measureCount = 0; }
            measureCount++;
            tickThread.Start();
            if (soundOn)
            {
                if (measureCount == 1) { tikSound.Start(); }
                else { tokSound.Start(); }
            }
        }

        // Start metronome
        private void startBtn_Click(object sender, EventArgs e)
        {
            if (!isStart)
            {
                _timer.Period = (int)interval;
                _timer.Start();
                isStart = true;
                _timer_Tick(null, null);
            }

        }
        // Stop metronome
        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (isStart)
            {
                _timer.Stop();
                isStart = false;
                measureCount = 0;
            }
        }

        // Incresing BPM
        private void bpmIn_Click(object sender, EventArgs e)
        {
            bpm++;
            if (bpm >= MAX_BPM) { bpm = MAX_BPM; }
            Button btnC = FindViewById<Button>(Resource.Id.bpmButton2);
            btnC.Text = bpm.ToString();
            changeInterval();
        }
        // Subtract BPM
        private void bpmSub_Click(object sender, EventArgs e)
        {
            bpm--;
            if (bpm <= MIN_BPM) { bpm = MIN_BPM; }
            Button btnC = FindViewById<Button>(Resource.Id.bpmButton2);
            btnC.Text = bpm.ToString();
            changeInterval();
        }
        // Change the interval
        private void changeInterval()
        {
            interval = 1000 * (60f / bpm);
            if (isStart)
            {
                _timer.Period = (int)interval;
            }
            defaultBPM = bpm;
            //removed Save setting method as no longer saving any user settings anyways
        }
    }
}