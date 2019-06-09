using AutoMapper;
using DistroGuide.Domain.Model.Entities.Distros;
using DistroGuide.Domain.Repository;
using DistroGuide.Domain.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DistroGuide.Domain.Services.Impl
{

    public class DistroService : IDistroService
    {
        // TODO create a centralized place to the constants
        const string ALL_DISTROS = "ALL_DISTROS";

        // TODO must be in a configurations file
        const int UPDATE_INTERVAL_ALL_DISTROS_IN_MINUTES = 1;

        private readonly ICacheService cacheService;
        private readonly ISingletonRepository singletonRepository;

        public DistroService(
            ICacheService cacheService,
            ISingletonRepository singletonRepository)
        {
            this.cacheService = cacheService;
            this.singletonRepository = singletonRepository;

            ConfigureCache(ALL_DISTROS, UPDATE_INTERVAL_ALL_DISTROS_IN_MINUTES);
        }

        public List<DistroSearchItemDto> GetDistrosByTerm(string term)
        {
            term = term.Trim();

            var availableDistros = this.cacheService.GetData<List<Distro>>(ALL_DISTROS);

            // TODO list:
            // Search by starts with
            // Then by contains
            // Then by basedOn starts with
            // Then by basedOn contains
            var filteredDistros = availableDistros
            .Where(d => d.Name.Contains(term))
            .OrderBy(b => b.Name.Length)
            .ToList();

            return Mapper.Map<List<DistroSearchItemDto>>(filteredDistros);
        }

        private void ConfigureCache(string name, int updateIntervalInMinutes)
        {
            Func<List<Distro>> funcUpdateData = () =>
            {
                return singletonRepository
                    .GetAllDistros()
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
