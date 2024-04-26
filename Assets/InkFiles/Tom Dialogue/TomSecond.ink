->WhatCanDo

=== WhatCanDo ===
What can I do for you little friend? #speaker:Blacksmith Tom
    +[What's happening in the mines?]
        ->InTheMines
    +[Do you have a key to the gate?]
        ->KeyToGate
    +[What do you think is behind the gate?]
        ->BehindGate
    +[Goodbye]
        ->Goodbye
        
=== InTheMines ===
The generator is down and all my Minerbots are refusing to go down there to fix it.
They usually don’t act like this, I’m gonna get the Sheriff to go down there to look around if this keeps up.
    ->WhatCanDo
    
=== KeyToGate ===
I found one a while ago in some rubble.
It’s amazing workmanship, I don’t think I could make something so impressive.
    ->WhatCanDo
    
=== BehindGate ===
I have seen many interesting relics from beyond the wall come out of the mines.
I would love to see more of what behind it, but of course with only one <color=\#F8FF30>Key</color> that’s impossible.
    ->WhatCanDo
    
=== Goodbye ===
Goodbye then!
->END