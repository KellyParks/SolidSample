# Interface Segregation Principle
Definition:
Client code shouldn’t be forced to depend on methods it doesn’t use. ISP violations make classes depend on things it doesn’t need. This makes the code more brittle and tightly coupled. It also requires more testing of downstream dependencies. To follow ISP, interfaces should be broken up into smaller interfaces, so that client code doesn’t need to implement methods it doesn’t need.

Exercise Rationale
The DefaultRatingContext contains many 'NotImplementedExceptions', a sign that the interface it implements (IRatingContext) is too large. In this part of the course I broke some of the methods in IRatingContext into their own interfaces (ILogger, IRatingUpdater) to accomplish ISP. 