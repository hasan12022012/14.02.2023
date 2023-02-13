using System;
using System.Collections.Generic;
using System.Text;

namespace tasK
{
    internal interface ICourse
    {
        Group[] AddGroup(Group groups);
        Group GetGroupByNo(string no);

        Group[] GetGroupsByPointRange(int minPoint,int maxPoint);
        Group[] Search(string search);
    }
}
