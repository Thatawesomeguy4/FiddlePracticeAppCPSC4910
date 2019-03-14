using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FiddleYourself
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //init media
        BrainTunerMedia brainTuner = new BrainTunerMedia();

        int count = 0;
        void Button_Clicked(object sender, System.EventArgs e)
        {
            count++;
            brainTuner.APlayer.Play();
            ((Button)sender).Text = $"You clicked {count} times.";
        }
    }
}
