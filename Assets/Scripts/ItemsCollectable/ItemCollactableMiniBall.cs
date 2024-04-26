using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableMiniBall : ItemCollactableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddMiniBall();
    }
}
