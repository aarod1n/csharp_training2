using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoItX3Lib;

namespace addressbook_test_autoit
{
    public class ApplicationManager
    {

        //Для передачи нового объекта разным потокам в параллельном запуске тестов
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        //Сохраним название окна приложения для более удобного использования
        public static string WINTITLE = "Free Address Book";
        
        //Объект для работы с приложением
        private AutoItX3 aux;
        
        //Создаем объект GroupHelper и передаем в него ApplicationManager
        private GroupHelper groupHelper;

        //Конструктор вызываем в GetInstance()
        private ApplicationManager()
        {
            aux = new AutoItX3();
            //Запуск приложения + aux.SW_SHOW для отображения данного приложения
            aux.Run(@"c:\FreeAddressBook\AddressBook.exe", "", aux.SW_SHOW);

            //Ждем появления окна WINTITLE = "Free Address Book"
            aux.WinWait(WINTITLE);

            //Делаем его активным
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);

            //Создаем объект типа GroupHelper и передаем в него ApplicationManager
            groupHelper = new GroupHelper(this);
        }

        //Через деструктор закрываем приложение
        ~ApplicationManager()
        {
            this.Stop();
        }

        public void Stop()
        {
            //Название окна, текст кнопки(необязательный), идентификатор кнопки
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }

        }

        public AutoItX3 Aux
        {
            get { return aux; }
        }

        //Возвращаем объект менеджера для потока, если в данном потоке его нет. 
        //Для каждого потока свой. При параллельном запуске тестов, открываем приложение один раз, в каждои потоке.
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                app.Value = newInstance;
            }
            return app.Value;
        }






    }
}

