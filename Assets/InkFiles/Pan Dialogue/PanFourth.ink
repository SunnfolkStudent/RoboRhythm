->WhatCan

=== WhatCan ===
What can Pan do for you?#speaker:Mad Hatter Pan  #audio:Pan
    +[Do you have a key to the gate?]
        ->HaveKey
    +[What do you think is behind the gate?]
        ->BehindGate
    +[Goodbye.]
        ->Goodbye
    
    
=== HaveKey ===
Unless the keys are also hats, Pan does not have one.
    ->WhatCan
    
=== BehindGate ===
Pan doesn’t know.
Maybe a giant hat?
    ->WhatCan
    
=== Goodbye ===
Bye!
    ->END