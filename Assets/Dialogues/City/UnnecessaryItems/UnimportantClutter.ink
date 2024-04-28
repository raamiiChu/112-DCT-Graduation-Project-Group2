INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left

~ temp dice_roll = RANDOM(0, 2)

{dice_roll:
    - 0: 	這個箱子裡面什麼都沒有。
    - 1: 	這個箱子裡充滿雜物，但都不是我們要的物品。
    - 2: 	這個箱子裡面只有用來鋪物品的紙，看起來將要在裡面裝進貨物。
}

-> END