# LSP
Definition:
Objects should be replaceable with instances of their subtypes without changing the behaviour of the  program. Type-checking is an indicator of an LSP violation. We shouldn’t need to ask instances for their type, then conditionally perform different actions. Instead, those different actions should be encapsulated in the type itself. State and behaviour should be packaged together.

In this exercise, we fixed the LSP violation by using the null object pattern. In essence, the factory was modified to return an instance of 'UnknownPolicyRater' if it couldn't find the matching policy. In a null object pattern, a class is made using the same abstract class or interface, but is designed to represent a null or neutral value.