export interface Review {
    reviewId: number;
    customerId: number;
    restaurantId: number;
    rating: number;
    comment?: string;
    response?: string;
    datePosted: Date;
}