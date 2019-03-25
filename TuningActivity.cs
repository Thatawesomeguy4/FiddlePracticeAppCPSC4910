
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FidLinn
{
    [Activity(Label = "TuningActivity")]
    public class TuningActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tuning);


            // Create your application here

            Button backButton = FindViewById<Button>(Resource.Id.backButton);

            backButton.Click += delegate { BackButtonHandler(); };
        }
        private void BackButtonHandler()
        {
            SetContentView(Resource.Layout.MainPageLayout);
        }

    }
}
