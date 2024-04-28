INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
 
地下室的門長年被鎖上，需要鑰匙才能打開。
 
 {getBasementKey:
    ~ PlaySound("unlock")
    你使用了在畫中找到的鑰匙。
    ~ Disappear()
  - else:
    找看看其他方法能開鎖吧。
    ~ ShowMission("接受任務：尋找開鎖的物品")
}
        
-> END