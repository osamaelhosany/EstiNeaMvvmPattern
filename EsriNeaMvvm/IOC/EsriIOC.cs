namespace EsriNeaMvvm
{
    public class EsriIOC
    {
        static EsriIOC()
        {
        }

        static IEsriIOC _freshIOCContainer;

        public static IEsriIOC Container
        {
            get
            {
                if (_freshIOCContainer == null)
                    _freshIOCContainer = new FreshTinyIOCBuiltIn();

                return _freshIOCContainer;
            }
        }

        public static void OverrideContainer(IEsriIOC overrideContainer)
        {
            _freshIOCContainer = overrideContainer;
        }
    }
}

