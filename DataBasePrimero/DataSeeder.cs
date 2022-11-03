using EntityBasicoDAL.Modelo;

namespace DataBasePrimero
{   
    public static class DataSeeder
    {
        //CON ESTA CLASE GENERAMOS LA INSERCION
        
            public static void Seed(this IHost host)
            {
                using var scope = host.Services.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<entityBasicoContext>();
                context.Database.EnsureCreated();
                AddEmpleados(context);
            }

        //AQUI CREAMOS EL OBJETO A INSERTAR
        private static void AddEmpleados(entityBasicoContext context)
        {
            var empleado = context.NivelAccesos.FirstOrDefault();

            context.Empleados.Add(new Empleado
            {
                Id = 4,
                NombreEmpleado = "Niki Hyden",
                NivelAccesos = new List<NivelAcceso> {

                    new NivelAcceso {
                        NivelAcceso1 = "Medio-Alto",
                        DescAcceso = "Corredor"
                    }
                }
            });

            context.SaveChanges();

            Console.WriteLine("Elemento insertado.");
        }
        
    }
}
