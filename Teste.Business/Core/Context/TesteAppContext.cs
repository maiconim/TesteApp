using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Teste.Business.Core.Entity;

namespace Teste.Business.Core.Context
{
    internal class TesteAppContext : DbContext
    {
        private static object _lock = new object();
        private static bool _migrationsApplied = false;
        private static readonly List<object?> _maps = new();

        public TesteAppContext(DbContextOptions options) : base(options)
        {
            _maps.AddRange(BuscarMapeamentos(typeof(TesteAppContext).Assembly));
            ApplyMigrates();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterMaps(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Aplica todas as migrações faltantes
        /// </summary>
        private void ApplyMigrates()
        {
            lock (_lock)
            {
                if (_migrationsApplied)
                    return;

                if (!this.AllMigrationApplied())
                    Database.Migrate();

                _migrationsApplied = true;
            }
        }

        /// <summary>
        /// Lista todas os mapeamentos encontrados no projeto
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        protected virtual List<object?> BuscarMapeamentos(params Assembly[] assemblies)
        {
            var result = new List<object?>();
            var baseEntityMap = typeof(BaseEntityMap<>);

            foreach (var a in assemblies)
                result.AddRange(
                    a.GetTypes()
                        .Where(w => !w.IsInterface && !w.IsAbstract && w.BaseType != null && w.BaseType.IsGenericType)
                        .Where(w => w.BaseType != null && (w.BaseType.GetGenericTypeDefinition() == baseEntityMap))
                        .Select(s => Activator.CreateInstance(s))
                        .ToList());

            return result;
        }

        /// <summary>
        /// Registra todos os mapeamentos no EF
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void RegisterMaps(ModelBuilder modelBuilder)
        {
            var method = modelBuilder
                .GetType()
                .GetMethod("ApplyConfiguration");

            if (method == null)
                return;

            foreach (var map in _maps)
            {
                if (map == null)
                    continue;

                var mapType = map
                    .GetType()
                    .GetInterfaces()
                    .FirstOrDefault(f => f.IsGenericType && f.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

                if (mapType == null)
                    continue;

                method
                    .MakeGenericMethod(mapType.GenericTypeArguments[0])
                    .Invoke(modelBuilder, new object[] { map });
            }
        }
    }
}