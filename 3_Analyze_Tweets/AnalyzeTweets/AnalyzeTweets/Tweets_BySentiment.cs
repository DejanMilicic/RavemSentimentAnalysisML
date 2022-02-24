using Raven.Client.Documents.Indexes;
using SentimentAnalyzer;

namespace AnalyzeTweets
{
    public class Tweets_BySentiment : AbstractIndexCreationTask<Tweet>
    {
        public class Entry
        {
            public string Sentiment { get; set; }

            public float Score { get; set; }
        }

        public Tweets_BySentiment()
        {
            Map = tweets => from tweet in tweets
                let prediction = Sentiments.Predict(tweet.Text)
                select new Entry
                {
                    Sentiment = prediction.Prediction ? "Positive" : "Negative",
                    Score = prediction.Score
                };

            AdditionalAssemblies = new HashSet<AdditionalAssembly>
            {
                AdditionalAssembly.FromNuGet(
                    packageName: "SentimentAnalyzer", 
                    packageVersion: "1.2.3", 
                    usings: new HashSet<string>{"SentimentAnalyzer"})
            };
        }
    }
}
