using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.DataAccessLayer
{
    public class DepartmentDAL
    {

        public static DataTable Search_Departments()
        {

            DataTable dt = new DataTable();

            using (EleventaDbContext dbCtx = new EleventaDbContext())
            {

                //en una variable generica guardamos los datos de la table Department
                var result = dbCtx.Departments.ToList();

                //Agregamos las Columnas al DataTable
                dt.Columns.AddRange(new DataColumn[]
                {

                    new DataColumn("Id", typeof(int)),
                    new DataColumn("Nombre", typeof(string)),
                    new DataColumn("Descripcion", typeof(string))

                });


                result.ToList().ForEach(x =>
                {

                    //Variable Generia para guardar la las filas traidas de la tabla
                    //Department de la base de datos
                    var row = dt.NewRow();

                    //Le asignamos a cada columna las filas
                    row["Id"] = x.Id;
                    row["Nombre"] = x.Nombre;
                    row["Descripcion"] = x.Descripcion;

                    //Y despues las añadimos al DataTable
                    dt.Rows.Add(row);

                });

            }

            return dt;
        }

    }
}
