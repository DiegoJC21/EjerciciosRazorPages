using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace EjerciciosRazorPages.Pages
{
    public class CifradoCesarModel : PageModel
    {
        [BindProperty]
        public string MensajeOriginal { get; set; }
        [BindProperty]
        public int Desplazamiento { get; set; }
        public string MensajeCifrado { get; set; }
        public string MensajeDescifrado { get; set; }

        public void OnPostCifrar()
        {
            MensajeCifrado = Cifrar(MensajeOriginal, Desplazamiento);
        }

        public void OnPostDescifrar()
        {
            MensajeDescifrado = Descifrar(MensajeOriginal, Desplazamiento);
        }

        private string Cifrar(string mensaje, int desplazamiento)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (char c in mensaje.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    char offset = 'A';
                    char cifrado = (char)((c + desplazamiento - offset) % 26 + offset);
                    resultado.Append(cifrado);
                }
                else
                {
                    resultado.Append(c);
                }
            }
            return resultado.ToString();
        }

        private string Descifrar(string mensaje, int desplazamiento)
        {
            return Cifrar(mensaje, 26 - desplazamiento);
        }
    }
}
