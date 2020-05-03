# Open/Closed Principle - Notes

Definition: Entities (classes, modules, functions etc...) should be open for extension, but closed for modification. Meaning that it should be possible to change the behaviour of a method without editing its source code, so that you're not having to continually perform surgery on the same function every time a new requirement arrises).
Why should code be closed to modification?
- less likely to introduce bugs in code we don't touch
- less likely to break dependant code
- fewer conditionals in code that is open to extension results in simpler code
