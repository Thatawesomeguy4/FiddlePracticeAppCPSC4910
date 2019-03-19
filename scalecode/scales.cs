using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalesCode
{

    public class ScalesTest
    {


        public static void Main()
        {
            Scales example = new Scales("Low A",5);
            //when you make a new Scales, use name of first note, not scale name
            //for example ("Low C",1) means major scale that starts on low c
            //signify scale type with int
            example.playScale(example.buildScale());
            //Scales chromatic = new Scales("Low/Open D", 3);
            //chromatic.buildScale();



#if DEBUG

           //Console.WriteLine("done");
            Console.ReadLine();

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

        public  List<Note> buildScale()
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

            int startNote=0;
            int i = 0;
            //look for a match in the list and get index/start value
            fingerChart.ForEach(x => {
                if (x.Equals(scaleName))
                {
                    startNote =i;
              
                }
                i++;
            }  );


            var builtScale = new List<Note>();
            //will hold finished scale
            int whole = 2;
            int half = 1;
            //will be determined from parameter, for now assuming c major
            int nowNote=startNote;
            int count = 1;
            //major scales
            if (scaleType == 1)
            {
                Console.WriteLine("{0} Major Scale", scaleName.Substring((scaleName.Length)-2));
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
                    else if(count==4 || count == 8)
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
                Console.WriteLine("{0} Minor Scale", scaleName.Substring((scaleName.Length) - 2));
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
                Console.WriteLine("{0} Chromatic Scale", scaleName.Substring((scaleName.Length) - 2));
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
                Console.WriteLine("{0} Pentatonic Major Scale", scaleName.Substring((scaleName.Length) - 2));
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
                        if (count == 8) { 
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
                Console.WriteLine("{0} Pentatonic Minor Scale", scaleName.Substring((scaleName.Length) - 2));
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
                        if (count == 4 || count == 5 || count == 7) { 
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

        public async void playScale(List<Note> scale)
        {
            //lookup position and match to according finger
            foreach(Note note in scale)
            {
                string stringName = "";
                string finger = "";
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
                else if (note.position ==14)
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

                if(note.position==1|| note.position==8||
                    note.position==15|| note.position == 22 )
                {
                    finger = "First Finger (Low)";
                }
                if (note.position == 2 || note.position == 9
                    || note.position == 16 || note.position == 23)
                {
                    finger = "First Finger";
                }
                else if((note.position == 3 || note.position == 10 ||
                  note.position == 17 || note.position ==24 ) )
                {
                    finger = "Second Finger (Low)";
                }
                else if (( note.position == 4 || note.position == 11 ||
                   note.position == 18 || note.position == 25))
                {
                    finger = "Second Finger";
                }
                else if(note.position == 5 || note.position == 12 || note.position == 19 || note.position == 26)
                {
                    finger = "Third Finger";
                }
                else if (note.position == 6 || note.position == 13 || note.position == 20 || note.position == 27)
                {
                    finger = "Third Finger (High) or Fourth Finger (Low)";
                }


                Console.WriteLine("Note Name: {0} Location: {1} {2}", note.name,stringName, finger );
                await Task.Delay(2000);
            }

        }



    }

    public class Note
    {

        public string name { get; set; }
      
        public int position { get; set; }
     


        public Note(string n, int p)
        {
            name = n;
            position = p;

        }


    }

   

   
}