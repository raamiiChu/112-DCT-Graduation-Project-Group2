INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

-> main

=== main ===

~ ShowSkyler()

# speaker: Layne #portrait: Layne #layout: left
.......

# speaker: Skyler #portrait: Skyler #layout: right
這難道就是那艘傳說中的永動潛水艇嗎！

# speaker: Layne #portrait: Layne #layout: left
我不確定這究竟是不是。

# speaker: Skyler #portrait: Skyler #layout: right
朋友，原來你就是創造傳說的人。

# speaker: Layne #portrait: Layne #layout: left
但我完全不記得我是怎麼做出這艘潛水艇的。

# speaker: Skyler #portrait: Skyler #layout: right
我也從來沒想過我的好朋友竟然能夠做出這樣子的潛水艇。

# speaker: Layne #portrait: Layne #layout: left
就算當他是我造的好了，但我現在對這艘潛水艇的設計細節基本上全忘光了。甚至我連他要怎麼發動我都不確定。


# speaker: Skyler #portrait: Skyler #layout: right
嗯.......難道你沒有曾經畫過藍圖之類的嗎？說不定我們能夠找到。

{getBlueprint:
    -> FoundBlueprint
  - else:
    -> NotFoundBlueprint
}

-> END

=== NotFoundBlueprint ===

# speaker: Layne #portrait: Layne #layout: left
找找看就知道了。

~ ShowMission("接受任務：尋找藍圖")

-> DONE

=== FoundBlueprint ===

# speaker: Layne #portrait: Layne #layout: left
難道是剛剛在地下室前方鐵桌上的那張嗎？

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你拿起剛剛那張藍圖圖紙，仔細瞧過後發現上面能夠用的資訊不多，但有提及到，要使這艘潛水艇啟動，必須要使用一種特殊礦石才能夠使其運作。）

# speaker: Skyler #portrait: Skyler #layout: right
說不定我們在舊工廠拿到的東西能夠幫到我們？

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你從背包中取出了那塊研究員的邊角料，並且將其卡進潛水艇外部對應的位置。）

~ PlaySound("hatch open")
# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（把它裝進去後不到十秒，整台潛水艇的電力系統便啟動，並且自動打開艙門。）

# speaker: Skyler #portrait: Skyler #layout: right
他啟動了！

~ ShowCG(24)

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
艙門打開後，映入眼簾的是擁有駕駛座雙人座椅的狹小空間。然而更神奇的是，潛水艇裡面就像是有一股屏障一樣，導致海水沒有直接灌進其中。

# speaker: Skyler #portrait: Skyler #layout: right
這艘潛水艇也太先進了吧！我們趕快進入看看他能不能夠開吧。

~ HideSkyler()
~ HideLayne()

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（Layne & Skyler 一起進入到潛水艇）

~ ShowRene()
~ ShowCG(25)

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（當你一坐上座椅，你注意到潛水艇外有一個正在哭泣的聲音，你向聲音傳出的地方望去，發現是 Rene 在外頭看著你。）

# speaker: Rene #portrait: Rene #layout: right
不要再一次拋下我.......。

# speaker: Layne #portrait: Layne #layout: left
Rene 你在外面做什麼？趕快進來呀！

# speaker: Rene #portrait: Rene #layout: right
裡面空間太小了，我沒有辦法擠進去了。

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（此時 Skyler 表情嚴肅地看著你。）

# speaker: Skyler #portrait: Skyler #layout: right
你在跟誰說話？

~ PlaySound("alarm")

# speaker: 潛水艇 #portrait: Narrator #layout: right
海水保護模式即將在十秒後關閉，請盡速關閉艙門，以防海水灌入。

* [關閉艙門]
    你真的狠心嗎？
    
    ** [關閉艙門]
        -> CloseTheHatch
        
    ** [一把抓住Rene]
        -> BadEnd
        
* [一把抓住Rene]
    -> BadEnd

-> DONE

=== CloseTheHatch ===
~ PlaySound("hatch open")

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你不顧 Rene 不斷哭泣，果斷地將艙門關上）

# speaker: Skyler #portrait: Skyler #layout: right
你沒事吧？你看起來很糟。

# speaker: Layne #portrait: Layne #layout: left
我沒事的，我們走吧。

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你按下了潛水艇的啟動鈕。）

# speaker: 潛水艇 #portrait: Narrator #layout: right
駕駛模式已開啟，但由於系統關鍵部位尚未安裝，因此無法啟動引擎。

# speaker: Skyler #portrait: Skyler #layout: right
尚未安裝？這艘潛水艇不是已經建造完的了嗎？

# speaker: Layne #portrait: Layne #layout: left
看來當時的我只差臨門一腳。

# speaker: Skyler #portrait: Skyler #layout: right
那你還記得那個部件是什麼嗎？如果我們沒有辦法完成這一個步驟，我們找到這艘潛水艇也沒有用。

~ StartSpawnBlocks()

# speaker: Layne #portrait: Layne #layout: left
我努力想想 .......

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你開始強力思索以前建造潛水艇的記憶。）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（然而許多伴隨而來的情緒也向你衝擊而來。）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（悲傷）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（焦慮）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（痛苦）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（憤怒）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（茫然）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（困惑）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（大量負面情緒充斥在你的腦海中...）

{
    - CheckMelancholy() <= 50:
        -> TrueEnd

    - else:
        -> NormalEnd
}

-> DONE


=== TrueEnd ===
~ ChangeEndingBGM("true")

~ StopSpawnBlocks()

~ ShowCG(16)

# speaker: Layne #portrait: Layne #layout: left
我想起來了！只要......

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你的腦袋飛快地運轉，將當初你放置在那還沒有安裝的部件，使用從前對於藍圖線路的記憶拼接起來。）

~ ShowCG(17)

# speaker: Layne #portrait: Layne #layout: left
完成了！

# speaker: Skyler #portrait: Skyler #layout: right
太好了！那我們準備出發吧。

# speaker: 潛水艇 #portrait: Narrator #layout: right
系統已經安裝完成，自動駕駛模式已啟動，目的地：……。

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
END 3：航向未知

~ ChangeScene("Credits")

-> DONE


=== NormalEnd ===
~ ChangeEndingBGM("normal")

~ StopSpawnBlocks()

~ ShowCG(14)

# speaker: Layne #portrait: Layne #layout: left
抱歉，我想了想還是想不起來。

~ ShowCG(15)

# speaker: Skyler #portrait: Skyler #layout: right
真的想不起來嗎？那就頭大了.....。

# speaker: Layne #portrait: Layne #layout: left
而且通往原本潛水艇的路線已經被封閉了。

# speaker: Skyler #portrait: Skyler #layout: right
看來只能找尋另外一條能夠回去的路了呢......。

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
END 2：此路不通

~ ChangeScene("Credits")

-> DONE


=== BadEnd ===
~ ChangeEndingBGM("bad")

~ ShowCG(13)

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你選擇衝出艙門一把抓住 Rene ，但此時海水保護模式已經關閉。）

# speaker: Skyler #portrait: Skyler #layout: right
Layne！！你在做什麼！！

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（Skyler 衝去想將艙門關閉，然而此時艙門已經因為海水保護模式而自動關閉，並且暫時無法開啟。）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（你看到 Rene 朝遠方走去，你也隨之跟上，但你發現你無論怎麼樣追趕，Rene 始終和你保持一段距離。）

# speaker: Skyler #portrait: Skyler #layout: right
Layne！你要去哪裡？

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（Skyler 隔著駕駛艙的玻璃對你大喊，但你彷彿像沒有聽到一般，直呼呼地向外遠去）

# speaker: Layne #portrait: Layne #layout: left
Rene，我這次不會再像之前一樣對你棄之不顧了.......，Rene！

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
（即使你一直呼叫 Rene ，Rene 也並沒有回應你，只是一直往家外面移動，你也隨之快速跟上，跑向了你陌生的地方……）

# speaker: 腦內的聲音 #portrait: Narrator #layout: left
END 1 ：深海中的追隨者

~ ChangeScene("Credits")

-> DONE