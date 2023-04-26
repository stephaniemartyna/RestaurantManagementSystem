namespace RestaurantManagementSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        DBConnect dbConnect = new DBConnect();

        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
