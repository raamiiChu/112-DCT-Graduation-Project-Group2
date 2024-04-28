INCLUDE ../Globals.ink
INCLUDE ../ExternalFunctions.ink
VAR t = 3

-> main



=== main ===

{
    - CheckMelancholy() <= 20:
        -> TrueEnd
    - CheckMelancholy() > 20 && CheckMelancholy() <= 80:
        -> NormalEnd
    - CheckMelancholy() > 80 :
        -> BadEnd
}

-> END


=== TrueEnd ===
~ ChangeEndingBGM("true")

// ~ ShowCG()

# speaker: Layne #portrait: Layne #layout: left
我想起來了！只要......

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你的腦袋飛快地運轉，將當初你放置在那還沒有安裝的部件，使用從前對於藍圖線路的記憶拼接起來。）

// ~ ShowCG()

# speaker: Layne #portrait: Layne #layout: left
完成了！

# speaker: Skyler #portrait: Skyler #layout: right
太好了！那我們準備出發吧。

# speaker: 潛水艇 #portrait: Narrator #layout: right
系統已經安裝完成，自動駕駛模式已啟動，目的地：……。

~ ChangeScene("Credits")

-> DONE


=== NormalEnd ===
~ ChangeEndingBGM("normal")

// ~ ShowCG()

# speaker: Layne #portrait: Layne #layout: left
抱歉，我想了想還是想不起來。

// ~ ShowCG()

# speaker: Skyler #portrait: Skyler #layout: right
真的想不起來嗎？那就頭大了.....。

# speaker: Layne #portrait: Layne #layout: left
而且通往原本潛水艇的路線已經被封閉了。

# speaker: Skyler #portrait: Skyler #layout: right
看來只能找尋另外一條能夠回去的路了呢......。

-> DONE


=== BadEnd ===
~ ChangeEndingBGM("bad")

// ~ ShowCG()

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你選擇衝出艙門一把抓住 Rene ，但此時海水保護模式已經關閉。）

# speaker: Skyler #portrait: Skyler #layout: right
Layne！！你在做什麼！！

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（Skyler 衝去想將艙門關閉，然而海水此時灌進了潛水艇，潛水艇內部的設備因此損壞，進而引發爆炸。）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（由於你距離潛艇並不遠，因此你的身體也被炸傷。）

# speaker: Layne #portrait: Layne #layout: left
Rene，我這次不會再像之前一樣對你棄之不顧了.......。

# speaker: Rene #portrait: Rene #layout: right
謝謝你，這樣我們就能夠永遠在一起了呢。

-> DONE