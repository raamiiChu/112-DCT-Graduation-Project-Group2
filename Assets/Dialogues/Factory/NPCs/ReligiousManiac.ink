INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

VAR attitudeOfReligiousManiac = 0

-> main

=== main ===
{
    - firstMeetReligiousManiac:
        -> FirstMeet
    - !getReligiousBooks:
        -> NotFindBooks
    - getReligiousBooks:
        -> FindBooks
}

-> END

=== FirstMeet ===

~ firstMeetReligiousManiac = false

不好意思，可以借過一下嗎。 # speaker: Layne #portrait: Layne #layout: left

噢，遠方的旅人啊，一定是神的指引讓你來到這裡。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

（太久沒看到舊人類了，現在的舊人類都這麼奇怪的嗎） # speaker: Layne #portrait: Layne #layout: left

所以，我可以過去了嗎？ # speaker: Layne #portrait: Layne #layout: left

主啊，遠方的旅人想要前往聆聽您的福音，尋找您的經典，跟隨您的意志，獲得喜樂和平靜…… # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

謝謝，但不用了，我趕時間。 # speaker: Layne #portrait: Layne #layout: left

聽我說完，讓我拯救你。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

什麼？ # speaker: Layne #portrait: Layne #layout: left

拯救你免於如果不聽我說完，我將會對你做的事情。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

    * [……好吧，你繼續說。]
        ~ ModifyMelancholy(10)
        ~ ModifySanity(-10)
        
        信主將拯救你的靈魂，接受主作生命，主將叫你得新生，我們藉水了結舊造，埋葬舊生命，而有了靈…… # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right
        
    * [……你有病吧？]
        ~ ModifySanity(-5)
        ~ attitudeOfReligiousManiac = 1
    
        這人若不是從神來的，什麼也不能做，恕我不能放你過去。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

        ……好吧，我錯了，你繼續說。 # speaker: Layne #portrait: Layne #layout: left
    
        主將憐憫你的罪，拯救你迷路的靈魂，藉著海水叫你得新生…… # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

- （只見他愈說愈沉浸在自己的世界，而你是一點也聽不懂了） # speaker: Layne #portrait: Layne #layout: left

好的，所以我現在是否可以過去了？ # speaker: Layne #portrait: Layne #layout: left

親愛的弟兄，當然可以，只要你順手帶回神的經典。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

教典不是在你手上嗎？ # speaker: Layne #portrait: Layne #layout: left

噢，每部經典我都擁有三本，一本每天翻閱、一本好好收藏、一本按神的意志流向不同的地方，而你將依循神的指引，找到流落在廢棄區的經典。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

~ ShowMission("接受任務：尋找教典")

去吧，願主與你同在。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

~ TeleportPlayer(18.5, -0.5, -30)

-> DONE

=== NotFindBooks ===
……的神，我們感謝讚美您，您賜予我全新的生命，我也願意將我的心靈奉獻給您，求主進入我的靈魂來充滿我，天天更新我的心思意念，使我可以按您的指引、您的旨意而活…… # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

~ ModifySanity(-1)

光聽他講話就會掉 SAN 的可怕人物 # speaker: Layne #portrait: Layne #layout: left

趕緊找到教典把他打發走吧 ......

~ TeleportPlayer(18.5, -0.5, -30)

-> DONE

=== FindBooks ===
噢，親愛的弟兄，主與你同在，這本經典順著主的意志被你找到，我便將其交付予你，願你能時時聽從神的教誨。 # speaker: 宗教狂 #portrait: ReligiousManiac #layout: right

~ Disappear()

-> DONE