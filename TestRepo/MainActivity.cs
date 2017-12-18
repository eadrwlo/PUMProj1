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
            var subjectField = FindViewById<EditText>(Resource.Id.subjectField);
            var clearRecipientField = FindViewById<Button>(Resource.Id.clearRecipientField);
            var clearContentsField = FindViewById<Button>(Resource.Id.clearContentsField);
            var clearSubjectField = FindViewById<Button>(Resource.Id.clearSubjectField);

            clearRecipientField.Click += (object sender, EventArgs e) =>
            {
                recipientField.Text = "";
            };

            clearContentsField.Click += (object sender, EventArgs e) =>
            {
                contentsField.Text = "";
            };

            clearSubjectField.Click += (object sender, EventArgs e) =>
            {
                subjectField.Text = "";
            };

            callButton.Click += (object sender, EventArgs e) =>
            {
                String recipient = recipientField.Text;
                String contents = contentsField.Text;
             
                int n;
                if (recipient.Contains("@") && subjectField.Text.Length != 0)
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
            };
        }

        //private void TranslateButton_Click(object sender, System.EventArgs e)
        //{
            
        //    throw new System.NotImplementedException();
        //}
    }
}

