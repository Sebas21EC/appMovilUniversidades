using AppUtn.Examen.Models;

namespace AppUtn.Examen.Pages;

public partial class CarreraPage : ContentPage
{
    private string urlApiCarrera= "https://appuniapivaca.azurewebsites.net/api/Carreras";

    public CarreraPage()
	{
		InitializeComponent();
	}

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Carrera>.Create(urlApiCarrera, new Carrera
            {
                Id = 0,
                Nombre = txtNombre.Text,
                UniversidadId = Convert.ToInt32(txtIdUniversidad.Text)
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
            var resultado = ApiConsumer.Crud<Carrera>.Read_ById(urlApiCarrera, int.Parse(txtId.Text));

            if (resultado != null)
            {

                txtNombre.Text = resultado.Nombre.ToString();
                txtIdUniversidad.Text = resultado.UniversidadId.ToString();

            }
            else

                DisplayAlert("Mensaje", "Registro no encontrado", "OK");

        }
        catch
        {
            DisplayAlert("Mensaje", "Error al buscar", "OK");
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Carrera>.Update(urlApiCarrera, int.Parse(txtId.Text), new Carrera
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                UniversidadId = int.Parse(txtIdUniversidad.Text)
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
            ApiConsumer.Crud<Carrera>.Delete(urlApiCarrera, int.Parse(txtId.Text));
            txtId.Text = "";
            txtIdUniversidad.Text = "";
            txtNombre.Text = "";


            DisplayAlert("Mensaje", "Registro eliminado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al eliminar", "OK");
        }
    }
}