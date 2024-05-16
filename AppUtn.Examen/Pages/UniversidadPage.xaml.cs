using AppUtn.Examen.Models;

namespace AppUtn.Examen.Pages;

public partial class UniversidadPage : ContentPage
{
    private string urlUniversidades = "https://appuniapivaca.azurewebsites.net/api/Universidades";
	public UniversidadPage()
	{
		InitializeComponent();
	}

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Universidad>.Create(urlUniversidades, new Universidad
            {
                Id = 0,
                Nombre = txtNombre.Text,
                Ubicacion = txtUbicacion.Text
            });

            if (resultado != null)
            {
                txtId.Text = resultado.Id.ToString();
                DisplayAlert("Mensaje", "Registro creado:" + txtId.Text + " - " + txtNombre.Text, "OK");
            }
            else
            {
                DisplayAlert("Mensaje", "Error al crear", "OK");
            }
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al crear", "OK");
        }

    }

    private void btnRead_Clicked(object sender, EventArgs e)
    {

        try
        {
            var resultado = ApiConsumer.Crud<Universidad>.Read_ById(urlUniversidades, int.Parse(txtId.Text));

            if (resultado != null)
            {

                txtNombre.Text = resultado.Nombre.ToString();
                txtUbicacion.Text = resultado.Ubicacion.ToString();

            }
            else

                DisplayAlert("Mensaje", "Registro no encontrado", "OK");

        }
        catch
        {
            DisplayAlert("Mensaje", "Registro no encontrado", "OK");
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Universidad>.Update(urlUniversidades, int.Parse(txtId.Text), new Universidad
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Ubicacion = txtUbicacion.Text
            });

            DisplayAlert("Mensaje", "Registro actualizado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al actualizar", "OK");
        }
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {

        try
        {
            ApiConsumer.Crud<Universidad>.Delete(urlUniversidades, int.Parse(txtId.Text));
            txtId.Text = "";
            txtNombre.Text = "";
            txtUbicacion.Text = "";


            DisplayAlert("Mensaje", "Registro eliminado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al eliminar", "OK");
        }
    }
}