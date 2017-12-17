using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace TestRepo
{
    [Activity(Label = "Sender", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //EditText phoneNumber = (Resource.Id.PhoneNumber);
        //EditText phoneNumberTranslate = FindViewById<EditText>(Resource.Id.PhoneNumberTranslated);
        //Button translateButton = FindViewById<Button>(Resource.Id.Translate);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            // Set our view from the "main" layout resource
            var phoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumber);
            var phoneNumberTranslate = FindViewById<EditText>(Resource.Id.PhoneNumberTranslated);
            var translateButton = FindViewById<Button>(Resource.Id.Translate);
            var callButton = FindViewById<Button>(Resource.Id.Call);

            translateButton.Click += (object sender, EventArgs e) =>
            {
                String parsedNr = "";
                String toParseNumber = phoneNumber.Text;
                foreach (char letter in toParseNumber)
                {
                    char upperedLetter = Char.ToUpper(letter);
                    switch (upperedLetter)
                    {
                        case 'A': case 'B': case 'C':
                            {
                                parsedNr += "2";
                                break;
                            }
                        case 'M': case 'N': case 'O':
                            {
                                parsedNr += "6";
                                break;
                            }
                        case 'D': case 'E': case 'F':
                            {
                                parsedNr += "3";
                                break;
                            }
                        case 'G': case 'H': case 'I':
                            {
                                parsedNr += "4";
                                break;
                            }
                        case 'J': case 'K': case 'L':
                            {
                                parsedNr += "5";
                                break;
                            }
                        case 'P': case 'Q': case 'R': case 'S':
                            {
                                parsedNr += "7";
                                break;
                            }
                        case 'T': case 'U': case 'V':
                            {
                                parsedNr += "8";
                                break;
                            }
                        case 'W': case 'X': case 'Y': case 'Z':
                            {
                                parsedNr += "9";
                                break;
                            }
                        default:
                            {
                                parsedNr += letter;
                                break;
                            }
                    }       
                }
                

                phoneNumberTranslate.Text = parsedNr;
            };
            callButton.Click += (object sender, EventArgs e) =>
            {
                //String translatedNumber = phoneNumberTranslate.Text;
                //var callIntent = new Intent(Intent.ActionCall);
                //callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
                //StartActivity(callIntent);

                //var smsUri = Android.Net.Uri.Parse("smsto:605483342");
                //var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                //smsIntent.PutExtra("sms_body", "Hello from Xamarin.Android");
                //StartActivity(smsIntent);

                var email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, "wlodek14a@gmail.com");
                email.PutExtra(Intent.ExtraText, "Message");
                email.PutExtra(Intent.ExtraSubject, "Hi");
                email.SetType("message/rfc822");
                StartActivity(email);

            };

            //translateButton.Click += TranslateButton_Click;


        }

        //private void TranslateButton_Click(object sender, System.EventArgs e)
        //{
            
        //    throw new System.NotImplementedException();
        //}
    }
}

