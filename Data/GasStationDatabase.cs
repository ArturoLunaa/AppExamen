using AppGasolinerasExamen.Extensions;
using AppGasolinerasExamen.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGasolinerasExamen.Data
{
    public class GasStationDatabase
    {
        //Instanciamos y abrimos la conexión a SQLite donde Lazy nos permite generar la conexión, sin que se bloquee nuestra app
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() => 
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        //Variable estática para regresar la conexión de SQLite
        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        //Variable estática para saber si la base de datos de SQLite está inicializada
        static bool isInitialized = false;

        //Constructor
        public GasStationDatabase()
        {
            //Llamamos el método inicializar con la extensión llamado seguro
            InitializeAsync().SafeFireAndForget(false);
        }

        //Método para inicializar la tabla de gasStation si no existe
        async Task InitializeAsync()
        {
            if (!isInitialized)
            {
                if(!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GasStationModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(GasStationModel)).ConfigureAwait(false);
                    isInitialized = true;
                }
            }
        }

        //Métodos CRUD para TaskModel
        public Task<List<GasStationModel>> GetAllGasStationsAsync()
        {
            return Database.Table<GasStationModel>().ToListAsync();
        }

        public Task<GasStationModel> GetGasStationAsync(int id)
        {
            return Database.Table<GasStationModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveGasStationAsync(GasStationModel model)
        {
            if(model.ID == 0)
            {
                //Crear
                return Database.InsertAsync(model);
            }
            else
            {
                //Actualizar
                return Database.UpdateAsync(model);
            }
        }

        public Task<int> DeleteGasStationAsync(GasStationModel model)
        {
            //Eliminar
            return Database.DeleteAsync(model);
        }
    }
}
