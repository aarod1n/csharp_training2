using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_test_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WINTITLE;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}