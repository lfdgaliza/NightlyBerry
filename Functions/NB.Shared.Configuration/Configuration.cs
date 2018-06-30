using NB.Shared.Configuration.Stages;
using System.Threading.Tasks;

namespace NB.Shared.Configuration
{
    public class Configuration
    {
        public async Task<string> Get(ConfigurationItem configurationItem)
        {
            ConfigurationChainBase configuration = CreateChain();
            return await configuration.Get(configurationItem);
        }

        private ConfigurationChainBase CreateChain()
        {
            ConfigurationChainBase chain;

            var prod = chain = new ConfigurationProduction();
            var dev = new ConfigurationDevelopment();

            prod.SetSucessor(dev);

            return prod;
        }
    }
}
