namespace Masa.EShop.Web.Admin
{
    public abstract class ProCompontentBase : ComponentBase
    {
        private I18n? _i18n;

        [CascadingParameter]
        public I18n I18n
        {
            get
            {
                return _i18n ?? throw new Exception("please Inject I18n!");
            }
            set
            {
                _i18n = value;
            }
        }

        public string T(string key)
        {
            return I18n.T(key) ?? key;
        }
    }
}