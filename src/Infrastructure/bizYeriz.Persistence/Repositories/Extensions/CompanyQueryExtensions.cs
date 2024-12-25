using bizyeriz.Application.Features.Companies.Models.Enums;
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

    public static class DistanceHelper
    {
        public static string FormatDistance(double distanceInMeters)
        {
            if (distanceInMeters < 1000)
            {
                return $"{Math.Round(distanceInMeters)} metre"; // 1000 metreden küçükse metre cinsinden
            }
            else
            {
                return $"{Math.Round(distanceInMeters / 1000, 2)} km"; // 1000 metre veya daha büyükse kilometre cinsinden
            }
        }
    }


    public static double GetMaxPriceByPriceRangeId(int priceRangeId)
    {
        // PriceRanges listesinden ilgili ID'ye sahip kaydı bul
        var priceRange = StaticFilters.PriceRanges.FirstOrDefault(pr => pr.Id == priceRangeId);
        return priceRange?.Range ?? double.MaxValue; // Eğer ID bulunmazsa varsayılan değer
    }

    public static double GetMinimumPointByPointId(int byPointId)
    {
        // ByPoints listesinden ilgili ID'ye sahip kaydı bul
        var byPoint = StaticFilters.ByPoints.FirstOrDefault(bp => bp.Id == byPointId);
        return byPoint?.Point ?? 0; // Eğer ID bulunmazsa varsayılan değer
    }
}