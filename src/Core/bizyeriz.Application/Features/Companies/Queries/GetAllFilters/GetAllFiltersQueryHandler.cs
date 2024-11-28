namespace bizyeriz.Application.Features.Companies.Queries.GetAllFilters;

public class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, GetAllFiltersResponse>
{
    public async Task<GetAllFiltersResponse> Handle(GetAllFiltersQuery request, CancellationToken cancellationToken)
    {
        // Sabit mutfak kategorileri
        var cuisineCategories = new List<CuisineCategoryDto>
        {
            new CuisineCategoryDto { Id = 8, Name = "Pasta/Tatlı" },
            new CuisineCategoryDto { Id = 9, Name = "Aperatifler" },
            new CuisineCategoryDto { Id = 10, Name = "Fırın Pastahane" },
            new CuisineCategoryDto { Id = 11, Name = "Ev Yemekleri" },
            new CuisineCategoryDto { Id = 12, Name = "Çorba" },
            new CuisineCategoryDto { Id = 13, Name = "Çiğ Köfte" },
            new CuisineCategoryDto { Id = 14, Name = "Salata" },
            new CuisineCategoryDto { Id = 15, Name = "Meze" },
            new CuisineCategoryDto { Id = 16, Name = "Dünya Mutfağı" }
        };

        // Sabit puan filtreleri
        var byPoints = new List<ByPointDto>
        {
            new ByPointDto { Id = 1, Name = "4.5 ve üzeri" },
            new ByPointDto { Id = 2, Name = "4.0 ve üzeri" },
            new ByPointDto { Id = 3, Name = "3.5 ve üzeri" },
            new ByPointDto { Id = 4, Name = "3.0 ve üzeri" },
            new ByPointDto { Id = 5, Name = "2.5 ve üzeri" },
            new ByPointDto { Id = 6, Name = "2.0 ve üzeri" },
            new ByPointDto { Id = 7, Name = "1.5 ve üzeri" },
            new ByPointDto { Id = 8, Name = "1.0 ve üzeri" }
        };

        // Sabit fiyat aralıkları
        var priceRanges = new List<PriceRangeDto>
        {
            new PriceRangeDto { Id = 1, Range = "50 TL ve altı" },
            new PriceRangeDto { Id = 2, Range = "100 TL ve altı" },
            new PriceRangeDto { Id = 3, Range = "150 TL ve altı" },
            new PriceRangeDto { Id = 4, Range = "200 TL ve altı" },
            new PriceRangeDto { Id = 5, Range = "250 TL ve altı" },
            new PriceRangeDto { Id = 6, Range = "300 TL ve altı" },
            new PriceRangeDto { Id = 7, Range = "350 TL ve altı" },
            new PriceRangeDto { Id = 8, Range = "400 TL ve altı" }
        };

        // Sabit ödeme türleri
        var paymentTypes = new List<PaymentTypeDto>
        {
            new PaymentTypeDto { Id = 1, Name = "Nakit" },
            new PaymentTypeDto { Id = 2, Name = "Kredi Kartı" }
        };

        // Sabit değerlerin birleştirilmesi
        return await Task.FromResult(new GetAllFiltersResponse
        {
            CuisineCategories = cuisineCategories,
            ByPoints = byPoints,
            PriceRanges = priceRanges,
            PaymentTypes = paymentTypes
        });
    }
}
