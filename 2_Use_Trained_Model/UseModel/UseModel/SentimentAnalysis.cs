using System;
using Microsoft.ML;
using Microsoft.ML.Data;

public class SentimentIssue
{
    [LoadColumn(0)]
    public bool Label { get; set; }

    [LoadColumn(2)]
    public string Text { get; set; }
}

public class SentimentPrediction
{
    // ColumnName attribute is used to change the column name from
    // its default value, which is the name of the field.
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }

    // No need to specify ColumnName attribute, because the field
    // name "Probability" is the column name we want.
    public float Probability { get; set; }

    public float Score { get; set; }
}

public static class SentimentAnalysis
{
    private const string ModelZipPath = @"SentimentModel.zip";

    [ThreadStatic]
    private static PredictionEngine<SentimentIssue, SentimentPrediction> _engine;

    private static void Init()
    {
        MLContext mlContext = new MLContext();
        var model = mlContext.Model.Load(ModelZipPath, out var _);
        _engine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(model);
    }

    public static dynamic Analyze(string text)
    {
        Init();

        var sentiment = _engine.Predict(new SentimentIssue { Text = text });

        return new { Sentiment = sentiment.Prediction ? "toxic" : "nontoxic", Score = sentiment.Probability };
    }
}