Welcome to Hazy City youngster! #speaker:??? #audio:Bell
I am Mayor Bell.
I’m sorry I can’t talk much now, there is a problem with Sky Pirates that is taking all my attention. #speaker:Mayor Bell
->WhatCanDo

=== WhatCanDo ===
What can I do for you?
    +[Do you have a key to the gate?]
        ->HaveAKey
    +[What's this about Sky Pirates?]
        ->SkyPirates
    +[Goodbye]
        ->Goodbye
        
=== HaveAKey ===
When I took the hat of mayor I was also given the <color=\#F8FF30>Key</color> passed down to all mayors. 
I’ve been tasked with keeping it safe from those who wish harm.
    ->WhatCanDo
    
=== SkyPirates ===
Those nasty pirates have been messing with <b>Hazy City’s Zeppelin Transport</b> again! 
We’ve chased them off before but they always come back stronger!
    +[Where is the Zeppelin Transport Area?]
        Just past me is the platform.
        ->WhatCanDo
    +[What Happened to The Sheriff?]
        Our poor Sheriff is on bedrest after an attack from those hooligans! Now there’s no one to stand up against them.
        ->WhatCanDo
    +[I see.]
    ->WhatCanDo
    
=== Goodbye ===
Stay safe, it’s a dangerous world out there!
->END

