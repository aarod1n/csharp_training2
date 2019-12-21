using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_autoit
{
    //Наследуемся от HelperBase для получения доступа к полям manager и WINTITLE
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupDate> GetGroupList()
        {
            List<GroupDate> list = new List<GroupDate>();
            OpenGroupEditorDialogue();
            //Получаем кол-во элементов в дереве
            string count = manager.Aux.ControlTreeView("Group editor", "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");

            //Проходим по всему дереву, получаем текст каждого элемента дерева
            for(int i =0; i < int.Parse(count); i++)
            {
                string item = manager.Aux.ControlTreeView("Group editor", "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                list.Add(new GroupDate()
                { 
                    Name = item
                });
            }
            CloseGroupEditorDialogue();
            return list;
        }

        public void AddGroup(GroupDate newGroup)
        {
            //В запущеной прогремме кликаем по кнопке создать новую группу
            OpenGroupEditorDialogue();
            manager.Aux.ControlClick("Group editor", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            manager.Aux.Send(newGroup.Name);
            manager.Aux.Send("{ENTER}");
            CloseGroupEditorDialogue();
        }

        public void CloseGroupEditorDialogue()
        {
            manager.Aux.ControlClick("Group editor", "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupEditorDialogue()
        {
            manager.Aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            manager.Aux.WinWait("Group editor");
        }

        
    }
}
