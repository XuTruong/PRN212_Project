using System;
using Services;

namespace WPF
{
    public static class ReportTest
    {
        public static void TestReports()
        {
            try
            {
                var reportService = new ReportService();
                
                // Test with date range covering July 2025
                var fromDate = new DateTime(2025, 7, 1);
                var toDate = new DateTime(2025, 7, 31);
                
                Console.WriteLine("Testing Revenue Report...");
                var revenueReport = reportService.GetRevenueReport(fromDate, toDate);
                Console.WriteLine($"Found {revenueReport.Count} revenue records");
                
                Console.WriteLine("Testing Room Report...");
                var roomReport = reportService.GetRoomReport(fromDate, toDate);
                Console.WriteLine($"Found {roomReport.Count} room records");
                
                Console.WriteLine("Testing Payment Report...");
                var paymentReport = reportService.GetPaymentReport(fromDate, toDate);
                Console.WriteLine($"Found {paymentReport.Count} payment records");
                
                Console.WriteLine("Testing Utility Report...");
                var utilityReport = reportService.GetUtilityReport(fromDate, toDate);
                Console.WriteLine($"Found {utilityReport.Count} utility records");
                
                Console.WriteLine("All tests completed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
