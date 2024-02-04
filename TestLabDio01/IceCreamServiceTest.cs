using LabDioAI01;

namespace TestLabDio01
{
    [TestClass]
    public class TestLabDio01
    {
        [TestMethod]
        public async Task TestLabDio01_IceCreamService_May_SuccessAsync()
        {

            var service = new SalesForecastService();
            var qt_sales_1may = await service.GetSalesForecast("2024-05-01");
            Assert.IsNotNull(qt_sales_1may);
            var qt_sales_5may = await service.GetSalesForecast("2024-05-05");
            Assert.IsNotNull(qt_sales_5may);

        }

        
    }
}