using System;
using System.Collections.Generic;

namespace Application.Tests.TestData
{
    public class ValuationTestData
    {
        public static ValuationData GetValuationWithCover()
        {
            var valuation = new ValuationData("", "", false, "", "Testowa wycena", "Testowy odbiorca", DateTime.Now.AddDays(7), "2000x1000", "5000x5000", 10000, 5, 12000, "testowa notatka pomocnicza", 8, "2000x1000", "5000x5000", 10000, 12000, "", 8, 0, 10000, 0);
            valuation.InsideColors.Add(new ColorData("CMYK 4+4"));
            valuation.InsidePapers.Add(new PaperData("Kreda", "Matowa", "500x500", 80, 1000, 0.5, "Pionowy"));
            valuation.InsideServices.Add(new ServiceData("Falcowanie", 200));
            valuation.CoverColors.Add(new ColorData("CMYK 4+4"));
            valuation.CoverPapers.Add(new PaperData("Kreda", "Matowa", "500x500", 90, 1000, 0.5, "Pionowy"));
            valuation.CoverServices.Add(new ServiceData("Lakierowanie", 200));

            return valuation;
        }

        public static ValuationData GetValuationWithoutCover()
        {
            var valuation = new ValuationData("", "", false, "", "Testowa wycena", "Testowy odbiorca", DateTime.Now.AddDays(7), "200x200", "500x500", 300, 1, 400, "testowa notatka pomocnicza", 8, "", "", 0, 0, "", 0, 0, 300, 0);
            valuation.InsideColors.Add(new ColorData("CMYK 4+4"));
            valuation.InsidePapers.Add(new PaperData("Kreda", "Matowa", "500x500", 90, 1000, 0.5, "Pionowy"));
            valuation.InsideServices.Add(new ServiceData("Lakierowanie", 200));

            return valuation;
        }
    }

    public struct ValuationData
    {
        public string Order { get; set; }
        public string OrderItem { get; set; }
        public bool IsWithCover { get; set; }
        public string Author { get; set; }
        public string ValuationName { get; set; }
        public string ValuationRecipient { get; set; }
        public DateTime OfferValidity { get; set; }
        public string InsideFormat { get; set; }
        public string InsideFormatSheet { get; set; }
        public int InsideCirculation { get; set; }
        public int InsideCapacity { get; set; }
        public int InsideSheetNumber { get; set; }
        public string IsnideOther { get; set; }
        public int InsidePlateNumber { get; set; }
        public string CoverFormat { get; set; }
        public string CoverFormatSheet { get; set; }
        public int CoverCirculation { get; set; }
        public int CoverSheetNumber { get; set; }
        public string CoverOther { get; set; }
        public int CoverPlateNumber { get; set; }
        public double FinalPrice { get; set; }
        public int MainCirculation { get; set; }
        public double UnitPrice { get; set; }
        public List<ColorData> InsideColors { get; set; }
        public List<ColorData> CoverColors { get; set; }
        public List<PaperData> InsidePapers { get; set; }
        public List<PaperData> CoverPapers { get; set; }
        public List<ServiceData> InsideServices { get; set; }
        public List<ServiceData> CoverServices { get; set; }

        public ValuationData(string order, string orderItem, bool isWithCover, string auhtor, string valuationName, string valuationRecipient, DateTime offerValidity,
                             string insideFormat, string insideFormatSheet, int insideCirculation, int insideCapacity, int insideSheetNumber, string isnideOther,
                             int insidePlateNumber, string coverFormat, string coverFormatSheet, int coverCirculation, int coverSheetNumber, string coverOther,
                             int coverPlateNumber, double finalPrice, int mainCirculation, double unitPrice)
        {
            Order = order;
            OrderItem = orderItem;
            IsWithCover = isWithCover;
            Author = auhtor;
            ValuationName = valuationName;
            ValuationRecipient = valuationRecipient;
            OfferValidity = offerValidity;
            InsideFormat = insideFormat;
            InsideFormatSheet = insideFormatSheet;
            InsideCirculation = insideCirculation;
            InsideCapacity = insideCapacity;
            InsideSheetNumber = insideSheetNumber;
            IsnideOther = isnideOther;
            InsidePlateNumber = insidePlateNumber;
            CoverFormat = coverFormat;
            CoverFormatSheet = coverFormatSheet;
            CoverCirculation = coverCirculation;
            CoverSheetNumber = coverSheetNumber;
            CoverOther = coverOther;
            CoverPlateNumber = coverPlateNumber;
            FinalPrice = finalPrice;
            MainCirculation = mainCirculation;
            UnitPrice = unitPrice;

            InsideColors = new List<ColorData>();
            CoverColors = new List<ColorData>();
            InsidePapers = new List<PaperData>();
            CoverPapers = new List<PaperData>();
            InsideServices = new List<ServiceData>();
            CoverServices = new List<ServiceData>();
        }
    }
}
