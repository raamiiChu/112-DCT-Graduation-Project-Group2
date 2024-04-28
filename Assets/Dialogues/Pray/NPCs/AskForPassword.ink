INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

-> main

=== main ===

~ PlaySound("beep")

# speaker: Skyler #portrait: Skyler #layout: right
Layne ，幹嘛？

-> AskInfo

-> END

=== AskInfo ===
* {hasSawPasswordDoor}[我看到一個密碼門]
    
    # speaker: Skyler #portrait: Skyler #layout: right
    我這邊也是，說是要兩邊同時輸入一樣的密碼，而且只能輸入一次。
    
    啊，石壁上還有記號，看起來應該是 9618。

    {passwordOnWall: 
        # speaker: Layne #portrait: Layne #layout: left
        我這邊牆上寫的是 4135
        
         # speaker: Skyler #portrait: Skyler #layout: right
        啊……
    }
    
    * * [輸入：9618]
        ~ ModifySanity(5)
        ~ ModifyMelancholy(-5)
        ~ PlaySound("click")
        
        你選擇相信 Skyler # speaker: 腦內的聲音 #portrait: Narrator #layout: left
        
        ~ ChangeScene("Church")
        ~ Disappear()
        -> END
    
    * * {passwordOnWall}[輸入：4135] 
        ~ ModifySanity(-10)
        ~ ModifyMelancholy(-5)
        ~ PlaySound("click")
        
        你選擇不相信 Skyler # speaker: 腦內的聲音 #portrait: Narrator #layout: left
        
        ~ ChangeScene("Church")
        ~ Disappear()
        -> END
        
    * * [繼續調查]
        # speaker: Layne #portrait: Layne #layout: left
        我先繼續調查好了，保持聯繫
        ~ Disappear()
        -> DONE
    
* [結束通話]
    ~ ModifyMelancholy(5)
    # speaker: Layne #portrait: Layne #layout: left
    我先繼續調查好了，保持聯繫
    ~ Disappear()
    -> DONE
    