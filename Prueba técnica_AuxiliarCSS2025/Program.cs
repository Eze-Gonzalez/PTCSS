using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_técnica_AuxiliarCSS2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ticket[] tickets = new Ticket[10]; // Creamos arreglo

            for (int i = 0; i < 10; i++) // llenamos el arreglo tickets
            {
                Ticket ticket = new Ticket();
                ticket.id = 103 + i;
                //ticket.ag = new Agente();
                //Console.WriteLine("Ingrese el nombre del agente asignado: ");
                //ticket.ag.nombre = Console.ReadLine();
                tickets[i] = ticket;
            }
            Dictionary<string, (int ticketsResueltos, TimeSpan totalTiempo)> resueltosokConTiempo = new Dictionary<string, (int, TimeSpan)>(); // creamos una biblioteca que almacene los nombres de los agentes+los tickets resueltos en plazo y el tiempo total que les llevó
            foreach (Ticket ticket in tickets) // asignamos valores a los tickets y sus propiedades (se puede crear para que se asignen en consola con readline, pero en este caso los llené manualmente)
            {
                ticket.ag = new Agente();
                ticket.tipo = new Tipo();
                switch (ticket.id)
                {
                    case 103:
                        ticket.ag.nombre = "Juan Pérez";
                        ticket.tipo.tipo = "Consulta";
                        ticket.creacion = new DateTime(02 / 02 / 2024);
                        ticket.cierre = new DateTime(02 / 02 / 2024);
                        break;
                    case 104:
                        ticket.ag.nombre = "María Lopez";
                        ticket.tipo.tipo = "Reclamo";
                        ticket.creacion = new DateTime(02 / 02 / 2024);
                        ticket.cierre = new DateTime(04 / 02 / 2024);
                        break;
                    case 105:
                        ticket.ag.nombre = "Pedro Gómez";
                        ticket.tipo.tipo = "consulta";
                        ticket.creacion = new DateTime(03 / 02 / 2024);
                        ticket.cierre = new DateTime(03 / 02 / 2024);
                        break;
                    case 106:
                        ticket.ag.nombre = "Ana Ramírez";
                        ticket.tipo.tipo = "Reclamo";
                        ticket.creacion = new DateTime(03 / 02 / 2024);
                        ticket.cierre = new DateTime(05 / 02 / 2024);
                        break;
                    case 107:
                        ticket.ag.nombre = "Luis Torres";
                        ticket.tipo.tipo = "Consulta";
                        ticket.creacion = new DateTime(04 / 02 / 2024);
                        ticket.cierre = new DateTime(05 / 02 / 2024);
                        break;
                    case 108:
                        ticket.ag.nombre = "Sofía Díaz";
                        ticket.tipo.tipo = "Reclamo";
                        ticket.creacion = new DateTime(04 / 02 / 2024);
                        ticket.cierre = new DateTime(06 / 02 / 2024);
                        break;
                    case 109:
                        ticket.ag.nombre = "Juan Pérez";
                        ticket.tipo.tipo = "Consulta";
                        ticket.creacion = new DateTime(05 / 02 / 2024);
                        ticket.cierre = new DateTime(06 / 02 / 2024);
                        break;
                    case 110:
                        ticket.ag.nombre = "María Lopez";
                        ticket.tipo.tipo = "Reclamo";
                        ticket.creacion = new DateTime(05 / 02 / 2024);
                        ticket.cierre = new DateTime(07 / 02 / 2024);
                        break;
                    case 111:
                        ticket.ag.nombre = "Pedro Gómez";
                        ticket.tipo.tipo = "Consulta";
                        ticket.creacion = new DateTime(06 / 02 / 2024);
                        ticket.cierre = new DateTime(06 / 02 / 2024);
                        break;
                    case 112:
                        ticket.ag.nombre = "Ana Ramírez";
                        ticket.tipo.tipo = "Reclamo";
                        ticket.creacion = new DateTime(06 / 02 / 2024);
                        ticket.cierre = new DateTime(08 / 02 / 2024);
                        break;
                }
                if (ticket.tipo.tipo == "Consulta") // se asigna el sla según sea reclamo o consulta
                {
                    ticket.tipo.sla = 24;
                }
                else
                {
                    ticket.tipo.sla = 48;
                }
                DateTime limite = ticket.creacion.AddHours(ticket.tipo.sla); // se crea un tiempo limite
                if (ticket.cierre <= limite) // se compara si cumple con el sla
                {
                    if (!resueltosokConTiempo.ContainsKey(ticket.ag.nombre)) // se inicializa la biblioteca
                    {
                        resueltosokConTiempo[ticket.ag.nombre] = (0, TimeSpan.Zero);
                    }

                    resueltosokConTiempo[ticket.ag.nombre] = (resueltosokConTiempo[ticket.ag.nombre].ticketsResueltos + 1, resueltosokConTiempo[ticket.ag.nombre].totalTiempo + (ticket.cierre - ticket.creacion)); //se calcula el tiempo que le tomó al agente completar la tarea
                }
            }
            var mejorAgente = resueltosokConTiempo.OrderBy(x => x.Value.totalTiempo.TotalSeconds / x.Value.ticketsResueltos).FirstOrDefault(); // se crea un promedio para saber quien fue el agente mas efectivo en cuanto a tickets y tiempo

            Console.WriteLine($"El agente más efectivo fue: {mejorAgente.Key} "); // se muestra el resultado
            Console.ReadKey();

        }
    }
}
