// See https://aka.ms/new-console-template for more information

using AnalyzeTweets;

var session = DocumentStoreHolder.Store.OpenSession();

Tweet sampleTweet = session.Load<Tweet>("Tweets/0000000000000029278-A");

Console.WriteLine(sampleTweet);