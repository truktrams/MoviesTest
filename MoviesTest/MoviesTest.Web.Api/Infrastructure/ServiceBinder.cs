using MoviesTest.Sdk.Interfaces;
using MoviesTest.Sdk.Services;
using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Services;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Services;

namespace MoviesTest.Web.Api.Infrastructure;

public static class ServiceBinder
{
    public static void BindServices(IServiceCollection collection)
    {
        BindBusinessLayerServices(collection);
        BindDataAccessServices(collection);
        BindTools(collection);
    }

    private static void BindBusinessLayerServices(IServiceCollection collection)
    {
        collection.AddTransient<IGenreBusinessService, GenreBusinessService>();
        collection.AddTransient<IMovieBusinessService, MovieBusinessService>();
        collection.AddTransient<IReservationBusinessService, ReservationBusinessService>();
        collection.AddTransient<IReservationInvoiceBusinessService, ReservationInvoiceBusinessService>();
        collection.AddTransient<ITheaterBusinessService, TheaterBusinessService>();
        collection.AddTransient<ITheaterSeatBusinessService, TheaterSeatBusinessService>();
        collection.AddTransient<ITheaterSeatReservationBusinessService, TheaterSeatReservationBusinessService>();
        collection.AddTransient<ITheaterShowTimeBusinessService, TheaterShowTimeBusinessService>();
        collection.AddTransient<IUserBusinessService, UserBusinessService>();
    }

    private static void BindDataAccessServices(IServiceCollection collection)
    {
        collection.AddTransient<IGenreDataService, GenreDataService>();
        collection.AddTransient<IMovieDataService, MovieDataService>();
        collection.AddTransient<IReservationDataService, ReservationDataService>();
        collection.AddTransient<ITheaterDataService, TheaterDataService>();
        collection.AddTransient<ITheaterSeatDataService, TheaterSeatDataService>();
        collection.AddTransient<ITheaterSeatReservationDataService, TheaterSeatReservationDataService>();
        collection.AddTransient<ITheaterShowTimeDataService, TheaterShowTimeDataService>();
        collection.AddTransient<IUserDataService, UserDataService>();
    }

    private static void BindTools(IServiceCollection collection)
    {
        collection.AddTransient<IDbConnectionManager, DbConnectionManager>();
    }
}