using DistroGuide.Domain.Model.Entities.Distros;
using DistroGuide.Domain.Repository.Impl.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DistroGuide.Domain.Repository.Impl
{
    public class SingletonRepository : ISingletonRepository
    {
        private readonly DbContextOptions<DistroGuideContext> options;

        public SingletonRepository(string connectionString)
        {
            options = new DbContextOptions<DistroGuideContext>();
            var optionsBuilder = new DbContextOptionsBuilder(options);
            optionsBuilder.UseSqlServer(connectionString);
            options = (DbContextOptions<DistroGuideContext>)optionsBuilder.Options;
        }

        public List<Distro> GetAllDistros()
        {
            using (var context = new DistroGuideContext(options))
            {
                var queryDistroRepository = new QueryDistroRepository(context);
                return queryDistroRepository.GetAllDistros().ToList();
            }
        }
    }
}
