namespace RestaurantManagementSystem;
public partial class AppShell : Shell
{
    public static TabBar TabBarStatic { get; private set; }
    public static ShellContent TablePageStatic { get; private set; }
    public static ShellContent MenuPageStatic { get; private set; }
    public static ShellContent SalesPageStatic { get; private set; }
    public AppShell()
    {
        InitializeComponent();
        TabBarStatic = TabBar;
        TablePageStatic = TablePage;
        MenuPageStatic = MenuPage;
        SalesPageStatic = SalesPage;
    }
}
