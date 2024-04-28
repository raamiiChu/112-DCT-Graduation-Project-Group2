INCLUDE ../../Globals.ink
INCLUDE ../../ExternalFunctions.ink

# speaker: 腦內的聲音 #portrait: Narrator #layout: left

隸屬於「逆行者」組織的高科技潛艇，代號 CHE242，

艇齡已經接近二十年了，不過憑藉持續的精心保養，這艘潛水艇的功能和外觀仍然保持著完整無缺的狀態。

是否前往下一個場景？
    + [否]
    
    + [是]
        ~ ChangeScene("Factory")
    
-> END