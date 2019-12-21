using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_test_autoit
{
    public class TestBase
    {

        public ApplicationManager app;

        [OneTimeSetUp]
        public void InitApplication()
        {
            app = ApplicationManager.GetInstance();
        }


        //Метод помеченный данным атрибутом
        //Не подходит для параллельного запуска, реализовал через деструктор ApplicationManager
        //[OneTimeTearDown]
        //public void StopApplication()
        //{
        //    app.Stop();
        //}
    }

    
}
