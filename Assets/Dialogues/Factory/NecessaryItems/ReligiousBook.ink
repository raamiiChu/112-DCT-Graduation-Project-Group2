INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

~ ShowCG(21)

# speaker: 旁白 #portrait: Narrator #layout: left

保存的極好，海水幾乎沒有對它造成任何影響。但為什麼會出現在這裡呢？


裡面收錄多首詩歌，用於聖地儀式和崇拜。

~ PlaySound("paper")
~ ShowImage(0)

<b>前</b>生繁事復不見，過<b>往</b>歲去未能還。<br>應有<b>洞</b>為人可活，莫知何<b>穴</b>眾所盼。

~ HideImage()

有什麼東西從教典裡飄了出來，你將其放入背包中

~ getReligiousBooks = true

~ ShowMission("完成任務：尋找教典")

獲得物品：教典、飄落的紙張<br>提示：按下 I 開啟背包後，點擊物品可以查看細節

~ Pickup()

-> END