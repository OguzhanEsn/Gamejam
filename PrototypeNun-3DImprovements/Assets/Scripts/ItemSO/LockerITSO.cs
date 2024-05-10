using System.Collections.Generic;
using MiniGames;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Locker")]
public class LockerITSO : ItemSO
{
    public bool isLocked;
    public LockDifficulty lockDifficulty;
    public bool isRandomed;
    public bool isKeyNeeded;
    public int LockerID;
    public List<ItemSO> itemsInLocker;

}
