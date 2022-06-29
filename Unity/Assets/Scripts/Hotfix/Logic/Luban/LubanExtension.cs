using System.Collections.Generic;
using Hotfix.Model;
using Hotfix.Model.Put;

namespace Hotfix.Logic
{
    public static class LubanExtension
    {
        public static List<DRBuilding> GetBuildings(this TbBuilding tbBuilding, int buildingType)
        {
            List<DRBuilding> buildings = new List<DRBuilding>();
            for (int i = 0; i < tbBuilding.DataList.Count; i++)
            {
                DRBuilding drBuilding = tbBuilding.DataList[i];
                if(drBuilding.TypeId == buildingType)
                    buildings.Add(drBuilding);
            }
            return buildings;
        }
        
        public static List<Int2> GetType(this DRBuilding drBuilding, int type)
        {
            if (type == 1)
                return drBuilding.Type1;
            if (type == 2)
                return drBuilding.Type2;
            if (type == 3)
                return drBuilding.Type3;
            if (type == 4)
                return drBuilding.Type4;
            if (type == 5)
                return drBuilding.Type5;
            return default;
        }
    }
}
