using System;
using System.Collections.Generic;

namespace Application.Tests.TestData
{
    public class OrderItemTestData
    {
        public static OrderItemData GetOrderItemWithCover()
        {
            var orderItem = new OrderItemData();
            orderItem.InsideColors.Add(new ColorData("CMYK 4+4"));
            orderItem.InsidePapers.Add(new PaperData("Kreda", "Matowa", "500x500", 80, 1000, 0.5, "Pionowy"));
            orderItem.InsideServices.Add(new ServiceData("Falcowanie", 200));
            orderItem.CoverColors.Add(new ColorData("CMYK 4+4"));
            orderItem.CoverPapers.Add(new PaperData("Kreda", "Matowa", "500x500", 90, 1000, 0.5, "Pionowy"));
            orderItem.CoverServices.Add(new ServiceData("Lakierowanie", 200));

            return orderItem;
        }

        public static OrderItemData GetOrderItemWithoutCover()
        {
            var orderItem = new OrderItemData();
            orderItem.InsideColors.Add(new ColorData("CMYK 4+4"));
            orderItem.InsidePapers.Add(new PaperData("Kreda", "Matowa", "500x500", 90, 1000, 0.5, "Pionowy"));
            orderItem.InsideServices.Add(new ServiceData("Lakierowanie", 200));

            return orderItem;
        }
    }

    public struct OrderItemData
    {
        public bool IsWithCover { get; set; }
        public string OrderItemName { get; set; }
        public string Note { get; set; }
        public DateTime WantedFinishDate { get; set; }
        public string InsideFormat { get; set; }
        public string CoverFormat { get; set; }
        public int Circulation { get; set; }
        public int Capacity { get; set; }
        public string OrderItemType { get; set; }
        public string DeliveryType { get; set; }
        public string BindingType { get; set; }

        public List<ColorData> InsideColors { get; set; }
        public List<ColorData> CoverColors { get; set; }
        public List<PaperData> InsidePapers { get; set; }
        public List<PaperData> CoverPapers { get; set; }
        public List<ServiceData> InsideServices { get; set; }
        public List<ServiceData> CoverServices { get; set; }

        public OrderItemData(bool isWithCover, string name, string note, DateTime wantedFinishDate, string insideFormat, string coverFormat, int circulation, int capacity, string orderItemType, string deliveryType, string bindingType)
        {
            IsWithCover = isWithCover;
            OrderItemName = name;
            Note = note;
            WantedFinishDate = wantedFinishDate;
            InsideFormat = insideFormat;
            CoverFormat = coverFormat;
            Circulation = circulation;
            Capacity = capacity;
            OrderItemType = orderItemType;
            DeliveryType = deliveryType;
            BindingType = bindingType;

            InsideColors = new List<ColorData>();
            CoverColors = new List<ColorData>();
            InsidePapers = new List<PaperData>();
            CoverPapers = new List<PaperData>();
            InsideServices = new List<ServiceData>();
            CoverServices = new List<ServiceData>();
        }
    }

    public struct ColorData
    {
        public string Name { get; set; }

        public ColorData(string name)
        {
            Name = name;
        }
    }

    public struct PaperData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Format { get; set; }
        public int Opacity { get; set; }
        public int Quantity { get; set; }
        public double PerKilo { get; set; }
        public string FiberDirection { get; set; }

        public PaperData(string name, string type, string format, int opacity, int quantity, double perkilo, string fiberDirection)
        {
            Name = name;
            Type = type;
            Format = format;
            Opacity = opacity;
            Quantity = quantity;
            PerKilo = perkilo;
            FiberDirection = fiberDirection;
        }
    }

    public struct ServiceData
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ServiceData(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
