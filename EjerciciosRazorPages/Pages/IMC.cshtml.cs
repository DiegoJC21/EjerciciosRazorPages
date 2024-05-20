using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class IMCModel : PageModel
    {
        // Propiedades
        [BindProperty]
        public string Peso { get; set; } = "";
        [BindProperty]
        public string Altura { get; set; } = "";

        public double IMC { get; set; } = 0;
        public string Clasificacion { get; set; } = "";

        public void OnPost()
        {
            // Convertir las cadenas a dobles
            double pesoDouble = Convert.ToDouble(Peso);
            double alturaDouble = Convert.ToDouble(Altura);

            // Calcular el IMC
            IMC = pesoDouble / (alturaDouble * alturaDouble);

            // Determinar la clasificación
            if (IMC < 18)
            {
                Clasificacion = "Peso Bajo";
            }
            else if (IMC >= 18 && IMC < 25)
            {
                Clasificacion = "Peso Normal";
            }
            else if (IMC >= 25 && IMC < 27)
            {
                Clasificacion = "Sobrepeso";
            }
            else if (IMC >= 27 && IMC < 30)
            {
                Clasificacion = "Obesidad grado I";
            }
            else if (IMC >= 30 && IMC < 40)
            {
                Clasificacion = "Obesidad grado II";
            }
            else if (IMC >= 40)
            {
                Clasificacion = "Obesidad grado III";
            }

            // Limpiar el estado del modelo
            ModelState.Clear();
        }
    }
}
