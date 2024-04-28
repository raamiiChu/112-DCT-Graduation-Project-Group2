INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 逆行者隊長 #portrait: Narrator #layout: right

Layne，先前指派你去市集拿取我們這次任務的物資，你拿到了嗎？

    + {getDivingMask && getOxygenTank && getWetsuit && getUnderwaterCamera}[拿到了]
        很好，這次的任務主要是除了搜尋生存物資之外，也要請你與 Skyler 在都市遺跡中尋找是否有可用於建造機械的材料，像是貴金屬、或是還能用的電子零件等
        
        請你們在搜索物資的同時一邊尋找，人類與大家會感激你們的，謝謝你們的協助。
        
        # speaker: 腦內的聲音 #portrait: Narrator #layout: left
        你向隊長點頭致意後，隊長回覆你逆行者的專屬口號「向海前行！」，並且祝福你們啟程順利。
        
        ~ TriggerAppear()
        
        ~ ShowMission("與 Skyler 談話")
        
    + [還沒]
        為什麼你還沒有去拿？請你拿完後再來找我。

-> END