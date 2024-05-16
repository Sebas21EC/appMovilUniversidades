namespace AppUtn.Examen.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void btnUniversidades_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UniversidadPage());
    }

    private void btnCarreras_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CarreraPage());
    }
}