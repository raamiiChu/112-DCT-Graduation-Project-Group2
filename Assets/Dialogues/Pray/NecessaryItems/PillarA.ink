INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

-> main

=== main ===
{
    - completePillars == 1:
        # speaker: 腦內的聲音 #portrait: default #layout: left
        沒必要再轉了
    - else:
        # speaker: 腦內的聲音 #portrait: default #layout: left
        這是一個石柱，看起來能輕易轉動。
        -> ask
}

-> END

=== ask ===

+ [向左轉]
    ~ Rotate(90.0)
    ~ pillarA -= 1
    向左轉動
    -> ask
    
+ [向右轉]
    ~ Rotate(-90.0)
    ~ pillarA += 1
    向右轉動
    -> ask
    
+ [離開]
    -> CheakPillars    
    
-> DONE 