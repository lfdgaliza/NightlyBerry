using System;

namespace NB.Shared.Configuration
{
    public abstract class ConfigurationChainBase
    {
        protected ConfigurationChainBase(StageOption treatingStage) => _treatingStage = treatingStage;
        public void SetSucessor(ConfigurationChainBase successor) => _successor = successor;
        public string Get(ConfigurationItem configurationItem)
        {
            return CurrentStage == _treatingStage
                ? RetrieveConfiguration(configurationItem)
                : _successor.Get(configurationItem);
        }
        
        private ConfigurationChainBase _successor = null;
        private StageOption CurrentStage
        {
            get
            {
                if (Enum.TryParse(Environment.GetEnvironmentVariable("Stage"), out StageOption currentStage))
                    return currentStage;

                Console.WriteLine("[NB.Shared.Configuration] You must setup the \"Stage\" Environment Variable in order to use configuration");
                throw new NotSupportedException();
            }
        }

        private StageOption _treatingStage;
        

        private string RetrieveConfiguration(ConfigurationItem configurationItem)
        {
            switch (configurationItem)
            {
                case ConfigurationItem.ConnectionString:
                    return GetConnectionString();
                default:
                    Console.WriteLine("[NB.Shared.Configuration] You are trying to use a configuration that was not implemented yet");
                    throw new NotImplementedException();
            }
        }

        protected abstract string GetConnectionString();
    }
}
