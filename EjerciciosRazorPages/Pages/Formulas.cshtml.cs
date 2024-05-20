using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class FormulasModel : PageModel
    {
        //Propiedades
        [BindProperty]
        public string a { get; set; } = "";
        [BindProperty]
        public string b { get; set; } = "";
        [BindProperty]
        public string x { get; set; } = "";
        [BindProperty]
        public string y { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";

        public double resultado1 = 0;
        public double resultado2 = 0;



        public void OnPost()
        {
            double A = Convert.ToDouble(a);
            double B = Convert.ToDouble(b);
            double X = Convert.ToDouble(x);
            double Y = Convert.ToDouble(y);
            double N = Convert.ToDouble(n);

            double termino1 = A * X;
            double termino2 = B * Y;
            double suma = termino1 + termino2;

            resultado1 = Math.Pow(suma, N);
            resultado2 = CalcularExpresion(A, X, B, Y, N);


            ModelState.Clear();
        }
        public long CalcularFactorial(double n)
        {
            if (n < 0)
            {
                throw new ArgumentException("El factorial solo está definido para números enteros no negativos.");
            }

            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public long CalcularCombinacion(double n, int k)
        {
            if (n < 0 || k < 0 || k > n)
            {
                throw new ArgumentException("Los valores de n y k deben ser enteros no negativos y k no puede ser mayor que n.");
            }

            // Calcula los factoriales de n, k y n-k
            long factorialN = CalcularFactorial(n);
            long factorialK = CalcularFactorial(k);
            long factorialNK = CalcularFactorial(n - k);

            // Calcula la combinación
            long combinacion = factorialN / (factorialK * factorialNK);

            return combinacion;
        }

        public double CalcularExpresion(double a, double x, double b, double y, double n)
        {
            double resultado = 0;

            for (int k = 0; k <= n; k++)
            {
                // Calcula la combinación
                long combinacion = CalcularCombinacion(n, k);

                // Calcula (a * x)^(n-k) * (b * y)^k
                double termino1 = Math.Pow(a * x, n - k);
                double termino2 = Math.Pow(b * y, k);
                double expresion = combinacion * termino1 * termino2;

                // Suma el resultado parcial
                resultado += expresion;
            }

            return resultado;
        }



    }
}

