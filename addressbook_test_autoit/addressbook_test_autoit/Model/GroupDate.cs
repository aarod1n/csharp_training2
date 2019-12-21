using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_autoit
{
    public class GroupDate : IComparable<GroupDate>, IEquatable<GroupDate>
    {
        public string Name { get; set; }

        public int CompareTo(GroupDate other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(GroupDate other)
        {
            return this.Name.Equals(other.Name); 
        }
    }

    
}
