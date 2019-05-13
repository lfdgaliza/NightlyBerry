using System;
using System.Collections.Generic;
using System.Linq;
using DistroGuide.App_Domain.CrossCutting.VO;
using DistroGuide.App_Domain.Repository;
using DistroGuide.App_Domain.Repository.Entities;
using DistroGuide.App_Domain.Services;
using DistroGuide.App_Impl.Repository;
using DistroGuide.App_Impl.Repository.Config;
using Microsoft.EntityFrameworkCore;

namespace DistroGuide.App_Impl.Services
{
    public class DistroService : IDistroService
    {
        // TODO create a centralized place to the constants
        const string ALL_DISTROS = "ALL_DISTROS";

        // TODO must be in a configurations file
        const int UPDATE_INTERVAL_ALL_DISTROS_IN_MINUTES = 1;

        private readonly ICacheService cacheService;
        private readonly IQueryDistroRepository queryDistroRepository;
        public DistroService(
            ICacheService cacheService,
            IQueryDistroRepository queryDistroRepository)
        {
            this.cacheService = cacheService;
            this.queryDistroRepository = queryDistroRepository;

            ConfigureCache(ALL_DISTROS, UPDATE_INTERVAL_ALL_DISTROS_IN_MINUTES);
        }
        public List<DistroSearchItemVO> GetDistrosByTerm(string term)
        {
            term = term.Trim();

            var availableDistros = this.cacheService.GetData<List<DistroSearchItemVO>>(ALL_DISTROS);

            // TODO list:
            // Search by starts with
            // Then by contains
            // Then by basedOn starts with
            // Then by basedOn contains

            return availableDistros
            .Where(d => d.N.Contains(term))
            .OrderBy(b => b.N.Length)
            .ToList();
        }

        private void ConfigureCache(string name, int updateIntervalInMinutes)
        {
            Func<List<DistroSearchItemVO>> funcUpdateData = () =>
            {
                // TODO refactor
                var options = new DbContextOptions<DistroGuideContext>();
                var optionsBuilder = new DbContextOptionsBuilder(options);
                optionsBuilder.UseMySQL(Startup.ConnectionString);
                options = (DbContextOptions<DistroGuideContext>)optionsBuilder.Options;

                var queryDistroRepository = new QueryDistroRepository(new DistroGuideContext(options));

                return queryDistroRepository
                    .GetAllDistros()
                    .Select(d => new DistroSearchItemVO
                    {
                        B = d.BasedOnId,
                        I = d.Id,
                        N = d.Name,
                        P = d.IconUrl
                    })
                    .ToList();
            };

            if (!this.cacheService.Has(ALL_DISTROS))
            {
                this.cacheService.NewUpdatable(
                    name,
                    updateIntervalInMinutes,
                    funcUpdateData);
            }
        }
    }
}