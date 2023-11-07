using System.Collections.Generic;
using Character.ItemManagement.InventoryManagement;
using Character.ItemManagement.Items;
using UnityEngine;

namespace Building.Resources
{
    public class ResourcePackage
    {
        public Dictionary<string, int> _resDict;

        // public bool GetResource
        // (
        //         ref Dictionary<string, int> resDict,
        //         Inventory inventory,
        //         List<ResourceDescription> descriptions
        // )
        // {
        //     int length = descriptions.Count;
        //
        //     for (int i = 0; i < length; i++)
        //     {
        //         string itemName = descriptions[i].GetName();
        //
        //         int lengthJ = inventory.GetCount();
        //
        //         for (int j = 0; j < lengthJ; j++)
        //         {
        //             if (inventory.GetItem(j).Data.GetName() == itemName)
        //             {
        //                 int itemCount = descriptions[i].GetCount();
        //                 
        //                 for (int k = 0; k < itemCount; k++)
        //                 {
        //                     
        //                 }
        //                 
        //                 if (resDict.TryGetValue(itemName, out int count))
        //                 {
        //                     resDict.Add(itemName, count + 1);
        //                 }
        //                 else
        //                 {
        //                     break;
        //                 }
        //             }
        //             else
        //             {
        //                 break;
        //             }
        //         }
        //     }
        // }
            
        private bool CheckRes(ref List<Item> list, string name, int count)
        {
            List<Item> newList = list;
            list = null;
            
            for (int i = 0; i < newList.Count; i++)
            {
                var item = newList[i];

                if (item.Data.GetName() == name && list.Count < count)
                {
                    list.Add(item);
                    newList.Remove(item);
                }
            }

            return newList.Count == count;
        }

        public bool GetResource(ref List<Item> list, Inventory inventory, List<ResourceDescription> descriptions)
        {
            List<Item> newList = new();
            
            int length = descriptions.Count;
            
            for (int i = 0; i < length; i++)
            {
                if (CheckRes(ref list, 
                            descriptions[i].GetName(), 
                            descriptions[i].GetCount()))
                {
                    int length2 = list.Count;
                    
                    for (int j = 0; j < length2; j++)
                        newList.Add(list[i]);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void Test(Inventory inventory, List<ResourceDescription> descriptions)
        {
            List<Item> list = GetListItems(inventory);

            if (GetResource(ref list, inventory, descriptions))
            {
                Debug.Log("YES");
            }
        }
        
        private List<Item> GetListItems(Inventory inventory)
        {
            List<Item> list = new();

            int length = inventory.GetCount();

            for (int i = 0; i < length; i++)
                list.Add(inventory.GetItem(i));

            return list;
        }
    }
}