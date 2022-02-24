// See https://aka.ms/new-console-template for more information

PrintSentimentAnalysis("your service is horrible");
PrintSentimentAnalysis("you stink");
PrintSentimentAnalysis("you suck");
PrintSentimentAnalysis("you wonderful and emphatic human being");
PrintSentimentAnalysis("life is beautiful");

static void PrintSentimentAnalysis(string text)
{
    dynamic analysis = SentimentAnalysis.Analyze(text);
    Console.WriteLine($"\n{text}");
    Console.WriteLine($"sentiment: {analysis.Sentiment} [{analysis.Score}]");
}