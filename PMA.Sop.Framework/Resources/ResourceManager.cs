using Microsoft.Extensions.Localization;
using PMA.Sop.Framework.Resources.Interface;

namespace PMA.Sop.Framework.Resources
{
    public class ResourceManager<TResource> : IResourceManager
    {
        private readonly IStringLocalizer<TResource> _stringLocalizer;
        public ResourceManager(IStringLocalizer<TResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public string GetName(string name)
        {
            return _stringLocalizer.GetString(name);
        }

        public string GetName(string name, params string[] arguments)
        {
            return _stringLocalizer.GetString(name, arguments);

        }

        public string this[string name] => _stringLocalizer[name];

        public string this[string name, params string[] arguments] => _stringLocalizer[name, arguments];
    }
}