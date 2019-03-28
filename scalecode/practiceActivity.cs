
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FidLinn
{
    [Activity(Label = "PracticeActivity")]
    public class PracticeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Practice);

            RadioButton radioButton1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton radioButton2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            RadioButton radioButton3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            RadioButton radioButton4 = FindViewById<RadioButton>(Resource.Id.radioButton4);
            RadioButton radioButton5 = FindViewById<RadioButton>(Resource.Id.radioButton5);
            RadioButton radioButton6 = FindViewById<RadioButton>(Resource.Id.radioButton6);
            RadioButton radioButton7 = FindViewById<RadioButton>(Resource.Id.radioButton7);
            RadioButton radioButton8 = FindViewById<RadioButton>(Resource.Id.radioButton8);
            RadioButton radioButton9 = FindViewById<RadioButton>(Resource.Id.radioButton9);
            RadioButton radioButton10 = FindViewById<RadioButton>(Resource.Id.radioButton10);
            RadioButton radioButton11 = FindViewById<RadioButton>(Resource.Id.radioButton11);
            RadioButton radioButton12 = FindViewById<RadioButton>(Resource.Id.radioButton12);
            RadioButton radioButton13 = FindViewById<RadioButton>(Resource.Id.radioButton13);
            RadioButton radioButton14 = FindViewById<RadioButton>(Resource.Id.radioButton14);
            RadioButton radioButton15 = FindViewById<RadioButton>(Resource.Id.radioButton15);
            RadioButton radioButton16 = FindViewById<RadioButton>(Resource.Id.radioButton16);
            RadioButton radioButton17 = FindViewById<RadioButton>(Resource.Id.radioButton17);
            RadioButton radioButton18 = FindViewById<RadioButton>(Resource.Id.radioButton18);

            RadioGroup radioGroup1 = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            RadioGroup radioGroup2 = FindViewById<RadioGroup>(Resource.Id.radioGroup2);

            Button myButton1 = FindViewById<Button>(Resource.Id.myButton1);
            Button myButton2 = FindViewById<Button>(Resource.Id.myButton2);
            Button myButton3 = FindViewById<Button>(Resource.Id.myButton3);
            


        }

        private void myButton3_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.MainPageLayout);
        }


        private void myButton2_Click(object sender, EventArgs e)
        {
            RadioButton radioButton1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton radioButton2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            RadioButton radioButton3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            RadioButton radioButton4 = FindViewById<RadioButton>(Resource.Id.radioButton4);
            RadioButton radioButton12 = FindViewById<RadioButton>(Resource.Id.radioButton12);

            RadioButton radioButton5 = FindViewById<RadioButton>(Resource.Id.radioButton5);
            RadioButton radioButton6 = FindViewById<RadioButton>(Resource.Id.radioButton6);
            RadioButton radioButton7 = FindViewById<RadioButton>(Resource.Id.radioButton7);
            RadioButton radioButton8 = FindViewById<RadioButton>(Resource.Id.radioButton8);
            RadioButton radioButton9 = FindViewById<RadioButton>(Resource.Id.radioButton9);
            RadioButton radioButton10 = FindViewById<RadioButton>(Resource.Id.radioButton10);
            RadioButton radioButton11 = FindViewById<RadioButton>(Resource.Id.radioButton11);
            RadioButton radioButton13 = FindViewById<RadioButton>(Resource.Id.radioButton13);
            RadioButton radioButton14 = FindViewById<RadioButton>(Resource.Id.radioButton14);
            RadioButton radioButton15 = FindViewById<RadioButton>(Resource.Id.radioButton15);
            RadioButton radioButton16 = FindViewById<RadioButton>(Resource.Id.radioButton16);
            RadioButton radioButton17 = FindViewById<RadioButton>(Resource.Id.radioButton17);
            RadioButton radioButton18 = FindViewById<RadioButton>(Resource.Id.radioButton18);

            EditText resultBox = FindViewById<EditText>(Resource.Id.resultBox);
            int type1 = 0;
            if (radioButton1.Checked)
            {
                type1 = 1;
            }
            else if (radioButton2.Checked)
            {
                type1 = 2;
            }
            else if (radioButton3.Checked)
            {
                type1 = 3;
            }
            else if (radioButton4.Checked)
            {
                type1 = 4;
            }
            else if (radioButton12.Checked)
            {
                type1 = 5;
            }
            else
            {
                resultBox.Text = "Choose a Type";
            }


            string name = "";


            if (radioButton5.Checked)
            {
                name = "Low A";
            }
            else if (radioButton6.Checked)
            {
                name = "Low B";
            }
            else if (radioButton7.Checked)
            {
                name = "Low C";
            }
            else if (radioButton8.Checked)
            {
                name = "Low/Open D";
            }
            else if (radioButton9.Checked)
            {
                name = "Low E";
            }
            else if (radioButton10.Checked)
            {
                name = "Low F";
            }
            else if (radioButton11.Checked)
            {
                name = "Mid G";
            }
            else if (radioButton13.Checked)
            {
                name = "Low Ab";
            }
            else if (radioButton14.Checked)
            {
                name = "Low Bb";
            }
            else if (radioButton15.Checked)
            {
                name = "Low C#";

            }
            else if (radioButton16.Checked)
            {
                name = "Low Eb";
            }
            else if (radioButton17.Checked)
            {
                name = "Low F#";
            }
            else if (radioButton18.Checked)
            {
                name = "Low G#";
            }
            else
            {
                resultBox.Text = "Choose a Key";

            }

            Scales play = new Scales(name, type1);
            List<Note> finalScale = play.buildScale();

            foreach (Note note in finalScale)
            {
                note.playNote(note);
                resultBox.Text = note.name+"Played With"+ note.finger+note.stringName;
            }
        }



        public class ScalesTest
        {



            public static void Main()
            {
                Scales example = new Scales("Low A", 5);
                //when you make a new Scales, use name of first note, not scale name
                //for example ("Low C",1) means major scale that starts on low c
                //signify scale type with int
                // example.playScale(example.buildScale());
                //Scales chromatic = new Scales("Low/Open D", 3);
                //chromatic.buildScale();



#if DEBUG

                //Console.WriteLine("done");
               // Console.ReadLine();

#endif
            }
        }


        public class Scales
        {




            public string scaleName;

            public int scaleType;
            //1=diatonic major,2=diatonic minor,3=chromatic,4=pentatonic major,5=pentatonic minor



            public Scales(string name, int Type)
            {

                scaleName = name;
                scaleType = Type;
            }

            public List<Note> buildScale()
            {
                //this is the finger chart
                //each first position note has a number assigned
                //Ab on G string is 1, each note is one greater, B on E string is 28
                //entry zero is open G (lowest note)
                var fingerChart = new List<string>()
            { "Low/Open G",
                "Low Ab","Low A","Low Bb","Low B","Low C","Low C#","Low/Open D",
                "Low Eb","Low E","Low F","Low F#","Mid G","Low G#","Mid/Open A",
                "Mid Bb","Mid B","Mid C","Mid C#","Mid D","Mid Eb","Mid/Open E",
                "High F","High F#","High G","High G#","High A","High Bb","High B"

            };

                int startNote = 0;
                int i = 0;
                //look for a match in the list and get index/start value
                fingerChart.ForEach(x =>
                {
                    if (x.Equals(scaleName))
                    {
                        startNote = i;

                    }
                    i++;
                });


                var builtScale = new List<Note>();
                //will hold finished scale
                int whole = 2;
                int half = 1;
                //will be determined from parameter, for now assuming c major
                int nowNote = startNote;
                int count = 1;

                if (scaleName == "" || scaleType == 0)
                {
                    //do nothing if parameters not received
                    return builtScale;
                }
                //major scales
                if (scaleType == 1)
                {
                   // Console.WriteLine("{0} Major Scale", scaleName.Substring((scaleName.Length) - 2));
                    //major scale
                    while (count <= 8)
                    {
                        if (count == 1)
                        {
                            Note thisNote = new Note(fingerChart[startNote], startNote);
                            builtScale.Add(thisNote);
                            //  Console.WriteLine(thisNote.name);
                            //    Console.WriteLine(thisNote.position);
                        }
                        else if (count == 4 || count == 8)
                        {
                            nowNote = nowNote + half;
                            Note thisNote = new Note(fingerChart[nowNote], nowNote);
                            builtScale.Add(thisNote);
                            //  Console.WriteLine(thisNote.name);
                            //    Console.WriteLine(thisNote.position);
                        }
                        else
                        {
                            nowNote = nowNote + whole;
                            Note madeNote = new Note(fingerChart[nowNote], nowNote);
                            builtScale.Add(madeNote);

                            // Console.WriteLine(madeNote.name);
                            //   Console.WriteLine(madeNote.position);
                        }

                        count++;
                    }


                }

                else if (scaleType == 2)
                {
                    //Console.WriteLine("{0} Minor Scale", scaleName.Substring((scaleName.Length) - 2));
                    //natural minor scale

                    while (count <= 8)
                    {
                        if (count == 1)
                        {
                            Note thisNote = new Note(fingerChart[startNote], startNote);
                            builtScale.Add(thisNote);
                            //  Console.WriteLine(thisNote.name);
                            //    Console.WriteLine(thisNote.position);
                        }
                        else if (count == 3 || count == 6)
                        {
                            nowNote = nowNote + half;
                            Note thisNote = new Note(fingerChart[nowNote], nowNote);
                            builtScale.Add(thisNote);
                            //  Console.WriteLine(thisNote.name);
                            //    Console.WriteLine(thisNote.position);
                        }
                        else
                        {
                            nowNote = nowNote + whole;
                            Note madeNote = new Note(fingerChart[nowNote], nowNote);
                            builtScale.Add(madeNote);

                            //  Console.WriteLine(madeNote.name);
                            //    Console.WriteLine(madeNote.position);
                        }

                        count++;
                    }





                }


                else if (scaleType == 3)
                {
                   // Console.WriteLine("{0} Chromatic Scale", scaleName.Substring((scaleName.Length) - 2));
                    //chromatic scale, every note

                    while (count <= 13)
                    {

                        Note thisNote = new Note(fingerChart[nowNote], nowNote);
                        builtScale.Add(thisNote);
                        //   Console.WriteLine(thisNote.name);
                        //     Console.WriteLine(thisNote.position);
                        nowNote = nowNote + half;

                        count++;
                    }





                }

                if (scaleType == 4)
                {
                   // Console.WriteLine("{0} Pentatonic Major Scale", scaleName.Substring((scaleName.Length) - 2));
                    //pentatonic major scale
                    while (count <= 8)
                    {
                        if (count == 1)
                        {
                            Note thisNote = new Note(fingerChart[startNote], startNote);
                            builtScale.Add(thisNote);
                            // Console.WriteLine(thisNote.name);
                            //   Console.WriteLine(thisNote.position);
                        }
                        else if (count == 4 || count == 8 || count == 7)
                        {
                            if (count == 8)
                            {
                                nowNote = nowNote + half;
                                Note thisNote = new Note(fingerChart[nowNote], nowNote);
                                builtScale.Add(thisNote);
                                //Console.WriteLine(thisNote.name);
                                // Console.WriteLine(thisNote.position);
                            }
                            else
                            {
                                nowNote = nowNote + half;
                            }
                        }
                        else
                        {
                            nowNote = nowNote + whole;
                            Note madeNote = new Note(fingerChart[nowNote], nowNote);
                            builtScale.Add(madeNote);

                            //Console.WriteLine(madeNote.name);
                            // Console.WriteLine(madeNote.position);
                        }

                        count++;
                    }


                }


                else if (scaleType == 5)
                {
                    //Console.WriteLine("{0} Pentatonic Minor Scale", scaleName.Substring((scaleName.Length) - 2));
                    //pentatonic minor scale

                    while (count <= 8)
                    {
                        if (count == 1)
                        {
                            Note thisNote = new Note(fingerChart[startNote], startNote);
                            builtScale.Add(thisNote);
                            //Console.WriteLine(thisNote.name);
                            //  Console.WriteLine(thisNote.position);
                        }
                        else if (count == 3 || count == 6)
                        {
                            nowNote = nowNote + half;
                            if (count == 3)
                            {
                                Note thisNote = new Note(fingerChart[nowNote], nowNote);
                                builtScale.Add(thisNote);
                                //Console.WriteLine(thisNote.name);
                                //Console.WriteLine(thisNote.position);
                            }


                        }
                        else
                        {
                            nowNote = nowNote + whole;
                            if (count == 4 || count == 5 || count == 7)
                            {
                                Note madeNote = new Note(fingerChart[nowNote], nowNote);
                                builtScale.Add(madeNote);

                                //  Console.WriteLine(madeNote.name);
                                //Console.WriteLine(madeNote.position);
                            }
                        }

                        count++;
                    }





                }



                return builtScale;
            }





        }


        public class Note
        {

            public string name { get; set; }

            public int position { get; set; }

            public string stringName { get; set; }

            public string finger { get; set; }

            public Note(string n, int p)
            {
                name = n;
                position = p;

            }

            public async void playNote(Note note)
            {


                //lookup position and match to according finger
                await Task.Delay(3000);
                stringName = "";
                 finger = "";
                if (note.position == 0)
                {
                    stringName = "G String";
                    finger = "Open";
                }
                else if (note.position < 7)
                {
                    stringName = "G String";
                }
                else if (note.position == 7)
                {
                    stringName = "Open D String or G String 4th Finger";
                }
                else if (note.position < 14)
                {
                    stringName = "D String";
                }
                else if (note.position == 14)
                {
                    stringName = "Open A String or D String 4th Finger";
                }
                else if (note.position < 21)
                {
                    stringName = "A String";
                }
                else if (note.position == 21)
                {
                    stringName = "Open E String or A String 4th Finger ";
                }
                else if (note.position <= 28)
                {
                    stringName = "E String";
                    if (note.position == 28)
                    {
                        finger = "4th finger";
                    }
                }

                if (note.position == 1 || note.position == 8 ||
                    note.position == 15 || note.position == 22)
                {
                    finger = "First Finger (Low)";
                }
                if (note.position == 2 || note.position == 9
                    || note.position == 16 || note.position == 23)
                {
                    finger = "First Finger";
                }
                else if ((note.position == 3 || note.position == 10 ||
                  note.position == 17 || note.position == 24))
                {
                    finger = "Second Finger (Low)";
                }
                else if ((note.position == 4 || note.position == 11 ||
                   note.position == 18 || note.position == 25))
                {
                    finger = "Second Finger";
                }
                else if (note.position == 5 || note.position == 12 || note.position == 19 || note.position == 26)
                {
                    finger = "Third Finger";
                }
                else if (note.position == 6 || note.position == 13 || note.position == 20 || note.position == 27)
                {
                    finger = "Third Finger (High) or Fourth Finger (Low)";
                }


                //Console.WriteLine("Note Name: {0} Location: {1} {2}", note.name, stringName, finger);
                



            }


        }

    }



}