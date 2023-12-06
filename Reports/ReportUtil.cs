using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public class ReportUtil
{
    public static ExtentReports Extent;
    public static ExtentTest Test;

    public static void Initialize()
    {
        string reportPath = @"C:\@ITLA\6to Cuatrimestre\Programacion III\Prog3-Tarea4\Report.html";
        var spark = new ExtentSparkReporter(reportPath);
        Extent = new ExtentReports();
        Extent.AttachReporter(spark);
    }

    public static void FlushReport()
    {
        Extent.Flush();
    }
    
}