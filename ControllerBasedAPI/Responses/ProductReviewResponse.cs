using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M02.BuildingRESTFulAPI.Model;

namespace ControllerBasedAPI.Responses
{
    public class ProductReviewResponse
    {
    public Guid ReviewId { get; set; }
    public Guid ProductId { get; set; }
    public string? Reviewer { get; set; }
    public int Stars { get; set; }

    private ProductReviewResponse() { } // to prevent instantiation outside the class

    public static ProductReviewResponse FromModel(M02.BuildingRESTFulAPI.Model.ProductReview? review)
    { 
        if (review == null)
            throw new ArgumentNullException(nameof(review), "Cannot create a response from a null review");

        return new ProductReviewResponse
        {
            ReviewId = review.Id,
            ProductId = review.ProductId,
            Reviewer = review.Reviewer,
            Stars = review.Stars
        };
    }

    
    public static IEnumerable<ProductReviewResponse> FromModels(IEnumerable<ProductReview> reviews)
    {
        if (reviews == null) 
            throw new ArgumentNullException(nameof(reviews));

        return reviews.Select(FromModel);
    }
    }
}