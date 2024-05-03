->WhatCanDo

=== WhatCanDo ===
What can I do for you? #speaker:Mayor Bell #audio:Bell
    +[Do you know where other keys are?]
        ->HaveAKey
    +[Why were the Sky Pirates attacking you?]
        ->SkyPirates
    +[Goodbye]
        ->Goodbye
        
=== HaveAKey ===
I’m sure Old Cornet has one, he’s been around long enough to have come across one.
    ->WhatCanDo
    
=== SkyPirates ===
Who knows why people like that do those things? 
They claimed they were helping us see the truth, but that sounds ridiculous to me.
    ->WhatCanDo
    
=== Goodbye ===
Stay safe, it’s a dangerous world out there!
->END
