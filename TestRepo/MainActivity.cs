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
            var recipientField = FindViewById<EditText>(Resource.Id.recipientField);
            var callButton = FindViewById<Button>(Resource.Id.Call);
            var contentsField = FindViewById<EditText>(Resource.Id.contentsField);
            //translateButton.Click += (object sender, EventArgs e) =>
            //{
            //    String parsedNr = "";
            //    String toParseNumber = phoneNumber.Text;
            //    foreach (char letter in toParseNumber)
            //    {
            //        char upperedLetter = Char.ToUpper(letter);
            //        switch (upperedLetter)
            //        {
            //            case 'A': case 'B': case 'C':
            //                {
            //                    parsedNr += "2";
            //                    break;
            //                }
            //            case 'M': case 'N': case 'O':
            //                {
            //                    parsedNr += "6";
            //                    break;
            //                }
            //            case 'D': case 'E': case 'F':
            //                {
            //                    parsedNr += "3";
            //                    break;
            //                }
            //            case 'G': case 'H': case 'I':
            //                {
            //                    parsedNr += "4";
            //                    break;
            //                }
            //            case 'J': case 'K': case 'L':
            //                {
            //                    parsedNr += "5";
            //                    break;
            //                }
            //            case 'P': case 'Q': case 'R': case 'S':
            //                {
            //                    parsedNr += "7";
            //                    break;
            //                }
            //            case 'T': case 'U': case 'V':
            //                {
            //                    parsedNr += "8";
            //                    break;
            //                }
            //            case 'W': case 'X': case 'Y': case 'Z':
            //                {
            //                    parsedNr += "9";
            //                    break;
            //                }
            //            default:
            //                {
            //                    parsedNr += letter;
            //                    break;
            //                }
            //        }       
            //    }
            //    phoneNumberTranslate.Text = parsedNr;
            //};
            callButton.Click += (object sender, EventArgs e) =>
            {
                String recipient = recipientField.Text;
                String contents = contentsField.Text;
             

                int n;
                if (recipient.Contains("@"))
                {
                    if(contents.Length != 0)
                    {
                        var email = new Intent(Intent.ActionSend);
                        email.PutExtra(Intent.ExtraEmail, recipient);
                        email.PutExtra(Intent.ExtraText, contents);
                        email.PutExtra(Intent.ExtraSubject, "Hi");
                        email.SetType("message/rfc822");
                        StartActivity(email);
                    }
                }
                else if (Int32.TryParse(recipient, out n))
                {
                    if (contents.Length != 0)
                    {
                        var smsUri = Android.Net.Uri.Parse("smsto:" + recipient);
                        var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                        smsIntent.PutExtra("sms_body", contents);
                        StartActivity(smsIntent);
                    }
                    else
                    {
                        var callIntent = new Intent(Intent.ActionCall);
                        callIntent.SetData(Android.Net.Uri.Parse("tel:" + recipient));
                        StartActivity(callIntent);
                    }
                }

                //var email = new Intent(Intent.ActionSend);
                //email.PutExtra(Intent.ExtraEmail, "wlodek14a@gmail.com");
                //email.PutExtra(Intent.ExtraText, "Message");
                //email.PutExtra(Intent.ExtraSubject, "Hi");
                //email.SetType("message/rfc822");
                //StartActivity(email);

            };

            //translateButton.Click += TranslateButton_Click;


        }

        //private void TranslateButton_Click(object sender, System.EventArgs e)
        //{
            
        //    throw new System.NotImplementedException();
        //}
    }
}

