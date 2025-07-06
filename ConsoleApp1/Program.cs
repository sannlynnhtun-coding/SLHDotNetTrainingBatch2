// See https://aka.ms/new-console-template for more information
using MailKit.Net.Smtp;
using MimeKit;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

string password = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);

var message = new MimeMessage();
message.From.Add(new MailboxAddress("Sann Lynn Htun", "sannlynnhtun.ace@gmail.com"));
message.To.Add(new MailboxAddress("Testing Staff", "sannlynnhtun.ace@gmail.com"));
message.Subject = "Mini POS - User Creation";

message.Body = new TextPart("plain")
{
    Text = $@"Your password is {password}"
};

using (var client = new SmtpClient())
{
    client.Connect("smtp.gmail.com", 587, false);

    // Note: only needed if the SMTP server requires authentication
    client.Authenticate("sannlynnhtun.ace@gmail.com", "kgom bcum apzn sqin"); // email & app password https://myaccount.google.com/apppasswords

    client.Send(message);
    client.Disconnect(true);
}