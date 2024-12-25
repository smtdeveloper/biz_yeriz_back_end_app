using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;

namespace bizyeriz.Application.Features.Companies.Models.Enums;

public static class StaticFilters
{
    public static readonly List<ByPointDto> ByPoints = new()
  {
      new ByPointDto { Id = 1, Point = 4.5 , Name ="4.5 ve üstü"},
      new ByPointDto { Id = 2, Point = 4.0, Name ="4 ve üstü" },
      new ByPointDto { Id = 3, Point = 3.5, Name ="3.5 ve üstü" },
      new ByPointDto { Id = 4, Point = 3.0, Name ="3 ve üstü" },
      new ByPointDto { Id = 5, Point = 2.5, Name ="2.5 ve üstü" },
      new ByPointDto { Id = 6, Point = 2.0, Name ="2 ve üstü" },
      new ByPointDto { Id = 7, Point = 1.5, Name ="1.5 ve üstü" },
      new ByPointDto { Id = 8, Point = 1.0, Name ="1 ve üstü" }
  };

    public static readonly List<PriceRangeDto> PriceRanges = new()
  {
      new PriceRangeDto { Id = 1, Range = 50 , Name ="50TL ve altı" },
      new PriceRangeDto { Id = 2, Range = 100, Name ="100TL ve altı"},
      new PriceRangeDto { Id = 3, Range = 150, Name ="150TL ve altı" },
      new PriceRangeDto { Id = 4, Range = 200, Name ="200TL ve altı" },
      new PriceRangeDto { Id = 5, Range = 250, Name ="250TL ve altı" },
      new PriceRangeDto { Id = 6, Range = 300, Name ="300TL ve altı" },
      new PriceRangeDto { Id = 7, Range = 350, Name ="350TL ve altı" },
      new PriceRangeDto { Id = 8, Range = 400, Name ="400TL ve altı" }
};

    public static readonly List<PaymentTypeDto> PaymentTypes = new()
    {
        new PaymentTypeDto { Id = 1, Name = "Nakit" },
        new PaymentTypeDto { Id = 2, Name = "Kredi Kartı" }
    };

    public static readonly List<OrderTypeDto> OrderTypes = new()
    {
         new OrderTypeDto { Id = 1, Name = "Akıllı Sıralama" },
         new OrderTypeDto { Id = 2, Name = "Yakınlık" },
         new OrderTypeDto { Id = 3, Name = "En Çok Değerlendirenler" },
         new OrderTypeDto { Id = 4, Name = "Puan" },
         new OrderTypeDto { Id = 5, Name = "Alfabetik" }
    };
}


