using NB.Shared.Configuration.Stages;

namespace NB.Shared.Configuration
{
    public class Configuration
    {
        public string Get(ConfigurationItem configurationItem)
        {
            ConfigurationChainBase configuration = CreateChain();
            return configuration.Get(configurationItem);
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
