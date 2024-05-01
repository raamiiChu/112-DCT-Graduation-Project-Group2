INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

-> main

=== main ===

~ HideBlackScreen()

我們先看看你都帶了哪些東西出來 # speaker: Skyler #portrait: Skyler #layout: right

（你簡單地向 Skyler 交代剛剛探索的經過） # speaker: Layne #portrait: Layne #layout: left

那麼，關於我們接下來要去哪裡探索，你有什麼想法？ # speaker: Skyler #portrait: Skyler #layout: right

-> chooseEvidence

-> END

=== chooseEvidence === 
* [根據研究報告]
    ~ ModifyMelancholy(5)
    ~ ModifySanity(-5)

    我在研究區找到幾份研究報告，其中有一份上面畫了潛水艇的圖紙，但…… # speaker: Layne #portrait: Layne #layout: left

    但看不太清楚呢，不知道可以從哪下手。 # speaker: Skyler #portrait: Skyler #layout: right
    
    -> chooseEvidence
  
* [根據邊角料]
    ~ ModifyMelancholy(5)
    ~ ModifySanity(-5)
    
    那個工作狂最後塞給我這個，但我沒聽清它的用途…… # speaker: Layne #portrait: Layne #layout: left

    你挺會組裝和修理設備的，認得這東西是什麼嗎？ # speaker: Layne #portrait: Layne #layout: left

    這……好像在哪看過，但一時之間我也想不起來。 # speaker: Skyler #portrait: Skyler #layout: right
    
    -> chooseEvidence

* [根據教典]
    ~ ModifyMelancholy(-10)
    ~ ModifySanity(5)
    
    ~ ShowImage(0)
    我找到的教典裡夾了一張紙，有人說看到在海底獲得新生的希望，並稱其為神蹟。 # speaker: Layne #portrait: Layne #layout: left

    然後依照教典中這一頁的敘述，我推測這裡應該是指<color=blue>海底洞穴</color>。 # speaker: Layne #portrait: Layne #layout: left
    
    好，那我們就去<color=blue>海底洞穴</color>看看。 # speaker: Skyler #portrait: Skyler #layout: right
    
    ~ HideImage()
    ~ ChangeScene("Pray")

    -> DONE