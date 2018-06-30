
using System;
using System.Threading.Tasks;

namespace NB.Shared.Configuration.Stages
{
    public class ConfigurationProduction : ConfigurationChainBase
    {
        public ConfigurationProduction() : base(StageOption.Production) { }

        protected override async Task<string> GetConnectionString()
        {
            throw new NotImplementedException();
        }
    }
}
