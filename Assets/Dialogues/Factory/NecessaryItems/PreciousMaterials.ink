INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left

不小心被混進廢棄區的珍貴機關原物料，幸好尚未毀損。

~ getPreciousMaterials = true

~ ShowMission("完成任務：尋找珍貴原料")

在撈取珍貴原料的途中，你發現了一張舊照片，出於好奇你決定將它收進背包。

~ Pickup()

獲得物品：珍貴原料、舊照片

-> END