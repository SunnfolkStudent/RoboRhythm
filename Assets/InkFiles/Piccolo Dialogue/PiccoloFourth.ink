Is there anything I can help you with? #speaker:Piccolo
    +[I'm looking for keys to the gate.]
    -> LookingForKeys
    +[I'm lost.]
    ->Lost
    +[Do you know what’s behind the gate?]
    ->BehindTheGate
    +[Goodbye.]
    ->Goodbye
    
    
=== AnythingElse ===
Is there anything else I can help you with?
+[I'm looking for keys to the gate.]
    -> LookingForKeys
    +[I'm lost.]
    ->Lost
    +[Do you know what’s behind the gate?]
    ->BehindTheGate
    +[Goodbye.]
    ->Goodbye
    
=== LookingForKeys ===
Still looking for <color=\#F8FF30>Keys</color>?
I have heard the blacksmith holds one.
He works down near the mine if you want to speak with him.
    -> AnythingElse
    
=== Lost ===
What are you looking for?
    + [The Mines]
        <b>The Mines</b> are right down the stairs and to the left!
        ->AnythingElse
    +[The Power Plant]
        <b>The Power Plant</b> is down the stairs and to the right!
        ->AnythingElse
    +[The Gate]
        <b>The Gate</b> is just behind me!
        ->AnythingElse
    +[Nevermind.]
        ->AnythingElse
        
=== BehindTheGate ===
There are many theories and rumors on why the gate has been locked up.

Some say there is a terrible beast on the other side, waiting for it to open again.

Others say the land beyond is inhospitable and had to be closed for safety.

I think if there is anything beyond the gate, it’s long dead.

It’s been more than a hundred years, what could survive that long?

    ->AnythingElse
    
=== Goodbye ===
Come back anytime!
->END
    