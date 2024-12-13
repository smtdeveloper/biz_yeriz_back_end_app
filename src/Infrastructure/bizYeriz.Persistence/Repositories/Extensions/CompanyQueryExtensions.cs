using bizYeriz.Domain.Entities.CompanyEntities;
using NetTopologySuite.Geometries;

namespace bizYeriz.Persistence.Repositories.Extensions;

public static class CompanyQueryExtensions
{
    public static IQueryable<Company> ApplyOrdering(this IQueryable<Company> query, int? byOrderId, Point userLocation)
    {
        if (!byOrderId.HasValue) return query;

        return byOrderId.Value switch
        {
            1 => query.OrderByDescending(c => c.RatingCount / c.StarRating), // Akıllı Sıralama
            2 => query.OrderBy(c => c.Location.Distance(userLocation)), // Yakınlık
            3 => query.OrderByDescending(c => c.RatingCount), // En Çok Değerlendirenler
            4 => query.OrderByDescending(c => c.AverageRating), // Puan
            5 => query.OrderBy(c => c.Name), // Alfabetik
            _ => query
        };
    }
}