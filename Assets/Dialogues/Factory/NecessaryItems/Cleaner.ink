INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left

可以有效清理掉地毯海葵汙染毒素，須由專業人士進行使用。

{getCleaner == false: 
    ~ ModifyMelancholy(-1)
}

~ getCleaner = true

~ ShowMission("完成任務：尋找清潔劑")

~ PlaySound("pick up")

獲得物品：清潔劑

~ Pickup()

-> END