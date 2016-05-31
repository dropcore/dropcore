using Newtonsoft.Json.Linq;

namespace DropCore.Configuration
{
    public class AppConfiguration
    {
        public string ApplicationPath { get; set; }
        public ModuleConfiguration[] Modules { get; set; }

        public void FromJson(JObject json)
        {
            Modules = json[nameof(Modules)].ToObject<ModuleConfiguration[]>();
        }
    }
}
