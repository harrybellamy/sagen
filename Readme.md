
# Sagen 
Sagen is a static API generator for .NET applications.

## Core Concepts
Sagen has two core concepts

- *Source*: a source of data to populate the API with.
- *Sink*: a destination for the API to be saved to.

## Extensibility
The `ISource` and `ISink` interfaces from the `Sagen.Core` library can be implemented to provide custom Sources and Sinks respectively.