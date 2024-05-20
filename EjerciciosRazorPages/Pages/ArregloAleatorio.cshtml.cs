using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosRazorPages.Pages
{
    public class EstadisticasNumerosModel : PageModel
    {
        public List<int> NumerosAleatorios { get; set; }
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }

        public void OnGet()
        {
            // Generar 20 números aleatorios entre 0 y 100
            Random random = new Random();
            NumerosAleatorios = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                NumerosAleatorios.Add(random.Next(0, 101));
            }

            // Copiar la lista de números aleatorios antes de ordenarla
            var numerosAleatoriosOrdenados = NumerosAleatorios.ToList();

            // Calcular suma
            Suma = NumerosAleatorios.Sum();

            // Calcular promedio
            Promedio = NumerosAleatorios.Average();

            // Ordenar los números aleatorios
            NumerosAleatorios.Sort();

            // Calcular moda
            var conteoNumeros = NumerosAleatorios.GroupBy(x => x)
                                                  .Select(g => new { Numero = g.Key, Frecuencia = g.Count() })
                                                  .OrderByDescending(g => g.Frecuencia);
            int maxFrecuencia = conteoNumeros.First().Frecuencia;
            Moda = conteoNumeros.Where(g => g.Frecuencia == maxFrecuencia)
                                 .Select(g => g.Numero)
                                 .ToList();

            // Calcular mediana
            if (NumerosAleatorios.Count % 2 == 0)
            {
                Mediana = (NumerosAleatorios[NumerosAleatorios.Count / 2 - 1] + NumerosAleatorios[NumerosAleatorios.Count / 2]) / 2.0;
            }
            else
            {
                Mediana = NumerosAleatorios[NumerosAleatorios.Count / 2];
            }

            // Asignar la lista ordenada de números aleatorios
            NumerosAleatorios = numerosAleatoriosOrdenados;
        }


    }
}
