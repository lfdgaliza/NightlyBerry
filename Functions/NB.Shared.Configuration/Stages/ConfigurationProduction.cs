namespace NB.Shared.Configuration.Stages
{
    public class ConfigurationProduction : ConfigurationChainBase
    {
        public ConfigurationProduction() : base(StageOption.Production) { }

        protected override string GetConnectionString()
        {
            return "Server=nightlyberry.cqm4dbzoplhr.us-east-1.rds.amazonaws.com;Database=nb_dev;User Id=nightlyberry;Password = gdmdu3D29!;";
        }
    }
}
