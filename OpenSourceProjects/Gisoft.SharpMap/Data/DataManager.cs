using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft.SharpMap.Data
{
    public class DataManager
    {
        static DataManager()
        {

        }
        DataManager()
        {

        }
        private static object _locker = new object();
        private static DataManager _instance;
        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void RegistProvider(string extension,Type providerType)
        {
            _providerMap.Add(extension, providerType);
        }

        private Dictionary<string, Type> _providerMap = new Dictionary<string, Type>();

        
    }
}
