INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

VAR attitudeOfWorkaholic = 0

-> main

=== main ===
{
    - firstMeetWorkaholic:
        -> FirstMeet
    - getCleaner && !hasTriggeredFindCleaner:
        -> FindCleaner
    - getPreciousMaterials && !hasTriggeredFindPreciousMaterials:
        -> FindPreciousMaterials
    - else:
        -> Default
}

-> END

=== FirstMeet ===
~ firstMeetWorkaholic = false
不好意思，打擾一下。 # speaker: Layne #portrait: Layne #layout: left

（這個人正在敲程式碼，好像沒聽到你在叫他） # speaker: 腦內的聲音 #portrait: Narrator #layout: left


那個，你好？ # speaker: Layne #portrait: Layne #layout: left

（這個人正在瘋狂改程式碼，看起來沒空理你） # speaker: 腦內的聲音 #portrait: Narrator #layout: left

    * [直接進去看看]
        ~ attitudeOfWorkaholic = 0
        ~ ModifyMelancholy(5)
        ~ ModifySanity(-5)
        
        再不理我我就直接進去了喔？ #speaker: Layne #portrait: Layne #layout: left
    
        你、你是誰啊！什麼時候過來的？ #speaker: 工作狂 #portrait: Workaholic #layout: right
    
        我是... #speaker: Layne #portrait: Layne #layout: left
    
        好了這個不重要，你們這些新來的能不能機靈點啊，每次進來都沒在看的，沾一堆毒過來，專給我增加不必要的工作量。 #speaker: 工作狂  #portrait: Workaholic #layout: right
    
        毒？ #speaker: Layne #portrait: Layne #layout: left
    
        還想活就快去把清潔劑拿過來，別在這邊影響我工作。 #speaker: 工作狂 #portrait: Workaholic #layout: right
    
        ~ ShowMission("接受任務：尋找清潔劑")
    
        （他好像搞錯了什麼，但至少有理由進去裡面探索了。而且毒又是什麼東西？還得想辦法把身上的毒清洗掉） #speaker: Layne #portrait: Layne #layout: left
        
        -> DONE
    
    * [想個辦法吸引他的注意]
        ~ attitudeOfWorkaholic = 1
        ~ ModifyMelancholy(-5)
        ~ ModifySanity(5)
    
        喂，這邊的程式碼寫錯了，應該要這樣改！ #speaker: Layne #portrait: Layne #layout: left
        
        （奇怪……我怎麼會懂這個？） # speaker: Layne #portrait: Layne #layout: left
        
        謝了啊，找我做什麼？哦不小心沾到汙染毒素了是吧。 #speaker: 工作狂 #portrait: Workaholic #layout: right
        
        汙染毒素？ #speaker: Layne #portrait: Layne #layout: left
        
        兄弟，你也是平時都待在這裡工作都不回家的嗎？多久沒出我們園區啦？ #speaker: 工作狂 #portrait: Workaholic #layout: right
        
        工廠門口有前陣子從生物廠跑出來的輻射地毯海葵，沒穿防護衣就出去會沾到毒素，只能來找我清掉。 #speaker: 工作狂 #portrait: Workaholic #layout: right
        
        那就麻煩你了。 #speaker: Layne #portrait: Layne #layout: left
        
        去把清潔劑拿過來吧，我先繼續忙這邊的工作。 #speaker: 工作狂 #portrait: Workaholic #layout: right
    
        ~ ShowMission("接受任務：尋找清潔劑")
        
        （他好像以為我是這裡的老員工了，我不知道清潔劑放哪啊……算了，找的時候還可以順便探索這邊的情況） #speaker: Layne #portrait: Layne #layout: left

        -> DONE

=== Default ===
網路……我需要……網……路…… #speaker: 工作狂 #portrait: Workaholic #layout: right

工作使我快樂！ #speaker: 工作狂 #portrait: Workaholic #layout: right
-> DONE

=== FindCleaner ===
我找到清潔劑了，那麼接下來就麻煩你了。 #speaker: Layne #portrait: Layne #layout: left

嘖，怎麼拿個清潔劑都要那麼久。 #speaker: 工作狂 #portrait: Workaholic #layout: right

~ ShowImage(9)
你再去廢棄區找出這個原料，找到了我再幫你洗掉毒素。 #speaker: 工作狂 #portrait: Workaholic #layout: right

~ HideImage()
什麼？為什麼？ #speaker: Layne #portrait: Layne #layout: left

你耽誤我的工作進度，要我幫你清洗毒素，總得先幫我做點事情吧。 #speaker: 工作狂 #portrait: Workaholic #layout: right

你這麼熱愛工作啊？ #speaker: Layne #portrait: Layne #layout: left

當然，人活著就是為了工作，不工作跟那些死魚有什麼區別！ #speaker: 工作狂 #portrait: Workaholic #layout: right

但你又不是活…… #speaker: Layne #portrait: Layne #layout: left

那也不影響啊，你看我現在這樣多好啊，可以把睡覺、吃飯、洗澡的時間全部都拿來工作了。 #speaker: 工作狂 #portrait: Workaholic #layout: right

……你開心就好。我去總行了吧，先說好，找回來之後就要幫我把毒素洗掉。 #speaker: Layne #portrait: Layne #layout: left

{attitudeOfWorkaholic:
    - 0: 
        嘖，拖拖拉拉的，要不是沒有其他人，我哪會找效率這麼差的人幫我做事啊。快去，等你拿回原料就幫你清總行了吧。 #speaker: 工作狂 #portrait: Workaholic #layout: right
    - 1:
        嘖，本來還以為你也是對工作有熱情的人。好啦，等你拿回原料，一定馬上幫你清。 #speaker: 工作狂 #portrait: Workaholic #layout: right
}

~ RemoveFromNPC(0)
~ hasTriggeredFindCleaner = true
~ ShowMission("接受任務：尋找珍貴原料")

-> DONE

=== FindPreciousMaterials ===

你看一下是不是這個。 #speaker: Layne #portrait: Layne #layout: left

（自接過原料的那一刻起，他就直接進入狂熱的工作狀態） #speaker: 工作狂 #portrait: Workaholic #layout: right

    * [不是說好拿到原料就馬上幫我清嗎！]
        ~ ModifyMelancholy(10)
        ~ ModifySanity(-10)
        
        哎呀，那麼急幹什麼。 #speaker: 工作狂 #portrait: Workaholic #layout: right

        你不幫我，我就自己弄。（直接上手把清潔劑搶過來） #speaker: Layne #portrait: Layne #layout: left

        嘖，我處理原料很快的，是不是看不起我的效率啊？行行行，你愛自己用就自己用。 #speaker: 工作狂 #portrait: Workaholic #layout: right

        （由於不熟悉清潔步驟，不慎讓清潔劑沾到包裡的照片） # speaker: 腦內的聲音 #portrait: Narrator #layout: left

        ~ ShowImage(16)
        咦？這張照片……  #speaker: Layne #portrait: Layne #layout: left

        ~ HideImage()
        處理完剩下的邊角料就給你吧，反正我也用不上了。可以用來……  #speaker: 工作狂 #portrait: Workaholic #layout: right

    * [先幫我清！（直接上手搶回原料）]
        ~ ModifyMelancholy(-10)
        ~ ModifySanity(5)
        
        你幹什麼！別急啊！ #speaker: 工作狂 #portrait: Workaholic #layout: right

        （在爭搶的過程中，碰倒旁邊的清潔劑，同時，包裡的照片掉了出來，沾到清潔劑） # speaker: 腦內的聲音 #portrait: Narrator #layout: left
        
        行行行，我先幫你清總可以了吧。 #speaker: 工作狂 #portrait: Workaholic #layout: right
        
        （工作狂幫你處理的同時，你一邊收拾著剛剛掉出來的東西） # speaker: 腦內的聲音 #portrait: Narrator #layout: left
        
        ~ ShowImage(16)
        咦？這張照片…… #speaker: Layne #portrait: Layne #layout: left
        
        ~ PlaySound("pick up")
        ~ HideImage()
        這個邊角料就給你吧，反正我也用不上了。可以用來……  #speaker: 工作狂 #portrait: Workaholic #layout: right
        
- ~ ShowBlackScreen()
- （突然一陣精神恍惚，頭腦昏沉，等你回過神來，發現自己已經跟Skyler會合了） # speaker: 腦內的聲音 #portrait: Narrator #layout: left

~ PickupFromNPC(0)
~ PickupFromNPC(1)
~ RemoveFromNPC(1)
~ RemoveFromNPC(2)

~ hasTriggeredFindPreciousMaterials = true

~ TeleportPlayer(12, -1.1, 3.77)

-> DONE