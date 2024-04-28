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
+ [你那邊有什麼發現嗎？]
    
    # speaker: Skyler #portrait: Skyler #layout: right
    暫時還沒有呢，我再找找。別擔心，我們會想到辦法的！
    
    -> AskInfo
    
+ {hasSawStrangeSymbols && !hasAskSymbols}[找找看牆面上有什麼奇怪符號。]
    
    # speaker: Skyler #portrait: Skyler #layout: right
    我看看……啊，我看到四個符號，由左至右分別是：同心圓；一個圓圈中間有十字；跟前一個符號很像但是中間是一個點；一個 X 周圍有 4 個點。
    
    ~ hasAskSymbols = true
    
    -> AskInfo
    
+ {hasSawStrangeSymbols && hasAskSymbols}[再說一次牆面上看到的符號？]

    # speaker: Skyler #portrait: Skyler #layout: right
    我看看……啊，我看到四個符號，由左至右分別是：同心圓；一個圓圈中間有十字；跟前一個符號很像但是中間是一個點；一個 X 周圍有 4 個點。
    
    -> AskInfo
    
+ [結束通話]
    ~ ModifyMelancholy(5)
    ~ Disappear()

-> DONE