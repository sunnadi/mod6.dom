using System;

public class Report
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Footer { get; set; }

    public void Show()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Body);
        Console.WriteLine(Footer);
    }
}

public interface IReportBuilder
{
    void SetTitle(string title);
    void SetBody(string content);
    void SetFooter(string footer);
    Report GetReport();
}

public class TextReportBuilder : IReportBuilder
{
    private Report _report;

    public TextReportBuilder()
    {
        _report = new Report();
    }

    public void SetTitle(string title)
    {
        _report.Title = "Текстовый отчет: " + title;
    }

    public void SetBody(string content)
    {
        _report.Body = content;
    }

    public void SetFooter(string footer)
    {
        _report.Footer = footer;
    }

    public Report GetReport()
    {
        return _report;
    }
}

public class HtmlReportBuilder : IReportBuilder
{
    private Report _report;

    public HtmlReportBuilder()
    {
        _report = new Report();
    }

    public void SetTitle(string title)
    {
        _report.Title = $"<h1>{title}</h1>";
    }

    public void SetBody(string content)
    {
        _report.Body = $"<p>{content}</p>";
    }

    public void SetFooter(string footer)
    {
        _report.Footer = $"<footer>{footer}</footer>";
    }

    public Report GetReport()
    {
        return _report;
    }
}

public class ReportDirector
{
    public void BuildReport(IReportBuilder builder)
    {
        builder.SetTitle("Ежегодный отчет");
        builder.SetBody("Тело отчета(содержимое) что то что то");
        builder.SetFooter("Подвал отчета(сслыки, литература и тп.)");
    }
}

class Program
{
    static void Main()
    {
        var director = new ReportDirector();

        IReportBuilder textBuilder = new TextReportBuilder();
        director.BuildReport(textBuilder);
        var textReport = textBuilder.GetReport();
        textReport.Show();

        Console.WriteLine();

        IReportBuilder htmlBuilder = new HtmlReportBuilder();
        director.BuildReport(htmlBuilder);
        var htmlReport = htmlBuilder.GetReport();
        htmlReport.Show();
    }
}
