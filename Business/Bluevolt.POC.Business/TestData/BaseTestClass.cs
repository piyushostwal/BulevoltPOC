using Bluevolt.POC.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluevolt.POC.Business.TestData
{
    public class BaseTestClass
    {
        #region Declarations

        private IDataService _instance = null;

        protected IDataService CreateInstance()
        {
            if (_instance == null)
            {
                TestData.PopulateUserData();
                string unitySectionName = ConfigurationManager.AppSettings["UnitySectionName"] ?? "unity";
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(unitySectionName);

                IUnityContainer container = new UnityContainer();
                section.Configure(container, "Services");
                _instance = container.Resolve<IDataService>();
            }

            return _instance;
        }

        #endregion

        public IDataService DataService
        {
            get
            {
                return CreateInstance();
            }
        }
    }
}
