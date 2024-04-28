INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: Layne #portrait: Layne #layout: left
這應該是日記本中提到的柱子。

{
    - hasRotatePillar:
        
        沒有調查的必要了
    - else:
        # speaker: 腦內的聲音 #portrait: Narrator #layout: left
        你試探性地將柱子轉動了一下
        ~ Rotate(90.0)
        ~ PlaySound("explosion")
        
        台階右後方傳來了一聲巨響
        ~ DeleteStone()
        ~ hasRotatePillar = true
}
    
-> END