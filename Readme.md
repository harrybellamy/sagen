[![CI](https://github.com/harrybellamy/sagen/actions/workflows/dotnet-ci.yml/badge.svg)](https://github.com/harrybellamy/sagen/actions/workflows/dotnet-ci.yml)


# Sagen 
Sagen is a static API generator for .NET applications.

## Core Concepts
Sagen has two core concepts:

- *Source*: a source of data to populate the API with.
- *Sink*: a destination for the API to be saved to.

Data is extracted from the *Source* and passed to the *Sink*, which then saves the data as flat files.

## Usage
Basic usage can be setup as follows:

```csharp
public async Task CreateStaticApiAsync(ISource source, ISink sink)
{
    var config = new ProcessorConfig(Source, Sink);

    var processor = new Processor();
    await processor.ProcessAsync(config);    
}
```

## Packages
Sagen is divided into a series of separate packages. 

`Sagen.Core` is the central library that contains the processor. Unless you are writing your own sources and sinks, it is unlikely you will require this package in isolation.

### Source Packages
The following source packages are available:

- `Sagen.Sources.Csv`: extract data from a CSV file.
    - All the data in the CSV file is treated as a single resource.

### Sink Packages
The following sink packages are available:

- `Sagen.Sinks.FileSystem`: save flat files to a local file system.
   - This is useful for testing the configuration of any sinks.
- `Sagen.Sinks.Azure.BlobStorage`: save flat files to an Azure Blob Storage container.

## Extensibility
The `ISource` and `ISink` interfaces from the `Sagen.Core` library can be implemented to provide custom Sources and Sinks respectively.
