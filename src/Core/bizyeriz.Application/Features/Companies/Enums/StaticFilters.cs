using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;

namespace bizyeriz.Application.Features.Companies.Enums;

public static class StaticFilters
{
    public static readonly List<ByPointDto> ByPoints = new()
    {
        new ByPointDto { Id = 1, Point = 4.5 },
        new ByPointDto { Id = 2, Point = 4.0 },
        new ByPointDto { Id = 3, Point = 3.5 },
        new ByPointDto { Id = 4, Point = 3.0 },
        new ByPointDto { Id = 5, Point = 2.5 },
        new ByPointDto { Id = 6, Point = 2.0 },
        new ByPointDto { Id = 7, Point = 1.5 },
        new ByPointDto { Id = 8, Point = 1.0 }
    };

    public static readonly List<PriceRangeDto> PriceRanges = new()
    {
        new PriceRangeDto { Id = 1, Range = 50 },
        new PriceRangeDto { Id = 2, Range = 100 },
        new PriceRangeDto { Id = 3, Range = 150 },
        new PriceRangeDto { Id = 4, Range = 200 },
        new PriceRangeDto { Id = 5, Range = 250 },
        new PriceRangeDto { Id = 6, Range = 300 },
        new PriceRangeDto { Id = 7, Range = 350 },
        new PriceRangeDto { Id = 8, Range = 400 }
    };

    public static readonly List<PaymentTypeDto> PaymentTypes = new()
    {
        new PaymentTypeDto { Id = 1, Name = "Nakit" },
        new PaymentTypeDto { Id = 2, Name = "Kredi Kartı" }
    };
}


